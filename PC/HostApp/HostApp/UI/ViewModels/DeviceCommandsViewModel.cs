using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.IO.Cmds;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.UI.ViewModels
{
    public class DeviceCommandsViewModel : BaseDeviceViewModel, IDeviceCommandsViewModel
    {


        public BindingList<IDeviceCommandViewModel> DeviceCommandViewModels { get; } = new BindingList<IDeviceCommandViewModel>();

        public Image ViewImage => throw new NotImplementedException();

        public string Name => "Device Commands";

        public IDeviceCommandViewModel SelectedDeviceCommandViewModel { get; set; }

        protected override void InternalDevicePropertyChanged(object sender, PropertyChangedEventArgs e)
        {

        }

        protected override void OnDeviceChanged(IDevice device)
        {
            // grab all the device commands
            DeviceCommandViewModels.Clear();

            if (device != null)
            {
                foreach (IDeviceCommand deviceCommand in device.DeviceCommands)
                {
                    DeviceCommandViewModel deviceCommandVwMdl = new DeviceCommandViewModel(deviceCommand);
                    if (SelectedDeviceCommandViewModel == null)
                    {
                        SelectedDeviceCommandViewModel = deviceCommandVwMdl;
                    }
                    DeviceCommandViewModels.Add(deviceCommandVwMdl);
                }
            }

            DeviceCommandViewModels.ResetBindings();
        }





    }
}
