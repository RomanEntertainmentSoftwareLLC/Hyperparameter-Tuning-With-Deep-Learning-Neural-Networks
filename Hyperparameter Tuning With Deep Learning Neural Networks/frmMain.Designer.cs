namespace Hyperparameter_Tuning_With_Deep_Learning_Neural_Networks
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlWindowBar = new System.Windows.Forms.Panel();
            this.picExit = new System.Windows.Forms.PictureBox();
            this.picMinimize = new System.Windows.Forms.PictureBox();
            this.picSound = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSidePanel = new System.Windows.Forms.Panel();
            this.lblOutputLarge = new System.Windows.Forms.Label();
            this.lblInputLarge = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.lblInput = new System.Windows.Forms.Label();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.picTrain = new System.Windows.Forms.PictureBox();
            this.picClear = new System.Windows.Forms.PictureBox();
            this.lblInputInformation = new System.Windows.Forms.Label();
            this.cmbActivationFunction = new System.Windows.Forms.ComboBox();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.txtHiddenLayers = new System.Windows.Forms.TextBox();
            this.txtEpochs = new System.Windows.Forms.TextBox();
            this.txtWeightedDistribution = new System.Windows.Forms.TextBox();
            this.cmbXavierInitialization = new System.Windows.Forms.ComboBox();
            this.lblActivationFunction = new System.Windows.Forms.Label();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblXavierInitialization = new System.Windows.Forms.Label();
            this.lblHiddenLayers = new System.Windows.Forms.Label();
            this.lblEpochs = new System.Windows.Forms.Label();
            this.lblInputTitle = new System.Windows.Forms.Label();
            this.lblWeightedDistribution = new System.Windows.Forms.Label();
            this.pnlOutput = new System.Windows.Forms.Panel();
            this.lblResults = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lblPercentComplete = new System.Windows.Forms.Label();
            this.picPercentComplete = new System.Windows.Forms.PictureBox();
            this.lblOutputTitle = new System.Windows.Forms.Label();
            this.pnlWindowBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSound)).BeginInit();
            this.pnlSidePanel.SuspendLayout();
            this.pnlInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTrain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClear)).BeginInit();
            this.pnlOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPercentComplete)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlWindowBar
            // 
            this.pnlWindowBar.Controls.Add(this.picExit);
            this.pnlWindowBar.Controls.Add(this.picMinimize);
            this.pnlWindowBar.Controls.Add(this.picSound);
            this.pnlWindowBar.Location = new System.Drawing.Point(0, 0);
            this.pnlWindowBar.Name = "pnlWindowBar";
            this.pnlWindowBar.Size = new System.Drawing.Size(1265, 30);
            this.pnlWindowBar.TabIndex = 0;
            this.pnlWindowBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlWindowBar_MouseDown);
            this.pnlWindowBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlWindowBar_MouseMove);
            this.pnlWindowBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlWindowBar_MouseUp);
            // 
            // picExit
            // 
            this.picExit.Image = global::Hyperparameter_Tuning_With_Deep_Learning_Neural_Networks.Properties.Resources.Exit_Button;
            this.picExit.Location = new System.Drawing.Point(1229, 0);
            this.picExit.Name = "picExit";
            this.picExit.Size = new System.Drawing.Size(30, 30);
            this.picExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picExit.TabIndex = 2;
            this.picExit.TabStop = false;
            this.picExit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picExit_MouseDown);
            this.picExit.MouseEnter += new System.EventHandler(this.picExit_MouseEnter);
            this.picExit.MouseLeave += new System.EventHandler(this.picExit_MouseLeave);
            this.picExit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picExit_MouseUp);
            // 
            // picMinimize
            // 
            this.picMinimize.Image = global::Hyperparameter_Tuning_With_Deep_Learning_Neural_Networks.Properties.Resources.Minimize_Button;
            this.picMinimize.Location = new System.Drawing.Point(1192, 0);
            this.picMinimize.Name = "picMinimize";
            this.picMinimize.Size = new System.Drawing.Size(30, 30);
            this.picMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMinimize.TabIndex = 1;
            this.picMinimize.TabStop = false;
            this.picMinimize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picMinimize_MouseDown);
            this.picMinimize.MouseEnter += new System.EventHandler(this.picMinimize_MouseEnter);
            this.picMinimize.MouseLeave += new System.EventHandler(this.picMinimize_MouseLeave);
            this.picMinimize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picMinimize_MouseUp);
            // 
            // picSound
            // 
            this.picSound.Image = global::Hyperparameter_Tuning_With_Deep_Learning_Neural_Networks.Properties.Resources.Sound_Button;
            this.picSound.Location = new System.Drawing.Point(1155, 0);
            this.picSound.Name = "picSound";
            this.picSound.Size = new System.Drawing.Size(30, 30);
            this.picSound.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSound.TabIndex = 0;
            this.picSound.TabStop = false;
            this.picSound.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picSound_MouseDown);
            this.picSound.MouseEnter += new System.EventHandler(this.picSound_MouseEnter);
            this.picSound.MouseLeave += new System.EventHandler(this.picSound_MouseLeave);
            this.picSound.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picSound_MouseUp);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(164)))), ((int)(((byte)(164)))));
            this.lblTitle.Location = new System.Drawing.Point(385, 33);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(598, 25);
            this.lblTitle.TabIndex = 84;
            this.lblTitle.Text = "Hyperparameter Tuning With Deep Learning Neural Networks";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSidePanel
            // 
            this.pnlSidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.pnlSidePanel.Controls.Add(this.lblOutputLarge);
            this.pnlSidePanel.Controls.Add(this.lblInputLarge);
            this.pnlSidePanel.Controls.Add(this.lblOutput);
            this.pnlSidePanel.Controls.Add(this.lblInput);
            this.pnlSidePanel.Location = new System.Drawing.Point(0, 0);
            this.pnlSidePanel.Name = "pnlSidePanel";
            this.pnlSidePanel.Size = new System.Drawing.Size(150, 678);
            this.pnlSidePanel.TabIndex = 85;
            // 
            // lblOutputLarge
            // 
            this.lblOutputLarge.AutoSize = true;
            this.lblOutputLarge.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutputLarge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(164)))), ((int)(((byte)(164)))));
            this.lblOutputLarge.Location = new System.Drawing.Point(15, 122);
            this.lblOutputLarge.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutputLarge.Name = "lblOutputLarge";
            this.lblOutputLarge.Size = new System.Drawing.Size(114, 37);
            this.lblOutputLarge.TabIndex = 89;
            this.lblOutputLarge.Text = "Output";
            this.lblOutputLarge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOutputLarge.Visible = false;
            this.lblOutputLarge.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblOutputLarge_MouseDown);
            this.lblOutputLarge.MouseLeave += new System.EventHandler(this.lblOutputLarge_MouseLeave);
            this.lblOutputLarge.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblOutputLarge_MouseUp);
            // 
            // lblInputLarge
            // 
            this.lblInputLarge.AutoSize = true;
            this.lblInputLarge.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInputLarge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(164)))), ((int)(((byte)(164)))));
            this.lblInputLarge.Location = new System.Drawing.Point(29, 82);
            this.lblInputLarge.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInputLarge.Name = "lblInputLarge";
            this.lblInputLarge.Size = new System.Drawing.Size(88, 37);
            this.lblInputLarge.TabIndex = 88;
            this.lblInputLarge.Text = "Input";
            this.lblInputLarge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInputLarge.Visible = false;
            this.lblInputLarge.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblInputLarge_MouseDown);
            this.lblInputLarge.MouseLeave += new System.EventHandler(this.lblInputLarge_MouseLeave);
            this.lblInputLarge.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblInputLarge_MouseUp);
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutput.ForeColor = System.Drawing.Color.White;
            this.lblOutput.Location = new System.Drawing.Point(38, 130);
            this.lblOutput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(76, 25);
            this.lblOutput.TabIndex = 87;
            this.lblOutput.Text = "Output";
            this.lblOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOutput.MouseEnter += new System.EventHandler(this.lblOutput_MouseEnter);
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInput.ForeColor = System.Drawing.Color.White;
            this.lblInput.Location = new System.Drawing.Point(47, 90);
            this.lblInput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(59, 25);
            this.lblInput.TabIndex = 86;
            this.lblInput.Text = "Input";
            this.lblInput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInput.MouseEnter += new System.EventHandler(this.lblInput_MouseEnter);
            // 
            // pnlInput
            // 
            this.pnlInput.Controls.Add(this.picTrain);
            this.pnlInput.Controls.Add(this.picClear);
            this.pnlInput.Controls.Add(this.lblInputInformation);
            this.pnlInput.Controls.Add(this.cmbActivationFunction);
            this.pnlInput.Controls.Add(this.cmbPriority);
            this.pnlInput.Controls.Add(this.txtHiddenLayers);
            this.pnlInput.Controls.Add(this.txtEpochs);
            this.pnlInput.Controls.Add(this.txtWeightedDistribution);
            this.pnlInput.Controls.Add(this.cmbXavierInitialization);
            this.pnlInput.Controls.Add(this.lblActivationFunction);
            this.pnlInput.Controls.Add(this.lblPriority);
            this.pnlInput.Controls.Add(this.lblXavierInitialization);
            this.pnlInput.Controls.Add(this.lblHiddenLayers);
            this.pnlInput.Controls.Add(this.lblEpochs);
            this.pnlInput.Controls.Add(this.lblInputTitle);
            this.pnlInput.Controls.Add(this.lblWeightedDistribution);
            this.pnlInput.Location = new System.Drawing.Point(156, 64);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(1103, 614);
            this.pnlInput.TabIndex = 86;
            // 
            // picTrain
            // 
            this.picTrain.Enabled = false;
            this.picTrain.Image = global::Hyperparameter_Tuning_With_Deep_Learning_Neural_Networks.Properties.Resources.Train_Button;
            this.picTrain.Location = new System.Drawing.Point(585, 384);
            this.picTrain.Name = "picTrain";
            this.picTrain.Size = new System.Drawing.Size(220, 60);
            this.picTrain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTrain.TabIndex = 102;
            this.picTrain.TabStop = false;
            this.picTrain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picTrain_MouseDown);
            this.picTrain.MouseEnter += new System.EventHandler(this.picTrain_MouseEnter);
            this.picTrain.MouseLeave += new System.EventHandler(this.picTrain_MouseLeave);
            this.picTrain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picTrain_MouseUp);
            // 
            // picClear
            // 
            this.picClear.Enabled = false;
            this.picClear.Image = global::Hyperparameter_Tuning_With_Deep_Learning_Neural_Networks.Properties.Resources.Clear_Button;
            this.picClear.Location = new System.Drawing.Point(309, 384);
            this.picClear.Name = "picClear";
            this.picClear.Size = new System.Drawing.Size(220, 60);
            this.picClear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClear.TabIndex = 101;
            this.picClear.TabStop = false;
            this.picClear.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picClear_MouseDown);
            this.picClear.MouseEnter += new System.EventHandler(this.picClear_MouseEnter);
            this.picClear.MouseLeave += new System.EventHandler(this.picClear_MouseLeave);
            this.picClear.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picClear_MouseUp);
            // 
            // lblInputInformation
            // 
            this.lblInputInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInputInformation.ForeColor = System.Drawing.Color.White;
            this.lblInputInformation.Location = new System.Drawing.Point(33, 492);
            this.lblInputInformation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInputInformation.Name = "lblInputInformation";
            this.lblInputInformation.Size = new System.Drawing.Size(1033, 116);
            this.lblInputInformation.TabIndex = 100;
            // 
            // cmbActivationFunction
            // 
            this.cmbActivationFunction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.cmbActivationFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActivationFunction.Enabled = false;
            this.cmbActivationFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbActivationFunction.ForeColor = System.Drawing.Color.White;
            this.cmbActivationFunction.FormattingEnabled = true;
            this.cmbActivationFunction.Items.AddRange(new object[] {
            "Sigmoid",
            "Tanh",
            "Relu"});
            this.cmbActivationFunction.Location = new System.Drawing.Point(436, 297);
            this.cmbActivationFunction.Name = "cmbActivationFunction";
            this.cmbActivationFunction.Size = new System.Drawing.Size(260, 33);
            this.cmbActivationFunction.TabIndex = 99;
            this.cmbActivationFunction.Enter += new System.EventHandler(this.cmbActivationFunction_Enter);
            // 
            // cmbPriority
            // 
            this.cmbPriority.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority.Enabled = false;
            this.cmbPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPriority.ForeColor = System.Drawing.Color.White;
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Items.AddRange(new object[] {
            "Time",
            "Accuracy"});
            this.cmbPriority.Location = new System.Drawing.Point(436, 257);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(260, 33);
            this.cmbPriority.TabIndex = 98;
            this.cmbPriority.Enter += new System.EventHandler(this.cmbBatchSize_Enter);
            // 
            // txtHiddenLayers
            // 
            this.txtHiddenLayers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.txtHiddenLayers.Enabled = false;
            this.txtHiddenLayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHiddenLayers.ForeColor = System.Drawing.Color.White;
            this.txtHiddenLayers.Location = new System.Drawing.Point(436, 218);
            this.txtHiddenLayers.Name = "txtHiddenLayers";
            this.txtHiddenLayers.Size = new System.Drawing.Size(260, 31);
            this.txtHiddenLayers.TabIndex = 97;
            this.txtHiddenLayers.Text = "4";
            this.txtHiddenLayers.TextChanged += new System.EventHandler(this.txtHiddenLayers_TextChanged);
            this.txtHiddenLayers.Enter += new System.EventHandler(this.txtHiddenLayers_Enter);
            this.txtHiddenLayers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHiddenLayers_KeyDown);
            // 
            // txtEpochs
            // 
            this.txtEpochs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.txtEpochs.Enabled = false;
            this.txtEpochs.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEpochs.ForeColor = System.Drawing.Color.White;
            this.txtEpochs.Location = new System.Drawing.Point(436, 176);
            this.txtEpochs.Name = "txtEpochs";
            this.txtEpochs.Size = new System.Drawing.Size(260, 31);
            this.txtEpochs.TabIndex = 96;
            this.txtEpochs.Text = "1000";
            this.txtEpochs.TextChanged += new System.EventHandler(this.txtEpochs_TextChanged);
            this.txtEpochs.Enter += new System.EventHandler(this.txtEpochs_Enter);
            this.txtEpochs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEpochs_KeyDown);
            // 
            // txtWeightedDistribution
            // 
            this.txtWeightedDistribution.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.txtWeightedDistribution.Enabled = false;
            this.txtWeightedDistribution.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeightedDistribution.ForeColor = System.Drawing.Color.White;
            this.txtWeightedDistribution.Location = new System.Drawing.Point(436, 134);
            this.txtWeightedDistribution.Name = "txtWeightedDistribution";
            this.txtWeightedDistribution.Size = new System.Drawing.Size(260, 31);
            this.txtWeightedDistribution.TabIndex = 95;
            this.txtWeightedDistribution.Text = "10";
            this.txtWeightedDistribution.TextChanged += new System.EventHandler(this.txtWeightedDistribution_TextChanged);
            this.txtWeightedDistribution.Enter += new System.EventHandler(this.txtWeightedDistribution_Enter);
            this.txtWeightedDistribution.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWeightedDistribution_KeyDown);
            // 
            // cmbXavierInitialization
            // 
            this.cmbXavierInitialization.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.cmbXavierInitialization.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbXavierInitialization.Enabled = false;
            this.cmbXavierInitialization.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbXavierInitialization.ForeColor = System.Drawing.Color.White;
            this.cmbXavierInitialization.FormattingEnabled = true;
            this.cmbXavierInitialization.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cmbXavierInitialization.Location = new System.Drawing.Point(436, 92);
            this.cmbXavierInitialization.Name = "cmbXavierInitialization";
            this.cmbXavierInitialization.Size = new System.Drawing.Size(260, 33);
            this.cmbXavierInitialization.TabIndex = 94;
            this.cmbXavierInitialization.Enter += new System.EventHandler(this.cmbXavierInitialization_Enter);
            // 
            // lblActivationFunction
            // 
            this.lblActivationFunction.AutoSize = true;
            this.lblActivationFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActivationFunction.ForeColor = System.Drawing.Color.White;
            this.lblActivationFunction.Location = new System.Drawing.Point(218, 300);
            this.lblActivationFunction.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblActivationFunction.Name = "lblActivationFunction";
            this.lblActivationFunction.Size = new System.Drawing.Size(195, 25);
            this.lblActivationFunction.TabIndex = 93;
            this.lblActivationFunction.Text = "Activation Function";
            this.lblActivationFunction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriority.ForeColor = System.Drawing.Color.White;
            this.lblPriority.Location = new System.Drawing.Point(333, 260);
            this.lblPriority.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(79, 25);
            this.lblPriority.TabIndex = 92;
            this.lblPriority.Text = "Priority";
            this.lblPriority.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblXavierInitialization
            // 
            this.lblXavierInitialization.AutoSize = true;
            this.lblXavierInitialization.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXavierInitialization.ForeColor = System.Drawing.Color.White;
            this.lblXavierInitialization.Location = new System.Drawing.Point(220, 100);
            this.lblXavierInitialization.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblXavierInitialization.Name = "lblXavierInitialization";
            this.lblXavierInitialization.Size = new System.Drawing.Size(192, 25);
            this.lblXavierInitialization.TabIndex = 91;
            this.lblXavierInitialization.Text = "Xavier Initialization";
            this.lblXavierInitialization.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHiddenLayers
            // 
            this.lblHiddenLayers.AutoSize = true;
            this.lblHiddenLayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHiddenLayers.ForeColor = System.Drawing.Color.White;
            this.lblHiddenLayers.Location = new System.Drawing.Point(229, 220);
            this.lblHiddenLayers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHiddenLayers.Name = "lblHiddenLayers";
            this.lblHiddenLayers.Size = new System.Drawing.Size(188, 25);
            this.lblHiddenLayers.TabIndex = 90;
            this.lblHiddenLayers.Text = "Hidden Layer Size";
            this.lblHiddenLayers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEpochs
            // 
            this.lblEpochs.AutoSize = true;
            this.lblEpochs.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEpochs.ForeColor = System.Drawing.Color.White;
            this.lblEpochs.Location = new System.Drawing.Point(333, 180);
            this.lblEpochs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEpochs.Name = "lblEpochs";
            this.lblEpochs.Size = new System.Drawing.Size(84, 25);
            this.lblEpochs.TabIndex = 89;
            this.lblEpochs.Text = "Epochs";
            this.lblEpochs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInputTitle
            // 
            this.lblInputTitle.AutoSize = true;
            this.lblInputTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInputTitle.ForeColor = System.Drawing.Color.White;
            this.lblInputTitle.Location = new System.Drawing.Point(406, 26);
            this.lblInputTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInputTitle.Name = "lblInputTitle";
            this.lblInputTitle.Size = new System.Drawing.Size(278, 37);
            this.lblInputTitle.TabIndex = 88;
            this.lblInputTitle.Text = "Input Parameters";
            this.lblInputTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWeightedDistribution
            // 
            this.lblWeightedDistribution.AutoSize = true;
            this.lblWeightedDistribution.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeightedDistribution.ForeColor = System.Drawing.Color.White;
            this.lblWeightedDistribution.Location = new System.Drawing.Point(147, 140);
            this.lblWeightedDistribution.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWeightedDistribution.Name = "lblWeightedDistribution";
            this.lblWeightedDistribution.Size = new System.Drawing.Size(265, 25);
            this.lblWeightedDistribution.TabIndex = 87;
            this.lblWeightedDistribution.Text = "Weighted Distribution Size";
            this.lblWeightedDistribution.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlOutput
            // 
            this.pnlOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.pnlOutput.Controls.Add(this.lblResults);
            this.pnlOutput.Controls.Add(this.listBox1);
            this.pnlOutput.Controls.Add(this.lblPercentComplete);
            this.pnlOutput.Controls.Add(this.picPercentComplete);
            this.pnlOutput.Controls.Add(this.lblOutputTitle);
            this.pnlOutput.Location = new System.Drawing.Point(156, 64);
            this.pnlOutput.Name = "pnlOutput";
            this.pnlOutput.Size = new System.Drawing.Size(1103, 614);
            this.pnlOutput.TabIndex = 87;
            this.pnlOutput.Visible = false;
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.BackColor = System.Drawing.Color.Transparent;
            this.lblResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResults.ForeColor = System.Drawing.Color.White;
            this.lblResults.Location = new System.Drawing.Point(495, 225);
            this.lblResults.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(70, 20);
            this.lblResults.TabIndex = 93;
            this.lblResults.Text = "Results";
            this.lblResults.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.ForeColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Items.AddRange(new object[] {
            "Epoch 993/1000",
            "1/1 [==============================] - 0s 289ms/step - loss: 0.0916 - accuracy: 0" +
                ".9724 - val_loss: 0.0841 - val_accuracy: 0.9749",
            "Epoch 994/1000",
            "1/1 [==============================] - 0s 290ms/step - loss: 0.0908 - accuracy: 0" +
                ".9721 - val_loss: 0.0840 - val_accuracy: 0.9750",
            "Epoch 995/1000",
            "1/1 [==============================] - 0s 290ms/step - loss: 0.0890 - accuracy: 0" +
                ".9725 - val_loss: 0.0840 - val_accuracy: 0.9750",
            "Epoch 996/1000",
            "1/1 [==============================] - 0s 286ms/step - loss: 0.0901 - accuracy: 0" +
                ".9719 - val_loss: 0.0839 - val_accuracy: 0.9750",
            "Epoch 997/1000",
            "1/1 [==============================] - 0s 288ms/step - loss: 0.0882 - accuracy: 0" +
                ".9736 - val_loss: 0.0838 - val_accuracy: 0.9749",
            "Epoch 998/1000",
            "1/1 [==============================] - 0s 288ms/step - loss: 0.0891 - accuracy: 0" +
                ".9728 - val_loss: 0.0836 - val_accuracy: 0.9751",
            "Epoch 999/1000",
            "1/1 [==============================] - 0s 291ms/step - loss: 0.0886 - accuracy: 0" +
                ".9737 - val_loss: 0.0835 - val_accuracy: 0.9750",
            "Epoch 1000/1000",
            "1/1 [==============================] - 0s 288ms/step - loss: 0.0908 - accuracy: 0" +
                ".9723 - val_loss: 0.0835 - val_accuracy: 0.9749",
            "Test loss:  0.08349700272083282",
            "Test accuracy:  0.9749000072479248"});
            this.listBox1.Location = new System.Drawing.Point(141, 258);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(793, 320);
            this.listBox1.TabIndex = 92;
            // 
            // lblPercentComplete
            // 
            this.lblPercentComplete.AutoSize = true;
            this.lblPercentComplete.BackColor = System.Drawing.Color.Transparent;
            this.lblPercentComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentComplete.ForeColor = System.Drawing.Color.White;
            this.lblPercentComplete.Location = new System.Drawing.Point(420, 134);
            this.lblPercentComplete.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPercentComplete.Name = "lblPercentComplete";
            this.lblPercentComplete.Size = new System.Drawing.Size(222, 20);
            this.lblPercentComplete.TabIndex = 91;
            this.lblPercentComplete.Text = "Percent Complete: 100.0%";
            this.lblPercentComplete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picPercentComplete
            // 
            this.picPercentComplete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(164)))), ((int)(((byte)(164)))));
            this.picPercentComplete.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPercentComplete.Location = new System.Drawing.Point(141, 102);
            this.picPercentComplete.Name = "picPercentComplete";
            this.picPercentComplete.Size = new System.Drawing.Size(793, 26);
            this.picPercentComplete.TabIndex = 90;
            this.picPercentComplete.TabStop = false;
            // 
            // lblOutputTitle
            // 
            this.lblOutputTitle.AutoSize = true;
            this.lblOutputTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutputTitle.ForeColor = System.Drawing.Color.White;
            this.lblOutputTitle.Location = new System.Drawing.Point(473, 26);
            this.lblOutputTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutputTitle.Name = "lblOutputTitle";
            this.lblOutputTitle.Size = new System.Drawing.Size(120, 37);
            this.lblOutputTitle.TabIndex = 89;
            this.lblOutputTitle.Text = "Output";
            this.lblOutputTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.pnlSidePanel);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlWindowBar);
            this.Controls.Add(this.pnlInput);
            this.Controls.Add(this.pnlOutput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hyperparameter Tuning With Deep Learning Neural Networks";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlWindowBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSound)).EndInit();
            this.pnlSidePanel.ResumeLayout(false);
            this.pnlSidePanel.PerformLayout();
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTrain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClear)).EndInit();
            this.pnlOutput.ResumeLayout(false);
            this.pnlOutput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPercentComplete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlWindowBar;
        private System.Windows.Forms.PictureBox picSound;
        private System.Windows.Forms.PictureBox picExit;
        private System.Windows.Forms.PictureBox picMinimize;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlSidePanel;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Label lblInputLarge;
        private System.Windows.Forms.Label lblOutputLarge;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.Label lblInputTitle;
        private System.Windows.Forms.Label lblWeightedDistribution;
        private System.Windows.Forms.Label lblEpochs;
        private System.Windows.Forms.Label lblActivationFunction;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblXavierInitialization;
        private System.Windows.Forms.Label lblHiddenLayers;
        private System.Windows.Forms.ComboBox cmbXavierInitialization;
        private System.Windows.Forms.TextBox txtWeightedDistribution;
        private System.Windows.Forms.ComboBox cmbActivationFunction;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.TextBox txtHiddenLayers;
        private System.Windows.Forms.TextBox txtEpochs;
        private System.Windows.Forms.Panel pnlOutput;
        private System.Windows.Forms.Label lblOutputTitle;
        private System.Windows.Forms.Label lblInputInformation;
        private System.Windows.Forms.PictureBox picTrain;
        private System.Windows.Forms.PictureBox picClear;
        private System.Windows.Forms.Label lblPercentComplete;
        private System.Windows.Forms.PictureBox picPercentComplete;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.ListBox listBox1;
    }
}

