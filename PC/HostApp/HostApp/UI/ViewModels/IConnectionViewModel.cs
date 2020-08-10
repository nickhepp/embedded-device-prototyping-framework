using System.Windows.Input;

namespace HostApp.UI.ViewModels
{
    public interface IConnectionViewModel : IViewModel
    {

        bool OpenButtonEnabled { get; }

        bool CloseButtonEnabled { get; }

        ICommand OpenCommand { get; }

        ICommand CloseCommand { get; }

    }
}
