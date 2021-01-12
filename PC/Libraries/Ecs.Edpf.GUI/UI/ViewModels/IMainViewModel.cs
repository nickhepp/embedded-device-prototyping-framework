using Ecs.Edpf.Devices;

namespace Ecs.Edpf.GUI.UI.ViewModels
{

    /// <summary>
    /// 
    /// </summary>
    public interface IMainViewModel
    {

        IDevice Device { get; }

        IDeviceFactory DeviceFactory { get; set; }

    }
}
