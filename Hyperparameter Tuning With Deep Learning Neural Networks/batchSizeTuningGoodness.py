import keras
from keras.datasets import mnist
from keras.datasets import cifar10
from keras.models import Sequential
from keras.layers import Dense, Dropout, Flatten
from keras.layers import Conv2D, MaxPooling2D
from keras import backend as K
from keras.callbacks import Callback
import numpy as np
import math
import socket
import errno
import json

'''
This module will automatically choose a batch size for a keras sequential model
based on the amount of epochs the model will be trained for, and whether the user wants to 
prioritize accuracy or speed of training.

Params:
epochs = the amount of epochs the model will train for
accOrTime = whether the user priorititzes model accuracy or training speed; 0 prioritizes time, 1 prioritizes accuracy, 0 by default
inputDataSet = the dataset that will be used; mnist by default
'''

'''
TODO: 
    - Add dynamic batch size tuning capabilities
    - Abstract function to allow for different datasets and models
    - Add further parameters such as learning rate function
'''

BUFFER_SIZE = 1024  # Use a constant for the buffer size
xavierInitialization = True
weightedDistributionSize = 10
epochs = 1000
hiddenLayerSize = 4
priority = 0
activationFunction = "ReLU"
client_socket = None


class TrainingMonitor(Callback):
    def __init__(self, clientSocket, total_epochs):
        self.socket = clientSocket
        self.total_epochs = total_epochs

    '''def on_epoch_end(self, epoch, logs=None):
        logs = logs or {}
        json_logs = json.dumps(str(logs), ensure_ascii=False)
        self.socket.send((json_logs + '\n').encode('utf-8'))  # Add '\n' at the end'''

    def on_epoch_end(self, epoch, logs=None):
        logs = logs or {}
        percent_complete = ((epoch+1) / self.total_epochs) * 100  # Calculate percent complete
        logs_with_epoch = {**logs, 'epoch': f'{epoch+1}/{self.total_epochs}',
                           'percent_complete': f"{percent_complete:.2f}"}
        json_logs = json.dumps(logs_with_epoch, ensure_ascii=False)
        self.socket.send((json_logs + '\n').encode('utf-8'))  # Add '\n' at the end


def kerasBatchSizeTuner(xavierInit=True, weightedDist=10, epochIterations=1000, numHiddenLayers=4, accOrTime=0,
                        activation="ReLU", inputDataSet=mnist.load_data()):
    # creating keras model input from the dataset
    (x_train, y_train), (x_test, y_test) = inputDataSet
    print('x_train shape: ', x_train.shape)
    print(x_train.shape[0], 'training samples')
    print(x_test.shape[0], 'test samples')
    num_classes = len(np.unique(y_train))

    y_train = keras.utils.to_categorical(y_train, num_classes)
    y_test = keras.utils.to_categorical(y_test, num_classes)

    # initializing a sequential keras model
    model = Sequential()

    # adding layers to the model
    model.add(Flatten())

    # Define initializer based on user's choice
    if xavierInit:
        initializer = 'glorot_uniform'
    else:
        initializer = keras.initializers.RandomUniform(minval=-weightedDist, maxval=weightedDist, seed=None)

    # Add hidden layers based on user's choice
    for _ in range(numHiddenLayers):
        model.add(Dense(128, activation=activation.lower(), kernel_initializer=initializer))
        model.add(Dropout(0.5))

    model.add(Dense(num_classes, activation='softmax'))

    # compiling model with the categorical cross entropy loss function and the adam optimizer
    model.compile(loss=keras.losses.categorical_crossentropy,
                  optimizer=keras.optimizers.Adam(),
                  metrics=['accuracy'])

    x_train = x_train.astype('float32')
    x_test = x_test.astype('float32')
    x_train /= 255
    x_test /= 255

    if accOrTime == 0:  # prioritizing time
        # Do not use. It is approximately 3,306,772,394 if using 1000 epochs. This makes no sense.
        # batch_size = 2 ** (int(math.sqrt(epochIterations)))
        batch_size = max(int(x_train.shape[0] * 0.1), 1)  # 10% of training data for time purposes.
    elif accOrTime == 1:  # prioritizing accuracy
        batch_size = 32

    if batch_size <= 0:
        batch_size = 1
        error_message = "Invalid prioritization choice. Batch size set to 1."
        print(error_message)
        error_results = {'error_results': error_message}
        json_results = json.dumps(error_results, ensure_ascii=False)
        client_socket.send((json_results + '\n').encode('utf-8'))
    elif batch_size > x_train.shape[0]:
        batch_size = x_train.shape[0]
        error_message = "Invalid prioritization choice. Batch size set to maximum available."
        print(error_message)
        error_results = {'error_results': error_message}
        json_results = json.dumps(error_results, ensure_ascii=False)
        client_socket.send((json_results + '\n').encode('utf-8'))

    print("Batch Size: ", batch_size)

    # training model
    model.fit(x_train, y_train,
              batch_size=batch_size,
              epochs=epochIterations,
              verbose=1,
              validation_data=(x_test, y_test),
              callbacks=[TrainingMonitor(client_socket, epochIterations)])
    # testing model
    score = model.evaluate(x_test, y_test, verbose=0)
    # send test loss and accuracy to server
    test_results = {'test_loss': score[0], 'test_accuracy': score[1]}
    json_results = json.dumps(test_results, ensure_ascii=False)
    client_socket.send((json_results + '\n').encode('utf-8'))
    print('Test loss: ', score[0])
    print('Test accuracy: ', score[1])


