using Ecs.Edpf.Devices.Connections;

namespace Ecs.Edpf.Devices
{

    public interface IDeviceFactory : IDeviceProvider
    {

        IConnectionInfo ConnectionInfo { get; }

        void CreateDevice();



    }

}
