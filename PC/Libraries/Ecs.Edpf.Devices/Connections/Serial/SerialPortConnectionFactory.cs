using Ecs.Edpf.Connections;
using Ecs.Edpf.Devices.Connections.Serial;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.Connections.Serial
{
    public class SerialPortConnectionFactory : IConnectionFactory
    {

        public IConnection GetConnection()
        {
            return new SerialPortConnection();
        }

    }
}
