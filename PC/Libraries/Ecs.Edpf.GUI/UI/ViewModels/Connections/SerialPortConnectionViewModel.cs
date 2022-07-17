using Ecs.Edpf.Connections.Serial;
using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.ComponentModel;
using Ecs.Edpf.Devices.Connections.Serial;
using Ecs.Edpf.Devices.Serial;
using Ecs.Edpf.GUI.Settings;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Ecs.Edpf.GUI.UI.ViewModels.Connections
{
    public class SerialPortConnectionViewModel : BaseConnectionViewModel, ISettingsResource
    {
        public override string Name => "Serial Port";


        public override Image ViewImage => throw new NotImplementedException();

        private SerialPortConnectionSettingsViewModel _serialPortConnectionSettingsViewModel;
        public override IDeviceConnectionSettingsViewModel DeviceConnectionSettingsViewModel => _serialPortConnectionSettingsViewModel;

        public string ResourceName => nameof(SerialPortConnectionViewModel);

        private SerialPortDeviceFactory _serialPortDeviceFactory = new SerialPortDeviceFactory();

        public SerialPortConnectionViewModel(IDeviceStateMachine deviceStateMachine, ISerialPortFactory serialPortFactory) : base(deviceStateMachine)
        {
            _serialPortConnectionSettingsViewModel = new SerialPortConnectionSettingsViewModel((SerialPortConnectionInfo)_serialPortDeviceFactory.ConnectionInfo, serialPortFactory);
        }

        public override IDeviceFactory GetDeviceFactory()
        {
            return _serialPortDeviceFactory;
        }

        public Dictionary<string, string> GetSettings()
        {
            return _serialPortConnectionSettingsViewModel.GetSettings();
        }

        public void ApplySettings(Dictionary<string, string> settings)
        {
            _serialPortConnectionSettingsViewModel.ApplySettings(settings);
        }

        public void ApplyDefaultSettings()
        {
            _serialPortConnectionSettingsViewModel.ApplyDefaultSettings();
        }
    }
}
