using Ecs.Edpf.Devices.IO.Params;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Ecs.Edpf.Devices.IO.Cmds
{
    public class EchoCommand : BaseDeviceCommand
    {
      
        public EchoCommand() :  base(new ReadOnlyCollection<IParameter>(new IParameter[] { new StringParameter("echoVal", 0, "hello") }))
        {
        }

        public override string MethodName => "echo";


    }
}
