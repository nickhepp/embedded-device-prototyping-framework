using Ecs.Edpf.Devices.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.Devices
{
    public class DeviceProviderRegistry : IDeviceProviderRegistry
    {

        private List<IDeviceProviderListener> _deviceProviderListeners = new List<IDeviceProviderListener>();

        private IGlobalDeviceProvider _globalDeviceProvider;

        public DeviceProviderRegistry()
        {

        }

        public void RegisterDeviceProviderListener(IDeviceProviderListener deviceProviderListener)
        {
            _deviceProviderListeners.Add(deviceProviderListener);
        }

        public void RegisterGlobalDeviceProvider(IGlobalDeviceProvider globalDeviceProvider)
        {
            _globalDeviceProvider = globalDeviceProvider;
        }

        public void SynchronizeRegistry()
        {
            foreach (IDeviceProviderListener deviceProviderListener in _deviceProviderListeners)
            {
                deviceProviderListener.DeviceProvider = _globalDeviceProvider.GlobalDeviceProvider;
            }
        }
    }
}
