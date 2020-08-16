using Ecs.Edpf.Devices.Connections;
using Ecs.Edpf.Devices.Connections.Fake;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices
{
    public class FakeDevice : BaseKernelDevice
    {
        public FakeDevice(FakeConnectionInfo fakeConnectionInfo) : base(new FakeConnectionFactory(), fakeConnectionInfo)
        {
        }




    }
}
