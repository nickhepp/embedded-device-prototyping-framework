using Ecs.Edpf.Devices;
using Ecs.Edpf.GUI.UI;
using System.Windows.Input;

namespace Ecs.Edpf.GUI.UI.ViewModels.Connections
{
    public interface IConnectionViewModel : IChildViewModel
    {

        IDeviceFactory GetDeviceFactory();

        IDeviceConnectionSettingsViewModel DeviceConnectionSettingsViewModel { get; }

        bool OpenButtonEnabled { get; }

        bool CloseButtonEnabled { get; }

        ICommand OpenCommand { get; }

        ICommand CloseCommand { get; }

        bool HasDevice { get; }

        bool Enabled { get; set; }

        string OpenFailedErrorMessage { get; }

    }
}
