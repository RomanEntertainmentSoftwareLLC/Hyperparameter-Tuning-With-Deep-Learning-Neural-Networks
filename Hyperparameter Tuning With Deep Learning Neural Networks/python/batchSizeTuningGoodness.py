import keras
from keras.datasets import mnist
from keras.datasets import cifar10
from keras.models import Sequential
from keras.layers import Dense, Dropout, Flatten
from keras.layers import Conv2D, MaxPooling2D
from keras import backend as K
import numpy as np
import math

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

def kerasBatchSizeTuner(epochs, accOrTime = 0, inputDataSet = mnist.load_data()): 

    #creating keras model input from the dataset
    (x_train, y_train), (x_test, y_test) = inputDataSet
    print('x_train shape: ', x_train.shape)
    print(x_train.shape[0], 'training samples')
    print(x_test.shape[0], 'test samples')
    num_classes = len(np.unique(y_train))

    y_train = keras.utils.to_categorical(y_train, num_classes)
    y_test = keras.utils.to_categorical(y_test, num_classes)

    #initializing a sequential keras model
    model = Sequential()

    #adding layers to the model
    model.add(Flatten())
    model.add(Dense(128, activation='relu'))
    model.add(Dropout(0.5))
    model.add(Dense(num_classes, activation='softmax'))

    #compiling model with the categorical cross entropy loss function and the adam optimizer
    model.compile(loss=keras.losses.categorical_crossentropy,
              optimizer=keras.optimizers.Adam(),
              metrics=['accuracy'])

    x_train = x_train.astype('float32')
    x_test = x_test.astype('float32')
    x_train /= 255
    x_test /= 255

    if accOrTime == 0: #prioritizing time
        batch_size = 2**(int(math.sqrt(epochs))) #this formula for batch size was found to be the best at training a model to 97% accuracy relatively quickly
    elif accOrTime == 1: #prioritizing accuracy
        batch_size = 32 #this batch size was found to give a more consistent higher test accuracy


    if batch_size > x_train.shape[0]: batch_size = x_train.shape[0] #ensuring that batch size cannot be larger than the size of the dataset
    elif batch_size <= 0: batch_size = 1 #ensuring that batch size cannot be zero
    else: #if all else fails somehow
        print("Invalid prioritization choice.")
        return

    #not using this
    #earlyStop = keras.callbacks.EarlyStopping(monitor = 'accuracy', min_delta = 0.001, patience = 1, mode = 'max', baseline = desiredAccuracy) 

    print("Batch Size: ", batch_size)

    #training model
    model.fit(x_train, y_train,
              batch_size = batch_size,
              epochs = epochs,
              verbose = 1,
              validation_data = (x_test, y_test))
    #testing model
    score = model.evaluate(x_test, y_test, verbose = 0)
    print('Test loss: ', score[0])
    print('Test accuracy: ', score[1])
    