using Ecs.Edpf.GUI.ComponentModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Ecs.Edpf.GUI.UI.ViewModels
{
    public interface IAddDeviceCommandsToMacroViewModel
    {
        BindingList<IGetDeviceCommandLinesViewModel> DeviceCommandViewModels { get; }
        IRelayCommand SelectedCommand { get; }
        bool SelectedCommandExecuteButtonEnabled { get; }
        string SelectedCommandExecuteButtonText { get; }
        IGetDeviceCommandLinesViewModel SelectedDeviceCommandViewModel { get; set; }
    }
}