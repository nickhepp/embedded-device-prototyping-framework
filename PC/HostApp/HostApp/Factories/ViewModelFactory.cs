using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecs.Edpf.Devices.Serial;
using Ecs.Edpf.GUI.UI.ViewModels;
using HostApp;
using HostApp.UI;
using HostApp.UI.ViewModels;
using HostApp.UI.Views;

namespace HostApp.UI
{
    public static class ViewModelFactory
    {

        public static IMainViewModel GetMainViewModel()
        {
            IMainViewModel mainViewModel = null; // new SimpleMainViewModel();
            mainViewModel.DeviceFactory = new SerialPortDeviceFactory();



            return mainViewModel;
        }



    }
}
