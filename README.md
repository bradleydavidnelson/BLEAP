# BLEAP
>Bluetooth Low-Energy Access Point. Software for interfacing with BLE113 strain gauge implants.

---
## Table of Contents
1. [Getting Started](#getting-started)
1. [Usage](#usage)
1. [Troubleshooting](#troubleshooting)
1. [Contributors](#contributors)
1. [License](#license)

## Getting Started
The executable may be found in the install directory at `BLEAP\bin\Debug\BLEAP.exe`. The version in `BLEAP\bin\Release\BLEAP.exe` does not work correctly.

This project contains several files:
- `BGAPI.cs` contains code to interface with BlueGiga events.
- `BGLib.cs` is the library provided by BlueGiga. This should not be modified.
- `BTDevice.cs` defines a data structure to contain BLE113 device data.
- `Calibrate.cs` contains code for the calibration window.
- `CalibratePH.cs` contains code to calibrate the pH sensor. It is depreciated and replaced with `Calibrate.cs`.
- `CalibrateStrain.cs` contains code to calibrate the strain sensor. It is depreciated and replaced with `Calibrate.cs`.
- `COM.cs` contains code to interface with the USB port.
- `DataTable.cs` is depreciated.
- `Main.cs` contains code for the main interface.

---
## Usage

#### Selecting the USB port
Available COM ports are listed in the drop-down box labeled "COM Port". Select the option titled "Bluegiga Bluetooth Low Energy". If this does not appear, insert the BLED112 dongle and press "Refresh". Once the correct device is selected, press "Attach". This will automatically initiate searching for our Bluetooth devices.
>Known issue: The software will crash on start-up if no USB device is connected.

#### Connecting to a sensor
Devices with the correct GATT configuration will appear in the "Discovered Devices" list. To connect to a device, simply press the "Connect" button next to the desired device. To disconnect, press the "Disconnect" button that appears in its place.

#### Waking the sensor
A few seconds after connecting, the device will appear in a table in the window. The last column of the table will contain the wake/sleep button. To change the sensor to wake mode, press the "Wake" button. Once awake, the sensor will automatically transmit data. To change the sensor to sleep mode, press the "Sleep" button.

#### Calibrating the sensor
The rheostat on the sensor may be adjusted when connected and in wake mode. When in wake mode, go to Sensor > Calibrate... in the menu. Values may be adjusted from 0 to 1023, and updated by pressing "Enter".

#### Changing the save location
The automatic save file location may be changed in File > Save As.... Files are named using the sensor name followed by a unique time-and-date identifier.

---
## Troubleshooting
###### Software crashes on startup
Make sure the BLED112 dongle is connected. Having no USB devices attached causes the software to crash.

###### The target device is not appearing
Close the software. Remove and replace the BLED112 dongle and try again. This will close all communications that may be in an error state. Disconnecting from all devices and pressing the "Detach" button before closing the software will reduce the risk of this error occuring.

###### Devices are dying too quickly
Be sure to return the device to sleep mode and disconnect after data collection.

###### The graph does not work
Graphing of data is not currently supported.

---
## Contributors
- Brad Nelson (https://github.com/bradleydavidnelson)

---
## License
[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)
