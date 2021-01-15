﻿using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.Devices;
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

        public IDeviceProvider GlobalDeviceProvider => _compositeDeviceProvider;


        private CompositeDeviceProvider _compositeDeviceProvider;

        private List<IConnectionViewModel> _connectionViewModels = new List<IConnectionViewModel>
        {
            new FakeConnectionViewModel(),
            new SerialPortConnectionViewModel()
        };

        public Image ViewImage => throw new NotImplementedException();

        public string Name => "Connections";


        public List<IConnectionViewModel> ConnectionViewModels => _connectionViewModels;

        public ConnectionViewModelFactoryViewModel()
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
