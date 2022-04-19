using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.ComponentModel;
using Ecs.Edpf.Devices.Devices.Fake;
using System;
using System.Drawing;

namespace Ecs.Edpf.GUI.UI.ViewModels.Connections
{
    public class FakeConnectionViewModel : BaseConnectionViewModel
    {

        public override string Name => "Fake Connection";

        public override Image ViewImage => throw new NotImplementedException();

        private FakeConnectionSettingsViewModel _fakeConnSettingsViewModel = new FakeConnectionSettingsViewModel();
        public override IDeviceConnectionSettingsViewModel DeviceConnectionSettingsViewModel => _fakeConnSettingsViewModel;


        public FakeConnectionViewModel(IDeviceStateMachine deviceStateMachine) : base(deviceStateMachine)
        {

        }

        public override IDeviceFactory GetDeviceFactory()
        {
            return new FakeDeviceFactory();
        }
     
    }
}
