using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Devices
{
    public static class KernelDeviceUtility
    {

        public static List<string> GetConnectedDevicePorts()
        {
            return System.IO.Ports.SerialPort.GetPortNames().ToList();
        }



    }
}
