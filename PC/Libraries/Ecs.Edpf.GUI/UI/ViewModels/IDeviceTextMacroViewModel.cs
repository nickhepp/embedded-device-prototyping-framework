using Ecs.Edpf.Devices.IO.Macros;
using Ecs.Edpf.GUI.ComponentModel;

namespace Ecs.Edpf.GUI.UI.ViewModels
{
    public interface IDeviceTextMacroViewModel : IViewModel
    {
        DeviceTextMacro DeviceTextMacro { get; set; }
        IRelayCommand OneShotCommand { get; }
        string RecordPauseButtonText { get; }
        IRelayCommand RecordPauseCommand { get; }
        string ResourceName { get; }
        IRelayCommand ToggleLoopCommand { get; }
    }
}