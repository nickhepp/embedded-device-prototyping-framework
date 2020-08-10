using Ecs.Edpf.Connections.Serial;
using Ecs.Edpf.Devices.Connections;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.Serial
{
    public class SerialPortDeviceFactory : IDeviceFactory
    {


        private SerialPortConnectionInfo _serialPortConnectionInfo;
        public IConnectionInfo ConnectionInfo => _serialPortConnectionInfo;

        public SerialPortDeviceFactory()
        {
        }



        public IDevice GetDevice()
        {
            return new SerialPortDevice(_serialPortConnectionInfo);


        }


    }
}
