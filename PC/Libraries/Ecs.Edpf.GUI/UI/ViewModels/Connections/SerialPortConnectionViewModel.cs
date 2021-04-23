using Ecs.Edpf.Connections.Serial;
using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.Serial;
using Ecs.Edpf.GUI.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.Connections
{
    public class SerialPortConnectionViewModel : BaseConnectionViewModel
    {
        public override string Name => "Serial Port";


        public override Image ViewImage => throw new NotImplementedException();

        private SerialPortConnectionSettingsViewModel _serialPortConnectionSettingsViewModel;
        public override IDeviceConnectionSettingsViewModel DeviceConnectionSettingsViewModel => _serialPortConnectionSettingsViewModel;


        private SerialPortDeviceFactory _serialPortDeviceFactory = new SerialPortDeviceFactory();

        public SerialPortConnectionViewModel(IDeviceStateMachine deviceStateMachine) : base(deviceStateMachine)
        {
            _serialPortConnectionSettingsViewModel = new SerialPortConnectionSettingsViewModel((SerialPortConnectionInfo)_serialPortDeviceFactory.ConnectionInfo);
        }


        public override IDeviceFactory GetDeviceFactory()
        {
            return _serialPortDeviceFactory;
        }

    }
}
