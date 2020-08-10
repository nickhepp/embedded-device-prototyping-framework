using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.Connections.Fake
{
    public class FakeConnectionFactory : IConnectionFactory
    {
        public IConnection GetConnection()
        {
            return new FakeConnection();
        }
    }
}
