using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecs.Edpf.Devices.Connections.Serial
{
    public class SerialPortFactory : ISerialPortFactory
    {
        public List<string> GetSerialPortNames()
        {
            List<string> portNames = System.IO.Ports.SerialPort.GetPortNames().ToList();
            return portNames;
        }
    }
}
