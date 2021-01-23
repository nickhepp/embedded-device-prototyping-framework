using Ecs.Edpf.Devices.Devices;

namespace HostApp.Devices
{
    public interface IDeviceProviderRegistry
    {
        void RegisterDeviceProviderListener(IDeviceProviderListener deviceProviderListener);

        void RegisterGlobalDeviceProvider(IGlobalDeviceProvider globalDeviceProvider);


        void SynchronizeRegistry();

    }
}