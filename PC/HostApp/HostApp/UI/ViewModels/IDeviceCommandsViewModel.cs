using HostApp.UI.ChildUI;
using System.ComponentModel;

namespace HostApp.UI.ViewModels
{
    public interface IDeviceCommandsViewModel : IChildViewModel
    {

        IDeviceCommandViewModel SelectedDeviceCommandViewModel { get; set; }

        BindingList<IDeviceCommandViewModel> DeviceCommandViewModels { get; } 

    }
}