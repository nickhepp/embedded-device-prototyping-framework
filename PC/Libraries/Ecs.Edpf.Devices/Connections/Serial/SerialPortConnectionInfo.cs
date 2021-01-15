using Ecs.Edpf.Devices.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.Connections.Serial
{
    public class SerialPortConnectionInfo : IConnectionInfo
    {
        public enum BaudRate
        {
            Baudrate75	= 75,
            Baudrate150	= 150,
            Baudrate300	= 300,
            Baudrate600	= 600,
            Baudrate1200 = 1200,
            Baudrate2400 = 2400,
            Baudrate4800 = 4800,
            Baudrate9600 = 9600,
            Baudrate19200 =	19200,
            Baudrate38400 =	38400,
            Baudrate57600 =	57600,
            Baudrate115200 = 115200,
            Baudrate230400	= 230400
        }

        public BaudRate DeviceBaudRate { get; set; } = BaudRate.Baudrate115200;

        public string DevicePort { get; set; } = System.IO.Ports.SerialPort.GetPortNames().FirstOrDefault();

        public override string ToString()
        {
            return $"{nameof(DeviceBaudRate)}: {DeviceBaudRate}, {nameof(DevicePort)}: {DevicePort}";
        }

    }
}
