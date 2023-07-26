﻿using System;
using System.Drawing;
using System.Windows.Forms;
using SharpDX.XAudio2;
using SharpDX.Multimedia;
using System.IO;
using Hyperparameter_Tuning_With_Deep_Learning_Neural_Networks.Properties;
using System.Reflection;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Text.RegularExpressions;
using System.Diagnostics.Eventing.Reader;
using System.Threading;

namespace Hyperparameter_Tuning_With_Deep_Learning_Neural_Networks
{
    public partial class frmMain : Form
    {
        private const int MIN_WEIGHTED_DISTRIBUTION = 1;
        private const int MIN_EPOCHS = 1;
        private const int MIN_HIDDEN_LAYERS = 2;

        private const int MAX_WEIGHTED_DISTRIBUTION = 100;
        private const int MAX_EPOCHS = 999999999;
        private const int MAX_HIDDEN_LAYERS = 256;

        private Color FORECOLOR1 = Color.FromArgb(0, 164, 164);
        private Color FORECOLOR2 = Color.FromArgb(0, 69, 87);
        private Color FORECOLOR3 = Color.FromArgb(255, 255, 255);
        private Color BACKCOLOR1 = Color.FromArgb(29, 29, 29);
        private Color BACKCOLOR2 = Color.FromArgb(36, 36, 36);

        private Point offset;
        private bool soundEnabled;
        private bool isDragging;
        private bool disableControls;
        XAudio2 xaudio;
        Assembly assembly;

        AudioBuffer beep_buffer;
        SoundStream beep_soundstream;
        WaveFormat beep_waveFormat;

        AudioBuffer nanoblade_buffer;
        SoundStream nanoblade_soundstream;
        WaveFormat nanoblade_waveFormat;

        private bool inputEnabled;
        private bool outputEnabled;

        private string[] inputInformation = new string[7];

        private TcpListener server = null;
        private TcpClient client = null;

        private bool clientConnected;
        private CancellationTokenSource cts = new CancellationTokenSource();


        //need to find a way to pass the variables input here into the python function and display that output
        //do this as soon as possible!!!!!! Martin is bad at C#!!!!

        public frmMain()
        {
            InitializeComponent();
        }

        private void disableInputControls()
        {
            cmbXavierInitialization.Enabled = false;
            txtWeightedDistribution.Enabled = false;
            txtEpochs.Enabled = false;
            txtHiddenLayers.Enabled = false;
            cmbPriority.Enabled = false;
            cmbActivationFunction.Enabled = false;
            picClear.Enabled = false;
            picTrain.Enabled = false;
        }

        private void enableInputControls()
        {
            cmbXavierInitialization.Enabled = true;
            txtWeightedDistribution.Enabled = true;
            txtEpochs.Enabled = true;
            txtHiddenLayers.Enabled = true;
            cmbPriority.Enabled = true;
            cmbActivationFunction.Enabled = true;
            picClear.Enabled = true;
            picTrain.Enabled = true;
        }

        private async void initializeServer()
        {
            int port = 13000;
            string localAddr = "127.0.0.1";

            server = new TcpListener(IPAddress.Parse(localAddr), port); // Create a TcpListener.
            server.Start(); // Start listening for client requests.

            while (!cts.Token.IsCancellationRequested)
            {
                lblInputInformation.Text = "Controls are disabled. Waiting for a connection from Python client...";

                try
                {
                    // Perform a blocking call to accept requests. Use Task.Run to move execution to a separate thread.
                    using (cts.Token.Register(() => server.Stop()))
                    {
                        client = await server.AcceptTcpClientAsync();
                    }
                    clientConnected = true;
                    enableInputControls();
                    _ = Task.Run(() => CheckClientConnection(cts.Token), cts.Token);
                    lblInputInformation.Text = "Connected! Controls enabled.";
                    disableControls = false;

                    while (clientConnected && !cts.Token.IsCancellationRequested)
                    {
                        await Task.Delay(1000);  // wait for a second
                    }

                    // Close the previous client before accepting a new one
                    client?.Close();
                    client = null;

                    // Add a delay here to give the system time to fully close the connection
                    await Task.Delay(1000);  // Delay for a second
                }
                catch (SocketException ex)
                {
                    server?.Stop();
                    return;
                }
                catch (OperationCanceledException)
                {
                    // Operation was cancelled, break the loop
                    break;
                }
            }
        }

