using Ecs.Edpf.Connections.Serial;
using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.Connections.Serial;
using Ecs.Edpf.GUI.ComponentModel;
using Ecs.Edpf.GUI.UI.ViewModels.Connections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels
{
    public class SerialPortConnectionSettingsViewModel : DeviceConnectionSettingsViewModel, IStandardValuesOptionsProvider 
    {
        public const string ComPortOptionsName = "ComPortOptions";

        public const string ExcludedComPortsSeparator = "|";

        const string SerailSettingsCategory = "Serial Settings";

        [Category(SerailSettingsCategory)]
        [TypeConverter(typeof(ComPortOptionsPropertyConverter))]
        [DisplayName("COM Port")]
        public string ComPort
        {
            get
            {
                return _serialPortConnectionInfo.DevicePort;
            }
            set
            {
                _serialPortConnectionInfo.DevicePort = value;
                ClearSelectedComPortFromExcludedComPorts();
            }
        }

        private List<string> _excludedComPorts = new List<string>();
        [Category(SerailSettingsCategory)]
        [Editor(@"System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
            typeof(System.Drawing.Design.UITypeEditor))]
        [TypeConverter(typeof(StringCollectionTypeConverter))]
        [DisplayName("Excluded COM Ports")]
        public List<string> ExcludedComPorts
        {
            get
            {
                return _excludedComPorts;
            }
            set 
            { 
                _excludedComPorts = value;
                ClearSelectedComPortFromExcludedComPorts();
            }
        }

        private SerialPortConnectionInfo _serialPortConnectionInfo;

        private ISerialPortFactory _serialPortFactory;

        public SerialPortConnectionSettingsViewModel(SerialPortConnectionInfo serialPortConnectionInfo, ISerialPortFactory serialPortFactory)
        {

            _serialPortConnectionInfo = serialPortConnectionInfo;
            _serialPortFactory = serialPortFactory;
        }

        private void ClearSelectedComPortFromExcludedComPorts()
        {
            if (_excludedComPorts != null)
            {
                if (_excludedComPorts.Any(testVal => testVal == _serialPortConnectionInfo.DevicePort))
                {
                    _serialPortConnectionInfo.DevicePort = null;
                }
            }
        }

        public List<string> GetFilteredOptions()
        {
            return new List<string>(_excludedComPorts);
        }

        protected override string GetResourceName()
        {
            return nameof(SerialPortConnectionSettingsViewModel);
        }

        protected override Dictionary<string, string> InternalGetSettings()
        {
            Dictionary<string, string> settings = new Dictionary<string, string>
            {
                { nameof(ComPort), ComPort },
                { nameof(ExcludedComPorts), string.Join(ExcludedComPortsSeparator, ExcludedComPorts) },
            };
            return settings;
        }

        protected override void InternalApplySettings(Dictionary<string, string> settings)
        {
            if (settings.TryGetValue(nameof(ComPort), out string theComPort))
            {
                ComPort = theComPort;
            }
            if (settings.TryGetValue(nameof(ExcludedComPorts), out string excludedComPorts) && !string.IsNullOrEmpty(excludedComPorts))
            {
                List<string> theExcludedCompPorts = excludedComPorts.Split(new string[] { ExcludedComPortsSeparator }, StringSplitOptions.RemoveEmptyEntries).ToList();
                ExcludedComPorts = theExcludedCompPorts;
            }
        }

        protected override void InternalApplyDefaultSettings()
        {
            ComPort = _serialPortFactory.GetSerialPortNames().FirstOrDefault();
            ExcludedComPorts = new List<string>();
        }

        public List<string> GetOptions(string optionsName)
        {
            if (optionsName == ComPortOptionsName)
            {
                return _serialPortFactory.GetSerialPortNames();
            }
            throw new NotImplementedException($"Options for '{optionsName}' are not implemented.");
        }

        public List<string> GetFilteredOptions(string optionsName)
        {
            if (optionsName == ComPortOptionsName)
            {
                return ExcludedComPorts;
            }
            throw new NotImplementedException($"Options for '{optionsName}' are not implemented.");
        }

        public class ComPortOptionsPropertyConverter : StandardValuesOptionsPropertyConverter
        {

            public ComPortOptionsPropertyConverter() : base(ComPortOptionsName) { }

        }


    }
}
