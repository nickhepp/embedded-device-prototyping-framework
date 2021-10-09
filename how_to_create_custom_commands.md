
# How to create custom commands

There are 3 code snippets needed to create custom commands.  We will use the 'param_io_command' command provided in the firmware as an example since it contains every supported parameter type.

1) Define the command in a global area.  'KernelDevice.cpp' is a good spot. 
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




