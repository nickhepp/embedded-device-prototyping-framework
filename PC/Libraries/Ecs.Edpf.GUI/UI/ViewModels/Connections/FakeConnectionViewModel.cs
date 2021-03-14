using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.Devices.Fake;
using Ecs.Edpf.GUI.ComponentModel;
using Ecs.Edpf.GUI.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        protected override void InternalDevicePropertyChanged(object sender, PropertyChangedEventArgs e)
        {

        }
    }
}
