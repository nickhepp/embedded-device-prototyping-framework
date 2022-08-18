<a id='id-what-are-commands' />

# <img src='PC/HostApp/HostApp/Resources/function.png' style="width:60px;" /> What are commands?
The IO between the device and the host application is facilitated by commands.  Commands are the fundamental building block which allows the firmware and the host app software to communicate.  Commands allow for firmware functionality to the be described to the host application, and for the host application to pass data to the firmware and invoke the functionality.  Commands can be thought of almost like methods can be thought of in a programming language.  This is the reason the symbol for a command is a function symbol.

Commands are built with two basic building blocks:
 1. A set of 0 or more parameters to pass data to the command
     * Parameters support many simple familiar types: integer based types, a floating point type, and a boolean type
 2. A name for the command
     * Most often the same name of the method that will run in firmware, this is by convention but not mandatory

Parameters along with their associated values, and the command names are sent from the host application to the device. The device simply collects parameters and waits for a command to make use of the parameter data. 

To illustrate what this looks like in action, let's look at some actual text IO captured from a host app and device interaction.  This IO comes from the 'param_io' command which is an example command that shows off all the parameter types supported by EDPF and simply echos the values back when the command is invoked.

```na
>p[0]=45
>p[1]=-23
>p[2]=54321
>p[3]=-12345
>p[4]=444235
>p[5]=-444235
>p[6]=4.57
>p[7]=1
>cmd:param_io()
uint8_val=45
int8_val=-23
uint16_val=54321
int16_val=-12345
uint32_val=444235
int32_val=-444235
double_val=4.570
bool_val=TRUE
```
The lines starting with 

`>p[#]=...`

are the parameter lines.  So in this example the application is sending down 8 values to the device.  The host application knew this command supports 8 values because the host application had previously queried the firmware for its supported functionality which includes the device's command specifics.  In this instance, p[0] through p[5] are integer based types (uint8, int8, uint16, int16, uint32, & int32), p[6] is a floating point type, and p[7] is a boolean type.  Parameters are sent individually from the host application to the firmware, and remain in device memory until the command is invoked.  This line invokes the command:

`>cmd:param_io()`

TODO: add a link to 'host_pc_to_embedded_device_io.md'

<a id='id-create-custom-commands' />

# How to create custom commands

There are 3 code snippets needed to create custom commands.  We will use the 'param_io_command' command provided in the firmware as an example since it contains every supported parameter type.

1) Define the command variable in a global area.  'KernelDevice.cpp' is a good spot. 
```c
Command paramIOCommand;
```

2) Initialize the command with a name which the host software can use to invoke the command, a callback pointer to be executed when the host UI executes the command by name, and (optional) parameters so the host UI can pass data to the command.  Make these calls in the 'KernelDevice::init()' method.
```c
void KernelDevice::init()
{
    // initialize the command by giving it a name for the host
    // application and assigning the callback method
    paramIOCommand.initCommand("param_io_command", cmd_params, param_io_command);
    // add parameters to the command
    paramIOCommand.addUInt8Parameter("my_uint8_param");
    // more commands...
    // register the command so the processing loop can look for matches by name
    registerCommand(&paramIOCommand);
}
```


3) Define the callback method with the correct method signature.  Inside the method the parameters can be retrieved by name. 
```c
void param_io_command(Command* cmd)
{
    uint8_t uint8_val;
    if (cmd->getUInt8Parameter("my_uint8_param", &uint8_val))
    {
        // ... do stuff
    }
}
```