def client_program():
    global xavierInitialization
    global weightedDistributionSize
    global epochs
    global hiddenLayerSize
    global priority
    global activationFunction
    global client_socket
    host = "127.0.0.1"
    port = 13000  # The same port as used by the server

    client_socket = socket.socket()  # instantiate

    print("Establishing connection with the server...")

    try:
        client_socket.connect((host, port))  # connect to the server
    except socket.error as e:
        if e.errno == errno.ECONNREFUSED:
            print("Could not connect to the server. Please ensure the server is "
                  "running before running this application.")
            return
        print(f"Could not connect to server: {e}")
        return

    print("Connected to Server")

    data_json = None  # initialize data_json
    message_buffer = ""

    while True:
        try:
            # Receive data from the server
            data = client_socket.recv(BUFFER_SIZE)

            # If there's no data, that could mean the server has disconnected
            if not data:
                print("Server has disconnected.")
                break
            else:
                message_buffer += data.decode()

                while "\n" in message_buffer:
                    message, message_buffer = message_buffer.split("\n", 1)
                    message = message.strip()  # remove leading/trailing spaces

                    if not message.startswith("ping"):
                        print(f"Received data: {message}")  # this will only print data that doesn't start with "ping"
                        try:
                            data_json = json.loads(message)
                            xavierInitialization = data_json["xavierInitialization"]
                            weightedDistributionSize = data_json["weightedDistributionSize"]
                            epochs = data_json["epochs"]
                            hiddenLayerSize = data_json["hiddenLayerSize"]
                            priority = data_json["priority"]
                            activationFunction = data_json["activationFunction"]
                            print("xavierInitialization: ", xavierInitialization)
                            print("weightedDistributionSize: ", weightedDistributionSize)
                            print("epochs: ", epochs)
                            print("hiddenLayerSize: ", hiddenLayerSize)
                            if priority == 0:
                                print("priority: Time")
                            elif priority == 1:
                                print("priority: Accuracy")
                            print("activationFunction: ", activationFunction)
                            kerasBatchSizeTuner(xavierInitialization, weightedDistributionSize, epochs,
                                                hiddenLayerSize, priority, activationFunction)

                        except json.JSONDecodeError:
                            print(f"Received data is not valid JSON: {message}")
        except socket.error as e:
            print("An error occurred: ", str(e))
            break
        except KeyboardInterrupt:
            print("Interrupted by user.")
            break


if __name__ == '__main__':
    client_program()