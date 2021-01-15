using System;
using System.ComponentModel;

using Ecs.Edpf.Devices;

namespace Ecs.Edpf.GUI.UI.ViewModels
{
    /// <summary>
    /// A view model with a device.
    /// </summary>
    public interface IDeviceViewModel : IViewModel
    {

        IDeviceProvider DeviceProvider { get; set; }

        IDevice Device { get; set; }

        BindingList<string> DeviceOutputBuffer { get; }

        event EventHandler DeviceOutputBufferChanged;

    }
}
