using Ecs.Edpf.Devices.IO.Params;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Ecs.Edpf.Devices.IO.Cmds
{
    public class PrintDeviceInfoCommand : BaseDeviceCommand
    {

        public const string PrintDeviceInfoCommandMethodName = "printDeviceInfo";

        public PrintDeviceInfoCommand() : base(new ReadOnlyCollection<IParameter>(new IParameter[] { }))
        {
        }

        public override string MethodName => PrintDeviceInfoCommandMethodName;
    }
}
