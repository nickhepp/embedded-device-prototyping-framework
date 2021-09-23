# Compatibility: Devices, Software, Firmware, Host Machine

Currently EDPF focuses on Arduino devices, RS232 (default Arduino USB IO mechanism), and Microsoft's .NET libraries.

## Table of Contents
[Devices](#id-devices)

[Software and Firmware](#id-software-firmware)

[Host Machine](#id-host-machine)



---
<a id='id-microcontrollers'></a>
## <img id="id-devices" src="Resources/Media/graphics/microchip_duotone.svg" style="width:40px;"/> Compatible Devices
Here are the boards and devices that have been verified to work with the EDPF. 
#### <img id="id-devices" src="Resources/Media/graphics/Arduino_Logo.svg" style="width:40px;"/> Arduino

:heavy_check_mark: Arduino Uno

:heavy_check_mark: Arduino Mega 2560 Rev3

:question: All other Arduino devices

#### Other Devices
:question: All other devices


---
<a id='id-software-firmware'></a>
### <img src="Resources/Media/graphics/code.svg" alt="drawing" style="width:40px;"/> Software and Firmware

The Arduino firmware is written in C and C++.  The software has been compiled and uploaded with the following Arduino development environments:
* [Arduino IDE](https://www.arduino.cc/en/software)
* [Visual Micro: Arduino IDE for Visual Studio (Visual Studio plugin)](https://www.visualmicro.com/)

The host application software is written in C# (.NET Framework V4.8).  The software can be compiled and executed with the following development environments:
* [Visual Studio 2019 (Community Edition or higher)](https://visualstudio.microsoft.com/downloads/)
* Visual Studio Code (not tested)

#### <img src="Resources/Media/graphics/handshake.svg" alt="drawing" style="width:40px;"/> Software and Firmware - Communication

Communication between the device and the host application can be established with the following data interfaces:
* RS232

---
<a id='id-host-machine'></a>
### <img src="Resources/Media/graphics/computer-classic_duotone.svg" style="width:40px;"/> Compatible Host Machines

The .NET Framework runs on recent Windows OS versions:
* Windows Server 2016, 2019, and beyond
* Windows 7 and 10


