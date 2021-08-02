using Ecs.Edpf.Devices.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.Devices.Test.Devices
{
    public class FakeDeviceProvider : IDeviceProvider, IDeviceFactory
    {

        private MockDevice _mockDevice;

        public FakeDeviceProvider()
        {

        }

        public MockDevice MockDevice => _mockDevice;

        public void InitDevice()
        {
            _mockDevice = new MockDevice();
            Device = _mockDevice.Object;
            if (DeviceCreated != null)
            {
                DeviceCreated(this, new EventArgs());
            }
        }

        public void CreateDevice()
        {
            InitDevice();
        }

        #region IDeviceProvider

        public IDevice Device { get; private set; }

        public IConnectionInfo ConnectionInfo => throw new NotImplementedException();

        public event EventHandler DeviceCreated;

        #endregion


    }

}
