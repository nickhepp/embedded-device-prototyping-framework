using Ecs.Edpf.GUI.UI;
using System.Windows.Input;

namespace Ecs.Edpf.GUI.UI.ViewModels
{
    public interface IConnectionViewModel : IChildViewModel
    {


        IDeviceConnectionSettingsViewModel DeviceConnectionSettingsViewModel { get; }

        bool OpenButtonEnabled { get; }

        bool CloseButtonEnabled { get; }

        ICommand OpenCommand { get; }

        ICommand CloseCommand { get; }

    }
}
