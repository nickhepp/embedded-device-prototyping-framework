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