using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.Devices;
using Ecs.Edpf.GUI.ComponentModel;
using Ecs.Edpf.GUI.UI.ViewModels.Connections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.Connections
{
    public class ConnectionViewModelFactoryViewModel : BaseDeviceViewModel, IConnectionViewModelFactoryViewModel
    {

        private CompositeDeviceProvider _compositeDeviceProvider;
        public IDeviceProvider GlobalDeviceProvider => _compositeDeviceProvider;


        private List<IConnectionViewModel> _connectionViewModels = new List<IConnectionViewModel>
        {
            new SerialPortConnectionViewModel(new DeviceStateMachine()),
            new FakeConnectionViewModel(new DeviceStateMachine()),
        };

        public Image ViewImage => throw new NotImplementedException();

        public string Name => "Connections";


        public List<IConnectionViewModel> ConnectionViewModels => _connectionViewModels;

        public ConnectionViewModelFactoryViewModel(IDeviceStateMachine deviceStateMachine) : base(deviceStateMachine)
        {
            _compositeDeviceProvider = new CompositeDeviceProvider(_connectionViewModels.Select(connVwMdl => connVwMdl.GetDeviceFactory()));
        }


        protected override void InternalDevicePropertyChanged(object sender, PropertyChangedEventArgs e)
        {

        }

        protected override void OnDeviceChanged(IDevice device)
        {

        }
    }
}
