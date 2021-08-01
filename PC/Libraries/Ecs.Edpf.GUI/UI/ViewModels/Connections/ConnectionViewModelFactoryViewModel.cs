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

        private ICompositeDeviceProvider _compositeDeviceProvider;
        public IDeviceProvider GlobalDeviceProvider => _compositeDeviceProvider;


        public IEnumerable<IConnectionViewModel> ConnectionViewModels { get; private set; }



        public Image ViewImage => throw new NotImplementedException();

        public string Name => "Connections";



        public ConnectionViewModelFactoryViewModel(IDeviceStateMachine deviceStateMachine, 
            ICompositeDeviceProvider compositeDeviceProvider,
            IEnumerable<IConnectionViewModel> connectionViewModels) : base(deviceStateMachine)
        {
            _compositeDeviceProvider = compositeDeviceProvider;
            ConnectionViewModels = connectionViewModels;
            //_compositeDeviceProvider.DeviceCreated += CompositeDeviceProvider_DeviceCreated;

        }

        //private void CompositeDeviceProvider_DeviceCreated(object sender, EventArgs e)
        //{
        //    DeviceSta
        //}

        protected override void OnDeviceStateChanged()
        {
            if (DeviceState == DeviceState.OpenedDevice)
            {
                foreach (IConnectionViewModel connViewMdl in ConnectionViewModels)
                {
                    connViewMdl.Enabled = connViewMdl.DeviceProvider.Device != null;
                    connViewMdl.Enabled = connViewMdl.HasDevice;

                }
            }
            else if (DeviceState == DeviceState.NoDevice)
            {
                foreach (IConnectionViewModel connViewMdl in ConnectionViewModels)
                {
                    connViewMdl.Enabled = true;
                }
            }
        }

 
    }
}
