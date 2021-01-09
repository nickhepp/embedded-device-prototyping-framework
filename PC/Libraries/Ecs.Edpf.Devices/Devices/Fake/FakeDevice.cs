using Ecs.Edpf.Devices.Connections;
using Ecs.Edpf.Devices.Connections.Fake;
using Ecs.Edpf.Devices.IO.Cmds;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Ecs.Edpf.Devices
{
    public class FakeDevice : BaseKernelDevice
    {
        public FakeDevice(FakeConnectionInfo fakeConnectionInfo) : base(new FakeConnectionFactory(), fakeConnectionInfo)
        {
            // create the commands
            _echoCommand = new EchoCommand();
            _printDeviceInfoCommand = new PrintDeviceInfoCommand();
            _deviceCommands = new List<IDeviceCommand>(new IDeviceCommand[] { _printDeviceInfoCommand, _echoCommand });


        }

        private readonly EchoCommand _echoCommand;
        private readonly PrintDeviceInfoCommand _printDeviceInfoCommand;

        private readonly List<IDeviceCommand> _deviceCommands;

        protected override List<IDeviceCommand> GetDeviceCommands()
        {
            return _deviceCommands;
        }
    }
}
