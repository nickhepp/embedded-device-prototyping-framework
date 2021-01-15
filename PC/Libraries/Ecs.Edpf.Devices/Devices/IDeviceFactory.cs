using Ecs.Edpf.Devices.Connections;

namespace Ecs.Edpf.Devices
{

    public interface IDeviceFactory : IDeviceProvider
    {

        IConnectionInfo ConnectionInfo { get; }

        //IDevice Device { get; }

        //event EventHandler DeviceCreated;

        void CreateDevice();



    }

}
