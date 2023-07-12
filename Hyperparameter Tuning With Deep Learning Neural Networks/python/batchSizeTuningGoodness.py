import keras
from keras.datasets import mnist
from keras.datasets import cifar10
from keras.models import Sequential
from keras.layers import Dense, Dropout, Flatten
from keras.layers import Conv2D, MaxPooling2D
from keras import backend as K
import numpy as np
import math

def kerasBatchSizeTuner(epochs, accOrTime = 0, inputDataSet = mnist.load_data()):

    (x_train, y_train), (x_test, y_test) = inputDataSet
    print('x_train shape: ', x_train.shape)
    print(x_train.shape[0], 'training samples')
    print(x_test.shape[0], 'test samples')
    num_classes = len(np.unique(y_train))

    y_train = keras.utils.to_categorical(y_train, num_classes)
    y_test = keras.utils.to_categorical(y_test, num_classes)

    model = Sequential()

    model.add(Flatten())
    model.add(Dense(128, activation='relu'))
    model.add(Dropout(0.5))
    model.add(Dense(num_classes, activation='softmax'))

    model.compile(loss=keras.losses.categorical_crossentropy,
              optimizer=keras.optimizers.Adam(),
              metrics=['accuracy'])

    x_train = x_train.astype('float32')
    x_test = x_test.astype('float32')
    x_train /= 255
    x_test /= 255

    if accOrTime == 0: #prioritizing time
        batch_size = 2**(int(math.sqrt(epochs)))
    elif accOrTime == 1: #prioritizing accuracy
        batch_size = 32


    if batch_size > x_train.shape[0]: batch_size = x_train.shape[0]
    elif batch_size <= 0: batch_size = 1
    else:
        print("Invalid prioritization choice.")
        return

    #earlyStop = keras.callbacks.EarlyStopping(monitor = 'accuracy', min_delta = 0.001, patience = 1, mode = 'max', baseline = desiredAccuracy)

    print("Batch Size: ", batch_size)

    model.fit(x_train, y_train,
              batch_size = batch_size,
              epochs = epochs,
              verbose = 1,
              validation_data = (x_test, y_test))
    score = model.evaluate(x_test, y_test, verbose = 0)
    print('Test loss: ', score[0])
    print('Test accuracy: ', score[1])
    