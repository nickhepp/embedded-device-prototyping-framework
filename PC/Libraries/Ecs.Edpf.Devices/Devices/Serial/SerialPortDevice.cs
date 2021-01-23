using Ecs.Edpf.Connections.Serial;
using Ecs.Edpf.Devices.Connections;
using Ecs.Edpf.Devices.Connections.Serial;
using Ecs.Edpf.Devices.IO.Cmds;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Ecs.Edpf.Devices.Serial
{
    public class SerialPortDevice : BaseKernelDevice
    {

        public override bool SupportsEmbeddedCodeGeneration => true;

        public override int ParameterCount => 4;


        private List<IDeviceCommand> _commands;

        public SerialPortDevice(SerialPortConnectionInfo connectionInfo) : base(new SerialPortConnectionFactory(), connectionInfo)
        {
            _commands = DefaultCommandFactory.GetDeviceCommands();

        }

        protected override List<IDeviceCommand> GetDeviceCommands()
        {
            return _commands;
        }

    }
}
