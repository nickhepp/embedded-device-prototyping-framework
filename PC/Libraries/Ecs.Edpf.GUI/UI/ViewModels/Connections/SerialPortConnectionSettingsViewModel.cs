using Ecs.Edpf.Connections.Serial;
using Ecs.Edpf.Devices;
using Ecs.Edpf.GUI.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels
{
    public class SerialPortConnectionSettingsViewModel : DeviceConnectionSettingsViewModel
    {
        [TypeConverter(typeof(ComPortOptionsPropertyConverter))]
        public string ComPort
        {
            get
            {
                return _serialPortConnectionInfo.DevicePort;
            }
            set
            {
                _serialPortConnectionInfo.DevicePort = value;
            }
        }

        private SerialPortConnectionInfo _serialPortConnectionInfo;


        public SerialPortConnectionSettingsViewModel(SerialPortConnectionInfo serialPortConnectionInfo)
        {
            _serialPortConnectionInfo = serialPortConnectionInfo;
        }


        public class ComPortOptionsPropertyConverter : StringOptionsPropertyConverter
        {
            protected override List<string> GetOptions()
            {
                List<string> portNames = System.IO.Ports.SerialPort.GetPortNames().ToList();
                return portNames;
            }
        }


    }
}
