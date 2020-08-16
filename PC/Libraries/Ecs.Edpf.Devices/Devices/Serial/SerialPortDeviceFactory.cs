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

        private SerialPortDevice _serialPortDevice;
        public IDevice Device => throw new NotImplementedException();

        public SerialPortDeviceFactory()
        {
        }

        public event EventHandler DeviceCreated;

        public void CreateDevice()
        {
            _serialPortDevice = new SerialPortDevice(_serialPortConnectionInfo);
            if (DeviceCreated != null)
            {
                DeviceCreated(this, new EventArgs());
            }
        }
    }
}