        private void CheckClientConnection(CancellationToken cancellationToken)
        {
            while (clientConnected && !cancellationToken.IsCancellationRequested)
            {
                try
                {
                    if (client.Client.Poll(0, SelectMode.SelectRead))
                    {
                        byte[] checkData = new byte[1];
                        if (client.Client.Receive(checkData, SocketFlags.Peek) == 0)
                        {
                            clientConnected = false;
                            disableInputControls();
                            lblInputInformation.Text = "Python client app disconnected from the server.";
                        }
                    }
                }
                catch
                {
                    clientConnected = false;
                    disableInputControls();
                    lblInputInformation.Text = "Python client app disconnected from the server.";
                }
                Task.Delay(1000).Wait(); // delay for a second
            }
        }


        private void setupInputInformation()
        {
            inputInformation[0] = string.Empty;

            inputInformation[1] = "Xavier initialization: also known as Glorot initialization, is a technique used to initialize the weights of neural networks. " +
                                  "It aims to set the initial weights in such a way that the activations and gradients during training are neither too large nor too " +
                                  "small. By initializing the weights properly, Xavier initialization helps in preventing the problem of vanishing or exploding gradients, " +
                                  "which can hinder the convergence of the neural network during training. It achieves this by scaling the initial weights based on " +
                                  "the number of input and output neurons of a layer.";

            inputInformation[2] = "Weighted Distribution Size: Determines the range of random values for initializing the weights and biases of a neural network.";

            inputInformation[3] = "Epochs: Also known as intervals, an epoch refers to a single pass of the entire training dataset through the network. During training, " +
                                  "the dataset is typically divided into smaller batches, and each batch is sequentially presented to the network for forward propagation " +
                                  "(computing the output) and backward propagation (updating the weights based on the computed errors). It is recommended to train your model " +
                                  "for at least 25 epochs.";

            inputInformation[4] = "Hidden Layers: An intermediate layer between the input layer and the output layer. It consists of " +
                                  "multiple artificial neurons, also known as activation units or nodes, which perform computations on the input data. The number of hidden " +
                                  "layers and the number of neurons in each hidden layer are design choices that depend on the complexity of the problem and the characteristics " +
                                  "of the data. Deeper networks with more hidden layers can potentially learn more intricate representations but may require more computational " +
                                  "resources and careful training.";
            
            inputInformation[5] = "Priority: This selection will determine whether you'd like to prioritize time or accuracy; prioritizing time will speed up the training process " +
                                  "and select a batch size determined to provide about 97% accuracy for the amount of epochs you have specified. Prioritizing accuracy will instead " +
                                  "default the batch size to the commonly used default of 32. At higher epoch counts, this choice will considerably slow down training, but " +
                                  "increase the test accuracy of the model by the end of training. Note that epoch counts below 25 will likely be both slow and inaccurate for either choice.";

            inputInformation[6] = "Activation Function: Determines the output of a neuron or a node, introducing non-linearity to enable the network to learn complex patterns " +
                                  "and make predictions.";
        }

        private void setupInputPanel()
        {
            cmbXavierInitialization.SelectedIndex = 0;
            txtWeightedDistribution.Text = "10";
            txtEpochs.Text = "1000";
            txtHiddenLayers.Text = "4";
            cmbPriority.SelectedIndex = 0;
            cmbActivationFunction.SelectedIndex = 0;

            if (disableControls == false) lblInputInformation.Text = inputInformation[0];
        }


