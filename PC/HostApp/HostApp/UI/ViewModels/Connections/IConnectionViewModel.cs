using HostApp.UI.ChildUI;
using System.Windows.Input;

namespace HostApp.UI.ViewModels
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
