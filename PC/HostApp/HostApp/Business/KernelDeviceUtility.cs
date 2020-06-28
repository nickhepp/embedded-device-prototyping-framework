using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.Business
{
    public static class KernelDeviceUtility
    {

        public static List<string> GetConnectedDevicePorts()
        {
            return System.IO.Ports.SerialPort.GetPortNames().ToList();
        }

        public static void InitializeDeviceConnection(IDeviceWithConnectionInfo device)
        {
            List<string> ports = GetConnectedDevicePorts();
            if (ports.Count == 0)
            {
                throw new Exception("No connected devices found.");
            }

            device.ConnectionInfo = new DeviceConnectionInfo
            {
                DeviceBaudRate = DeviceConnectionInfo.BaudRate.Baudrate115200,
                DevicePort = ports[0]
            };
        }

    }
}