        private void initializeSound(UnmanagedMemoryStream audioStream, out SoundStream soundStream, out WaveFormat waveFormat, out AudioBuffer buffer)
        {
            if (audioStream == null)
            {
                throw new ArgumentNullException(nameof(audioStream));
            }

            soundStream = new SoundStream(audioStream);
            waveFormat = soundStream.Format;

            buffer = new AudioBuffer
            {
                Stream = soundStream.ToDataStream(),
                AudioBytes = (int)soundStream.Length,
                Flags = BufferFlags.EndOfStream
            };
        }

        void setupSounds()
        {
            assembly = Assembly.GetExecutingAssembly();
            xaudio = new XAudio2();
            var masteringsound = new MasteringVoice(xaudio);

            initializeSound(Properties.Resources.beep, out beep_soundstream, out beep_waveFormat, out beep_buffer);
            initializeSound(Properties.Resources.nanoblade, out nanoblade_soundstream, out nanoblade_waveFormat, out nanoblade_buffer);
        }

        void setupInputOutput()
        {
            pnlInput.Visible = true;
            pnlOutput.Visible = false;
            inputEnabled = false;
            outputEnabled = true;
            lblInput.ForeColor = FORECOLOR2;
            lblOutput.ForeColor = FORECOLOR3;
    }

        void playSound(WaveFormat waveFormat, AudioBuffer audioBuffer, SoundStream soundStream)
        {
            if (soundEnabled == true)
            {
                SourceVoice soundVoice = new SourceVoice(xaudio, waveFormat, true);
                soundVoice.SubmitSourceBuffer(audioBuffer, soundStream.DecodedPacketsInfo);
                soundVoice.Start();
            }
        }

        void swapImage(Bitmap imageResource, PictureBox pictureBox)
        {
            Image img = imageResource;

            if (img != null)
                pictureBox.Image = img;
            else
                throw new Exception("Image not found in Resource.");
        }

