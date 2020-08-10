using Ecs.Edpf.Devices;

namespace HostApp.UI
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
