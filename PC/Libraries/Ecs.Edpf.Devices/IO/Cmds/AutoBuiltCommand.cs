using Ecs.Edpf.Devices.IO.Params;
using System.Collections.ObjectModel;

namespace Ecs.Edpf.Devices.IO.Cmds
{

    public class AutoBuiltCommand : BaseDeviceCommand
    {

        private string _methodName;
        public override string MethodName => _methodName;

        public AutoBuiltCommand(string methodName, ReadOnlyCollection<IParameter> parameters) : base(parameters)
        {
            _methodName = methodName;
        }


    }
}
