using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.ComponentModel;
using Ecs.Edpf.Devices.Devices;
using System;
using System.Collections.Generic;
using System.Drawing;

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
        }

        protected override void OnDeviceStateChanged()
        {
            if (DeviceState == DeviceState.OpenedDevice)
            {
                foreach (IConnectionViewModel connViewMdl in ConnectionViewModels)
                {
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
