using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.Devices.Fake;
using HostApp.UI.ChildUI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.UI.ViewModels.Connections
{
    public class FakeConnectionViewModel : BaseConnectionViewModel
    {
        public override Image ViewImage => throw new NotImplementedException();

        private FakeConnectionSettingsViewModel _fakeConnSettingsViewModel = new FakeConnectionSettingsViewModel();
        public override IDeviceConnectionSettingsViewModel DeviceConnectionSettingsViewModel => _fakeConnSettingsViewModel;

        //private FakeDeviceFactory _fakeDeviceFactory = new FakeDeviceFactory();
        //public override IDeviceFactory DeviceFactory { get => _fakeDeviceFactory; }

        public FakeConnectionViewModel()
        {

        }

        protected override IDeviceFactory GetDeviceFactory()
        {
            return new FakeDeviceFactory();
        }

        protected override void InternalDevicePropertyChanged(object sender, PropertyChangedEventArgs e)
        {

        }
    }
}
