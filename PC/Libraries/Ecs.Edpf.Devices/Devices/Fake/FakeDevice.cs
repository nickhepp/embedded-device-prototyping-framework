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

        public const int FakeDeviceParameterCount = 5;

        public override int ParameterCount => FakeDeviceParameterCount;


        public FakeDevice(FakeConnectionInfo fakeConnectionInfo) : base(new FakeConnectionFactory(), fakeConnectionInfo)
        {
            // create the commands
            _getDeviceInfoCommand = new GetDeviceInfoCommand();
            _getRegisteredCommandsCommand = new GetRegisteredCommandsCommand();
            _getCommandParametersCommand = new GetCommandParametersCommand();
            _deviceCommands = new List<IDeviceCommand>(new IDeviceCommand[] 
                { 
                    _getDeviceInfoCommand,
                    _getRegisteredCommandsCommand,
                    _getCommandParametersCommand
                });
        }


        private readonly GetDeviceInfoCommand _getDeviceInfoCommand;
        private readonly GetRegisteredCommandsCommand _getRegisteredCommandsCommand;
        private readonly GetCommandParametersCommand _getCommandParametersCommand;

        private readonly List<IDeviceCommand> _deviceCommands;


        protected override List<IDeviceCommand> GetDeviceCommands()
        {
            return _deviceCommands;
        }
    }
}
