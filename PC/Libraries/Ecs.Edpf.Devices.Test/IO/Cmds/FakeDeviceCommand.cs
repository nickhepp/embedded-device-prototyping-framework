using Ecs.Edpf.Devices.IO.Cmds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Ecs.Edpf.Devices.IO.Params;

namespace Ecs.Edpf.Devices.Test.IO.Cmds
{
    internal class FakeDeviceCommand : BaseDeviceCommand
    {
        public override string MethodName => nameof(FakeDeviceCommand);
    
        public FakeDeviceCommand() : base(new ReadOnlyCollection<IParameter>(new IParameter[] 
            { 
                new StringParameter("val1", 0, "val1"),
                new StringParameter("val2", 1, "val2")
            }))
        {

        }

    }
}
