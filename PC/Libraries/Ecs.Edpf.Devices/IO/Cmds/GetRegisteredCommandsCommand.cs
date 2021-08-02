using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.IO.Cmds
{
    public class GetRegisteredCommandsCommand : BaseDeviceCommand
    {
        public const string GetRegisteredCommandsCommandMethodName = "get_registered_commands";

        public override string MethodName => GetRegisteredCommandsCommandMethodName;

        public GetRegisteredCommandsCommand() : base()
        {

        }

    }
}
