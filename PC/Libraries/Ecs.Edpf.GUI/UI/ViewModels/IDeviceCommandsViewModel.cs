using Ecs.Edpf.GUI.UI;
using System.ComponentModel;
using System.Windows.Input;

namespace Ecs.Edpf.GUI.UI.ViewModels
{
    public interface IDeviceCommandsViewModel : IChildViewModel
    {

        IDeviceCommandViewModel SelectedDeviceCommandViewModel { get; set; }

        BindingList<IDeviceCommandViewModel> DeviceCommandViewModels { get; }


        string SelectedCommandExecuteButtonText { get; }

        bool SelectedCommandExecuteButtonEnabled { get; }


        ICommand SelectedCommand
        {
            get;
        }



    }
}