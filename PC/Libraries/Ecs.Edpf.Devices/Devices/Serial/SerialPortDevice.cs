using Ecs.Edpf.Connections.Serial;
using Ecs.Edpf.Devices.Connections;
using Ecs.Edpf.Devices.Connections.Serial;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.Serial
{
    public class SerialPortDevice : BaseKernelDevice
    {
        public SerialPortDevice(SerialPortConnectionInfo connectionInfo) : base(new SerialPortConnectionFactory(), connectionInfo)
        {
        }
    }
}
