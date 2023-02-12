<img src='./Resources/Media/graphics/github_social_media_preview.png' style='display: block;
  margin-left: auto;
  margin-right: auto; height:299px
  /*width: 70%;*/'/>
  
<!--TODO: add gifs of host tools, link to host section below-->
# Embedded Device Prototyping Framework
##  Less boilerplate coding, more productive prototyping, faster project completion

Embedded Device Prototyping Framework (EDPF) is an embedded device rapid prototyping framework. A lot of time and effort can be spent simply establishing communication back and forth from a host PC to an embedded device uPC.  This framework establishes a base infrastructure that removes much of that plumbing work off the backs of developers/designers/hobbyists/etc.  This design has been used in numerous applications for both commercial and hobbyist purposes.  Please make use of it yourself if it can lighten your load, help you complete your task, and get to what matters in your device -- completing your design.

## Video Overview
If you would like to watch a video overview of this project, 
<a href="https://www.youtube.com/watch?v=P5Ys7X5QqWg?t=519">please follow this link
<img src='Resources/Media/graphics/overview-video.jpg' style='display: block;
  margin-left: auto;
  margin-right: auto; width:400px
  /*width: 70%;*/'/></a>

Slides for the [presentation can be found here](https://electroniccomputing.com/slides#edpf_overview).

---
## Table of Contents (this doc)
* [Project Philosophy](#id-proj-philosophy)
* [Main Features](#id-main-features)
  * [Firmware for Rapid Prototyping](#id-firwmare-rapid)
  * [Host Machine Software for Rapid Prototyping](#id-software-rapid)
* [Host Machine Software Tools](#id-hostapp-tools)
   * [Charting](#id-tool-charting)
   * [Console](#id-tool-console)
   * [Device Commands](#id-tool-devicecommands)
   * [Connections](#id-tool-connections)
   * [Macros](#id-tool-macros)
   * [Logging](#id-tool-logging)

---
## Other Important ReadMe's (not this doc)

:link: [Getting Started](./getting_started.md)

:link: [Compatibility: Devices, Software, Firmware, Host Machine](./compatibility_devices_software_host_machine.md)

:link: [Host PC to Embedded Device IO](./host_pc_to_embedded_device_io.md)

:link: [What are Commands?](./device_commands.md#id-what-are-commands)

:link: [How to create custom commands](./device_commands.md#id-create-custom-commands)



---
<a id='id-proj-philosophy'></a>

## <img src='Resources/Media/graphics/book-open.svg' style="width:40px;"/> Project Philosophy
* Low code through reduced boilerplate - EDPF strives to reduce the code needed to create new functionality in both firmware and software
* Open source with examples of common functionality
* Easily extendable for custom applications

<a id='id-firwmare-rapid'></a>

---
<a id='id-main-features'></a>

## What are its main features?

The EDPF provides a powerful combination of [Embedded Firmware](#id-firwmare-rapid) & [Host Machine Software](#id-software-rapid) to empower its users to rapidly prototype new devices.



### <img src='Resources/Media/graphics/microchip_duotone.svg' style="width:35px;"/> Firmware for Rapid Prototyping

* <img src='Resources/Media/graphics/handshake.svg' style="width:30px;"/> Handshaking to establish a connection
* <img src='Resources/Media/graphics/connect-plugged.svg' style="width:30px;"/> Easy IO between the device and the host application
* <img src='Resources/Media/graphics/function.svg' style="width:30px;"/> Commands and parameters make it easy for the device to accept data from the host application software and invoke firmware functionality 

<a id='id-software-rapid'></a>

### <img src='Resources/Media/graphics/laptop-code.svg' style="width:35px;"/> Host Machine Software for Rapid Prototyping

The software on the host machine configures itself to facilitate the functionality offered by the firmware.  When a connection is established from the host software to the firmware, the host software queries the firmware for the commands supported by the firmware.  The firmware responds by describing the commands, and the UI sets up custom controls to support each command.

<img src='Resources/Media/uml/ui_config.png' style='display: block;
  margin-left: auto;
  margin-right: auto; 
  /*width: 70%;*/'/>
  
---

<a id='id-hostapp-tools'></a>  

## Host Machine Software Tools

The host machine software has a number tools that can be used for operating with the device.  Let's do a run down on the tools.

<a id='id-tool-charting'></a>

### <img src='PC/HostApp/HostApp/Resources/charts.png' style="width:30px;"/> Charting Tool
Charts the flow of device data. Read more about the [Charting Tool](./tool-charting.md).

<a id='id-tool-console'></a>

### <img src='PC/HostApp/HostApp/Resources/cmd_icon.png' style="width:30px;" />  Console Tool
The EDPF software makes the device act like a server that provides a terminal interface.  Read more about the [Console Tool](./tool-console.md).
  
<a id='id-tool-devicecommands'></a>

### <img src='PC/HostApp/HostApp/Resources/function.png' style="width:30px;" /> Device Commands Tool
Send data and execute instructions, much like a software program calls methods. The host application queries the attached device to learn of its capabilities and automatically creates UI elements to easily interact with device functionality. Read more about the [Device Commands Tool](./tool-devicecommands.md).

<a id='id-tool-connections'></a>

### <img src='PC/HostApp/HostApp/Resources/baseline_cable_black.png' style="width:30px;"/> Connections Tool
Establish connections to devices over multiple connection options.  Read more about the [Connections Tool](./tool-connections.md).
 
<a id='id-tool-macros'></a>

### <img src='PC/HostApp/HostApp/Resources/repeat.png' style="width:30px;"/> Macros Tool
Send multiple operations to the device with optional time delays in between. Supports both oneshot and looping macros on a timer. Read more about the [Macros Tool](./tool-macros.md).

<a id='id-tool-logging'></a>

### <img src='PC/HostApp/HostApp/Resources/clipboard-list.png' style="width:30px;"/> Logging Tool
Interact with the device as if it were a server that provides a terminal interface. The device responds with easy to understand text in a 'human readable' format. Read more about the [Logging Tool](./tool-logging.md).