using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.IO.Cmds
{
    public static class DefaultCommandFactory
    {

        public static List<IDeviceCommand> GetDeviceCommands()
        {
            List<IDeviceCommand> deviceCommands = new List<IDeviceCommand>
            {
                new GetDeviceInfoCommand(),
                new GetRegisteredCommandsCommand(),
                new GetCommandParametersCommand()
            };

            return deviceCommands;


        }

    }
}
