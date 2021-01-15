using Ecs.Edpf.Devices.IO.Params;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Ecs.Edpf.Devices.IO.Cmds
{
    public class GetDeviceInfoCommand : BaseDeviceCommand
    {

        public const string GetDeviceInfoCommandMethodName = "getDeviceInfo";

        public GetDeviceInfoCommand() : base()
        {
        }

        public override string MethodName => GetDeviceInfoCommandMethodName;
    }
}