        private void pnlWindowBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                offset = e.Location;
            }
        }

        private void pnlWindowBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void pnlWindowBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void picExit_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                swapImage(Resources.Exit_Button_3, picExit);
            }
        }

        private void picExit_MouseEnter(object sender, EventArgs e)
        {
            swapImage(Resources.Exit_Button_2, picExit);
            playSound(beep_waveFormat, beep_buffer, beep_soundstream);
        }

        private void picExit_MouseLeave(object sender, EventArgs e)
        {
            swapImage(Resources.Exit_Button, picExit);
        }

        private void picExit_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                swapImage(Resources.Exit_Button_2, picExit);
                playSound(nanoblade_waveFormat, nanoblade_buffer, nanoblade_soundstream);
                Application.Exit();
            }
        }

        private void picMinimize_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                swapImage(Resources.Minimize_Button_3, picMinimize);
            }
        }

        private void picMinimize_MouseEnter(object sender, EventArgs e)
        {
            swapImage(Resources.Minimize_Button_2, picMinimize);
            playSound(beep_waveFormat, beep_buffer, beep_soundstream);
        }

        private void picMinimize_MouseLeave(object sender, EventArgs e)
        {
            swapImage(Resources.Minimize_Button, picMinimize);
        }

        private void picMinimize_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                swapImage(Resources.Minimize_Button_2, picMinimize);
                playSound(nanoblade_waveFormat, nanoblade_buffer, nanoblade_soundstream);
                WindowState = FormWindowState.Minimized;
            }
        }

        private void picSound_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (soundEnabled == true)
                {
                    swapImage(Resources.Sound_Button_3, picSound);
                }
                else
                {
                    swapImage(Resources.Sound_Disabled_Button_3, picSound);
                }
            }
        }

        private void picSound_MouseEnter(object sender, EventArgs e)
        {
            if (soundEnabled == true)
            {
                swapImage(Resources.Sound_Button_2, picSound);
                playSound(beep_waveFormat, beep_buffer, beep_soundstream);
            }
            else
            {
                swapImage(Resources.Sound_Disabled_Button_3, picSound);
            }
        }

        private void picSound_MouseLeave(object sender, EventArgs e)
        {
            if (soundEnabled == true)
            {
                swapImage(Resources.Sound_Button, picSound);
            }
            else
            {
                swapImage(Resources.Sound_Disabled_Button, picSound);
            }
        }

        private void picSound_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (soundEnabled == true)
                {
                    swapImage(Resources.Sound_Disabled_Button_2, picSound);
                    soundEnabled = false;
                }
                else
                {
                    swapImage(Resources.Sound_Button_2, picSound);
                    soundEnabled = true;
                }

                playSound(nanoblade_waveFormat, nanoblade_buffer, nanoblade_soundstream);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            disableControls = true;
            soundEnabled = true;
            isDragging = false;
            clientConnected = false;
            disableInputControls();
            setupInputOutput();
            setupSounds();
            setupInputPanel();
            setupInputInformation();
            initializeServer();
        }

        private void lblInput_MouseEnter(object sender, EventArgs e)
        {
            if (inputEnabled == true)
            {
                lblInput.Visible = false;
                lblInputLarge.Visible = true;
                playSound(beep_waveFormat, beep_buffer, beep_soundstream);
            }
        }

        private void lblInputLarge_MouseLeave(object sender, EventArgs e)
        {
            lblInputLarge.Visible = false;
            lblInput.Visible = true;
        }

        private void lblInputLarge_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblInputLarge.ForeColor = FORECOLOR2;
            }
        }

        private void lblInputLarge_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                outputEnabled = true;
                inputEnabled = false;
                lblInputLarge.ForeColor = FORECOLOR1;
                lblInputLarge.Visible = false;
                lblInput.Visible = true;
                lblInput.ForeColor = FORECOLOR2;
                lblOutput.ForeColor = FORECOLOR3;
                playSound(nanoblade_waveFormat, nanoblade_buffer, nanoblade_soundstream);
                pnlOutput.Visible = false;
                pnlInput.Visible = true;
                cmbXavierInitialization.Select();
            }
        }

        private void lblOutput_MouseEnter(object sender, EventArgs e)
        {
            if (outputEnabled == true)
            {
                lblOutput.Visible = false;
                lblOutputLarge.Visible = true;
                playSound( beep_waveFormat, beep_buffer, beep_soundstream);
            }
        }

        private void lblOutputLarge_MouseLeave(object sender, EventArgs e)
        {
            lblOutputLarge.Visible = false;
            lblOutput.Visible = true;
        }

        private void lblOutputLarge_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblOutputLarge.ForeColor = FORECOLOR2;
            }
        }

        private void lblOutputLarge_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                inputEnabled = true;
                outputEnabled = false;
                lblOutputLarge.ForeColor = FORECOLOR1;
                lblOutputLarge.Visible = false;
                lblOutput.Visible = true;
                lblOutput.ForeColor = FORECOLOR2;
                lblInput.ForeColor = FORECOLOR3;
                playSound(nanoblade_waveFormat, nanoblade_buffer, nanoblade_soundstream);
                pnlInput.Visible = false;
                pnlOutput.Visible = true;
            }
        }

        private void cmbXavierInitialization_Enter(object sender, EventArgs e)
        {
            if (disableControls == false) lblInputInformation.Text = inputInformation[1];
        }

        private void txtWeightedDistribution_Enter(object sender, EventArgs e)
        {
            if (disableControls == false) lblInputInformation.Text = inputInformation[2];
        }

        private void txtEpochs_Enter(object sender, EventArgs e)
        {
            if (disableControls == false) lblInputInformation.Text = inputInformation[3];
        }

        private void txtHiddenLayers_Enter(object sender, EventArgs e)
        {
            if (disableControls == false) lblInputInformation.Text = inputInformation[4];
        }

        private void cmbBatchSize_Enter(object sender, EventArgs e)
        {
            if (disableControls == false) lblInputInformation.Text = inputInformation[5];
        }

        private void cmbActivationFunction_Enter(object sender, EventArgs e)
        {
            if (disableControls == false) lblInputInformation.Text = inputInformation[6];
        }

        private void txtWeightedDistribution_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Control && e.KeyCode != Keys.Back && e.KeyCode != Keys.Delete && 
                (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) &&
                (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9))
            {
                e.SuppressKeyPress = true; // Prevent the key from being processed
            }
        }

        private void txtWeightedDistribution_TextChanged(object sender, EventArgs e)
        {
            if (txtWeightedDistribution.Text.Length > 0 && txtWeightedDistribution.Text[0] == '0')
            {
                txtWeightedDistribution.Text = txtWeightedDistribution.Text.TrimStart('0');
            }

            if (int.TryParse(txtWeightedDistribution.Text, out int value))
            {
                if (value > MAX_WEIGHTED_DISTRIBUTION)
                {
                    txtWeightedDistribution.Text = MAX_WEIGHTED_DISTRIBUTION.ToString(); // Set the value to the maximum allowed
                    lblInputInformation.Text = "Error: Maximum value allowed for Weighted Distribution is " + MAX_WEIGHTED_DISTRIBUTION.ToString();
                }
                else if (value < MIN_WEIGHTED_DISTRIBUTION)
                {
                    txtWeightedDistribution.Text = MIN_WEIGHTED_DISTRIBUTION.ToString(); // Set the value to the minimum allowed
                    lblInputInformation.Text = "Error: Minimum value allowed for Weighted Distribution is " + MIN_WEIGHTED_DISTRIBUTION.ToString();
                }
            }
            else
            {
                txtWeightedDistribution.Text = MIN_WEIGHTED_DISTRIBUTION.ToString(); // Set the value to the minimum allowed
                lblInputInformation.Text = "Error: Minimum value allowed for Weighted Distribution is " + MIN_WEIGHTED_DISTRIBUTION.ToString();
            }
        }

        private void txtEpochs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Control && e.KeyCode != Keys.Back && e.KeyCode != Keys.Delete &&
                (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) &&
                (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9))
            {
                e.SuppressKeyPress = true; // Prevent the key from being processed
            }
        }

        private void txtEpochs_TextChanged(object sender, EventArgs e)
        {
            if (txtEpochs.Text.Length > 0 && txtEpochs.Text[0] == '0')
            {
                txtEpochs.Text = txtEpochs.Text.TrimStart('0');
            }

            if (int.TryParse(txtEpochs.Text, out int value))
            {
                if (value > MAX_EPOCHS)
                {
                    txtEpochs.Text = MAX_EPOCHS.ToString(); // Set the value to the maximum allowed
                    lblInputInformation.Text = "Error: Maximum value allowed for number of Epochs is " + MAX_EPOCHS.ToString();
                }
                else if (value < MIN_EPOCHS)
                {
                    txtEpochs.Text = MIN_EPOCHS.ToString(); // Set the value to the minimum allowed
                    lblInputInformation.Text = "Error: Minimum value allowed for number of Epochs is " + MIN_EPOCHS.ToString();
                }
            }
            else
            {
                txtEpochs.Text = MIN_EPOCHS.ToString(); // Set the value to the minimum allowed
                lblInputInformation.Text = "Error: Minimum value allowed for number of Epochs is " + MIN_EPOCHS.ToString();
            }
        }

        private void txtHiddenLayers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Control && e.KeyCode != Keys.Back && e.KeyCode != Keys.Delete &&
                (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) &&
                (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9))
            {
                e.SuppressKeyPress = true; // Prevent the key from being processed
            }
        }

        private void txtHiddenLayers_TextChanged(object sender, EventArgs e)
        {
            if (txtHiddenLayers.Text.Length > 0 && txtHiddenLayers.Text[0] == '0')
            {
                txtHiddenLayers.Text = txtHiddenLayers.Text.TrimStart('0');
            }

            if (int.TryParse(txtHiddenLayers.Text, out int value))
            {
                if (value > MAX_HIDDEN_LAYERS)
                {
                    txtHiddenLayers.Text = MAX_HIDDEN_LAYERS.ToString(); // Set the value to the maximum allowed
                    lblInputInformation.Text = "Error: Maximum value allowed for number of Hidden Layers is " + MAX_HIDDEN_LAYERS.ToString();
                }
                else if (value < MIN_HIDDEN_LAYERS)
                {
                    txtHiddenLayers.Text = MIN_HIDDEN_LAYERS.ToString(); // Set the value to the minimum allowed
                    lblInputInformation.Text = "Error: Minimum value allowed for number of Hidden Layers is " + MIN_HIDDEN_LAYERS.ToString();
                }
            }
            else
            {
                txtHiddenLayers.Text = MIN_HIDDEN_LAYERS.ToString(); // Set the value to the minimum allowed
                lblInputInformation.Text = "Error: Minimum value allowed for number of Hidden Layers is " + MIN_HIDDEN_LAYERS.ToString();
            }
        }

        private void picClear_MouseEnter(object sender, EventArgs e)
        {
            swapImage(Resources.Clear_Button_2, picClear);
        }

        private void picClear_MouseLeave(object sender, EventArgs e)
        {
            swapImage(Resources.Clear_Button, picClear);
        }

        private void picClear_MouseDown(object sender, MouseEventArgs e)
        {
            swapImage(Resources.Clear_Button_3, picClear);
        }

        private void picClear_MouseUp(object sender, MouseEventArgs e)
        {
            swapImage(Resources.Clear_Button_2, picClear);
            playSound(nanoblade_waveFormat, nanoblade_buffer, nanoblade_soundstream);
            setupInputPanel();
            ActiveControl = cmbXavierInitialization;
        }

        private void picTrain_MouseEnter(object sender, EventArgs e)
        {
            swapImage(Resources.Train_Button_2, picTrain);
        }

        private void picTrain_MouseLeave(object sender, EventArgs e)
        {
            swapImage(Resources.Train_Button, picTrain);
        }

        private void picTrain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                swapImage(Resources.Train_Button_3, picTrain);
            }
        }

        private void picTrain_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                swapImage(Resources.Train_Button_2, picTrain);
                playSound(nanoblade_waveFormat, nanoblade_buffer, nanoblade_soundstream);
                pnlInput.Visible = false;
                pnlOutput.Visible = true;
                outputEnabled = false;
                inputEnabled = true;
                lblInput.ForeColor = FORECOLOR3;
                lblOutput.ForeColor = FORECOLOR2;
                //string pythonPath = @"C:\Users\psych\AppData\Local\Programs\Python\Python39\python.exe";
                //string pythonScriptPath = Path.Combine(Directory.GetCurrentDirectory(), "python", "batchSizeTuningGoodness.py");

                //ProcessStartInfo startInfo = new ProcessStartInfo
                //{
                //    FileName = pythonPath,
                //    Arguments = $"\"{pythonScriptPath}\"",
                //    UseShellExecute = false,
                //    RedirectStandardOutput = true,
                //    RedirectStandardError = true,
                //};

                //using (Process process = Process.Start(startInfo))
                //{
                //    string result = process.StandardOutput.ReadToEnd();
                //    string error = process.StandardError.ReadToEnd();

                //    if (!string.IsNullOrEmpty(result))
                //    {
                //        MessageBox.Show(result);
                //    }

                //    if (!string.IsNullOrEmpty(error))
                //    {
                //        MessageBox.Show(error);
                //    }
                //}

            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            cts.Cancel();
            client?.Close();
            server?.Stop();
        }
    }
}
