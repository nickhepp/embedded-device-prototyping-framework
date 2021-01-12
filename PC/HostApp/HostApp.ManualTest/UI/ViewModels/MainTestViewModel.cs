using Ecs.Edpf.GUI.UI.ViewModels;
using Ecs.Edpf.GUI.UI.ViewModels.Connections;
using HostApp.ManualTest.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.ManualTest.UI.ViewModels
{
    public class MainTestViewModel
    {

        public ViewConfigurationFactory ViewConfigurationFactory { get; } = new ViewConfigurationFactory();


        public IConnectionViewModel ConnectionViewModel { get; }


        public IDeviceCommandsViewModel DeviceCommandsViewModel { get; }


        


        public MainTestViewModel()
        {

            ConnectionViewModel = new FakeConnectionViewModel();

            DeviceCommandsViewModel = new DeviceCommandsViewModel();
            DeviceCommandsViewModel.DeviceFactory = ConnectionViewModel.DeviceFactory;

        }



    }
}
