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
    public class ComPortConnectionSettingsViewModel : DeviceConnectionSettingsViewModel
    {

        private string _comPort = "";
        [TypeConverter(typeof(ComPortOptionsPropertyConverter))]
        public string ComPort
        {
            get
            {
                return _comPort;
            }
            set
            {
                _comPort = value;
            }
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
