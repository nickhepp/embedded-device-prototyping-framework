using Ecs.Edpf.Devices.IO.Params;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Ecs.Edpf.Devices.IO.Cmds
{
    public class GetCommandParametersCommand : BaseDeviceCommand
    {

        public const string GetCommandParametersCommandMethodName = "getCommandParameters";

        public GetCommandParametersCommand() : base()
        {
        }

        public override string MethodName => GetCommandParametersCommandMethodName;
    }

 
}
