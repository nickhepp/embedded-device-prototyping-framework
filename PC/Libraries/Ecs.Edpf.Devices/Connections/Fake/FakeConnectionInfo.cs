using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.Connections.Fake
{
    public class FakeConnectionInfo : IConnectionInfo
    {

        public string ConnectionName => "Fake";

        public string ConnectionType => "Fake";

        public FakeConnectionInfo()
        {
        }

    }
}
