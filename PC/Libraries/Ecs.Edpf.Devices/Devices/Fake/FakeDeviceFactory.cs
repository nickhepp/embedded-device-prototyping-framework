using Ecs.Edpf.Devices.Connections;
using Ecs.Edpf.Devices.Connections.Fake;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ecs.Edpf.Devices.Devices.Fake
{
    public class FakeDeviceFactory : IDeviceFactory
    {

        private FakeConnectionInfo _fakeConnectionInfo = new FakeConnectionInfo();
        public IConnectionInfo ConnectionInfo => _fakeConnectionInfo;


        public IDevice Device => _fakeDevice;

        public event EventHandler DeviceCreated;

        private FakeDevice _fakeDevice;
        public void CreateDevice()
        {
            _fakeDevice = new FakeDevice(_fakeConnectionInfo);
            if (DeviceCreated != null)
            {
                DeviceCreated(this, new EventArgs());
            }
        }

    }
}
