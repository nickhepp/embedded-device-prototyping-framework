# Device Commands Tool

## Insert Icon
## Insert GIF

Commands and parameters make it easy for the device to accept data from the host application software and invoke firmware functionality.  If you are familiar with software programming, think of Commands as a function and parameters as arguments to that function.  The EDPF starts off with first sending the parameters down to the device, and the device stores them until the host application sends the command.  The command instructs the device that it is time to invoke the functionality called out by the command name. Each command knows what parameters to expect because thats programed in the firmware as part of the command definition, and likewsie the host application knows what parameters the command requires b/c that information is discovered at the time of connection. To ease user interactions, the commands window populates UI controls that show all of the device commands along with all the associated parameters. The UI parameter controls are labeled by name and the inputs are type safe to steer the user as much as possible into providing valid values.  So this is very much like swagger for APIs in that the UI builds itself to know about the different functionality along with descriptive labeling of actions (endpoints for swagger, commands for edpf) and inputs to those actions (request parameters and objects for swagger and parameters for edpf). Once the inputs are filled in, a simple button click in the UI sends all the needed parameters and command to the device. The first steps in the command firmware are to retrieve the stored parameters by name and type. Afterwards comes your custom code to execute the custom device functionality.  Each command is allowed to perform whatever actions it needs, such as configuring device outputs, modifying device storage, and requesting the device to complete a sensor reading along with reporting the reading value back to the host application.

Now that I went over the specifics of commands let me to over the edpf operations at a higher level. In the edpf their is a master-slave relationship between the host application and the device, in which the host application is the master and the device is the slave. While the device can be programmed to perform any custom behavior you want in the firmware, the edpf requires the IO from the connection is controlled by the host application. The device is not allowed to send text to the host application unless the device has specifically requested information. So the normal flow of operation goes as such:
Step 1, If the command needs parametsr the Host application sends parameters
Step 2, Host application sends the command which requests the device to execute it
Step 3, the device performs the command, using any parameters that were needed for that command
Step 4, if the command is to return data to the host application, the device sends that information now
Step 5, the device tells the host application that it has completed the command by sending a sentinel token to the host application. And thus the device ceeds control back to the host application

After the last step the process is free to start again with step number 1.

Let's recap all of this. The device defines commands by thier names, and each command defines 0 or more parameters and each parameter has a name and type. The host application discovers these commands and configures controls that makes it easy for users to filled in parameters and execute the commands. If the command returns data, the host application reads that data.

So I hope this video has shown how the command infrastructure is a useful way for host application and device interaction. Commands and parameters are the backbone of edpf, and I hope they can be useful in your own projects. 

