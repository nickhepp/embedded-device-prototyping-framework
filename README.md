<img src='./Resources/Media/graphics/github_social_media_preview.png' style='display: block;
  margin-left: auto;
  margin-right: auto; height:299px
  /*width: 70%;*/'/>
  
<!--TODO: add gifs of host tools, link to host section below-->
# Embedded Device Prototyping Framework
Embedded Device Prototyping Framework (EDPF) is an embedded device rapid prototyping framework. A lot of time and effort can be spent simply establishing communication back and forth from a host PC to an embedded device uPC.  This framework establishes a base infrastructure that removes much of that plumbing work off the backs of developers/designers/hobbyists/etc.  This design has been used in numerous applications for both commercial and hobbyist purposes.  Please make use of it yourself if it can lighten your load, help you complete your task, and get to what matters in your device -- completing your design.


---
## Table of Contents (this doc)

* [Project Philosophy](#id-proj-philosophy)
* [Main Features](#id-main-features)
  * [Firmware for Rapid Prototyping](#id-firwmare-rapid)
  * [Host Machine Software for Rapid Prototyping](#id-software-rapid)

---
## Other Important ReadMe's

:link: [Getting Started](./getting_started.md)

:link: [Compatibility: Devices, Software, Firmware, Host Machine](./compatibility_devices_software_host_machine.md)

:link: [Host PC to Embedded Device IO](./host_pc_to_embedded_device_io.md)

:link: [How to create custom commands](./how_to_create_custom_commands.md)

---
<a id='id-proj-philosophy' />

## <img src='Resources/Media/graphics/book-open.svg' style="width:40px;"/> Project Philosophy
* Low code through reduced boilerplate - EDPF strives to reduce the code needed to create new functionality in both firmware and software
* Open source with examples of common functionality
* Easily extendable for custom applications

<a id='id-firwmare-rapid' />

---
<a id='id-main-features' />

## What are its main features?

The EDPF provides a powerful combination of [Embedded Firmware](#id-firwmare-rapid) & [Host Machine Software](#id-software-rapid) to empower its users to rapidly prototype new devices.



### <img src='Resources/Media/graphics/microchip_duotone.svg' style="width:35px;"/> Firmware for Rapid Prototyping

* <img src='Resources/Media/graphics/handshake.svg' style="width:30px;"/> Handshaking to establish a connection
* <img src='Resources/Media/graphics/connect-plugged.svg' style="width:30px;"/> Easy IO between the device and the host application
  * <img src='Resources/Media/graphics/function.svg' style="width:30px;"/> Commands and parameters make it easy for the device to accept data from the host application software and invoke firmware functionality 

<a id='id-software-rapid' />

### <img src='Resources/Media/graphics/laptop-code.svg' style="width:35px;"/> Host Machine Software for Rapid Prototyping

The software on the host machine configures itself to facilitate the functionality offered by the firmware.  When a connection is established from the host software to the firmware, the host software queries the firmware for the commands supported by the firmware.  The firmware responds by describing the commands, and the UI sets up custom controls to support each command.

<img src='Resources/Media/uml/ui_config.png' style='display: block;
  margin-left: auto;
  margin-right: auto; 
  /*width: 70%;*/'/>
  
<!--  
TODO: list UI tools with animations


----

# STUFF TO RELOCATE OR DELETE


* Easy IO 

* Host App (PC) Prototyping UI (.NET WinForms)
  * Easily extendable for custom functionality
  * Multiple interfaces to the embedded device
    * Terminal style command line interface
    * Common UI elements (buttons and numeric inputs) for executing multiple step communication tasks with the device
  * Built in logging

* Host Device library (.NET)
  
  * Provides core IO methods which handle establishing connection, sending instructions, receiving acknowledgements, and return data payloads 

* Command line driven communication protocol (protocol runs over RS232)
  * Easily extendable for custom functionality
  * Intuitive, human readable IO

* Firmware kernel (Arduino and other compatible devices)
  * Easily extendable for custom functionality
  * Handles routing command line IO to device subroutines along with parameters
  -->



