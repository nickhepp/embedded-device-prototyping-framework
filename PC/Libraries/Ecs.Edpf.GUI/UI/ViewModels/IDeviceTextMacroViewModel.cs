using Ecs.Edpf.Devices.IO.Macros;
using Ecs.Edpf.GUI.ComponentModel;

namespace Ecs.Edpf.GUI.UI.ViewModels
{
    public interface IDeviceTextMacroViewModel : IViewModel
    {
        /// <summary>
        /// Resource identifier for serialization.
        /// </summary>
        string ResourceName { get; }

        /// <summary>
        /// The macro text for the device.
        /// </summary>
        DeviceTextMacro DeviceTextMacro { get; set; }

        /// <summary>
        /// Command for a one shot of the macro text.
        /// </summary>
        IRelayCommand OneShotCommand { get; }

        /// <summary>
        /// Command for toggling the record and pause of the device text.
        /// </summary>
        IRelayCommand StopCommand { get; }

        /// <summary>
        /// Command for looping the macro text.
        /// </summary>
        IRelayCommand LoopCommand { get; }


    }
}