using Ecs.Edpf.Devices.IO.Params;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Ecs.Edpf.Devices.IO.Cmds
{
    public class EchoParametersCommand : BaseDeviceCommand
    {
        public EchoParametersCommand() : base(new ReadOnlyCollection<IParameter>(new List<IParameter>()))
        {
        }

        public override string MethodName => "echoParameters";
    }
}
