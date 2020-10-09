using Ecs.Edpf.Devices.IO.Params;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Ecs.Edpf.Devices.IO.Cmds
{
    public class PrintDeviceInfoCommand : BaseDeviceCommand
    {

        // no params so empty list
        private readonly ReadOnlyCollection<IParameter> _parameters = new ReadOnlyCollection<IParameter>(new List<IParameter>());
        public override ReadOnlyCollection<IParameter> Parameters => _parameters;

        public override string MethodName => "printDeviceInfo";
    }
}
