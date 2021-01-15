using Ecs.Edpf.Devices.Connections;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.Devices
{
    /// <summary>
    /// A device provider built out of device factories.
    /// </summary>
    public class CompositeDeviceProvider : IDeviceProvider
    {

        private IDeviceFactory _selectedDeviceFactory;
        private IEnumerable<IDeviceFactory> _deviceFactories;

        public CompositeDeviceProvider(IEnumerable<IDeviceFactory> deviceFactories)
        {
            _deviceFactories = deviceFactories;

            foreach (IDeviceFactory deviceFactory in _deviceFactories)
            {
                deviceFactory.DeviceCreated += DeviceFactoryDeviceCreated;
            }

        }


        private void DeviceFactoryDeviceCreated(object sender, EventArgs e)
        {
            _selectedDeviceFactory = (IDeviceFactory)sender;
            if (DeviceCreated != null)
            {
                DeviceCreated(this, new EventArgs());
            }
        }

        public IDevice Device => _selectedDeviceFactory.Device;

        public event EventHandler DeviceCreated;

   
    }
}
