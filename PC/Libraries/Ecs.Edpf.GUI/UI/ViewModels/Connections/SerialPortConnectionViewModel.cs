using Ecs.Edpf.Connections.Serial;
using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.ComponentModel;
using Ecs.Edpf.Devices.Connections.Serial;
using Ecs.Edpf.Devices.Serial;
using System;
using System.Drawing;

namespace Ecs.Edpf.GUI.UI.ViewModels.Connections
{
    public class SerialPortConnectionViewModel : BaseConnectionViewModel
    {
        public override string Name => "Serial Port";


        public override Image ViewImage => throw new NotImplementedException();

        private SerialPortConnectionSettingsViewModel _serialPortConnectionSettingsViewModel;
        public override IDeviceConnectionSettingsViewModel DeviceConnectionSettingsViewModel => _serialPortConnectionSettingsViewModel;


        private SerialPortDeviceFactory _serialPortDeviceFactory = new SerialPortDeviceFactory();

        public SerialPortConnectionViewModel(IDeviceStateMachine deviceStateMachine, ISerialPortFactory serialPortFactory) : base(deviceStateMachine)
        {
            _serialPortConnectionSettingsViewModel = new SerialPortConnectionSettingsViewModel((SerialPortConnectionInfo)_serialPortDeviceFactory.ConnectionInfo, serialPortFactory);
        }

        public override IDeviceFactory GetDeviceFactory()
        {
            return _serialPortDeviceFactory;
        }

    }
}
