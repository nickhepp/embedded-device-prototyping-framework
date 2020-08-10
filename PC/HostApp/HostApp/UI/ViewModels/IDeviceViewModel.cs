using System.ComponentModel;

using Ecs.Edpf.Devices;

namespace HostApp.UI.ViewModels
{
    /// <summary>
    /// A view model with a device.
    /// </summary>
    public interface IDeviceViewModel
    {


        IDevice Device { get; set; }


        BindingList<string> DeviceOutputBuffer { get; }


    }
}
