using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.IO.Macros;
using Ecs.Edpf.GUI.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ecs.Edpf.GUI.UI.ViewModels
{
    public class DeviceTextMacroViewModel : BaseDeviceViewModel, ISettingsResource
    {
        public string ResourceName => "DeviceTextMacro";

        private ICommand _toggleLoopCommand;
        public ICommand ToggleLoopCommand => _toggleLoopCommand;

        private ICommand _oneShotCommand;
        public ICommand OneShotCommand => _oneShotCommand;

        private DeviceTextMacro _deviceTextMacro;
        public DeviceTextMacro DeviceTextMacro 
         {
            get
            {
                return _deviceTextMacro;
            }
            set
            {
                _deviceTextMacro = value;
                CheckCommandsCanExecute();
            }
        }




        public DeviceTextMacroViewModel()
        {
            _toggleLoopCommand = new Ecs.Edpf.GUI.ComponentModel.RelayCommand(canExecute: ToggleLoopCommandCanExecute, execute: ToggleLoopCommandExecute);

            _oneShotCommand = new Ecs.Edpf.GUI.ComponentModel.RelayCommand(canExecute: OneShotCommandCanExecute, execute: OneShotCommandExecute);

        }

        private bool OneShotCommandCanExecute(object obj)
        {
            return (_deviceTextMacro?.DeviceTextLines.Count > 0) && (Device != null);
        }

        private void OneShotCommandExecute(object obj)
        {

        }

        private void ToggleLoopCommandExecute(object obj)
        {

        }


        public bool ToggleLoopCommandCanExecute(object obj)
        {
            return true;
        }


        public void ApplyDefaultSettings()
        {
            DeviceTextMacro = new DeviceTextMacro();
        }

        // settings names
        private const string DeviceTextMacroSettingsName = "DeviceTextMacro";

        public void ApplySettings(Dictionary<string, string> settings)
        {
            try
            {
                if (settings.ContainsKey(DeviceTextMacroSettingsName))
                {
                    DeviceTextMacro = Newtonsoft.Json.JsonConvert.DeserializeObject<DeviceTextMacro>(settings[DeviceTextMacroSettingsName]);
                }

            }
            catch (Exception ex)
            {

            }

        }

        public Dictionary<string, string> GetSettings()
        {
            string deviceTextMacroStr = Newtonsoft.Json.JsonConvert.SerializeObject(DeviceTextMacro);
            Dictionary<string, string> settings = new Dictionary<string, string>
            {
                { DeviceTextMacroSettingsName, deviceTextMacroStr }
            };

            return settings;
        }

        protected override void InternalDevicePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        
        protected override void OnDeviceChanged(IDevice device)
        {
            

        }

        private void CheckCommandsCanExecute()
        {
            RaiseNotifyPropertyChanged(nameof(ToggleLoopCommand));
            RaiseNotifyPropertyChanged(nameof(OneShotCommand));
        }

        internal class DeviceTextMacroBackgroundWorker : BackgroundWorker
        {
            private int? _deviceTextLineIdx = null;
            private DeviceTextMacro _deviceTextMacro;

            protected override bool CanRaiseEvents => true;

            public DeviceTextMacroBackgroundWorker(DeviceTextMacro deviceTextMacro)
            {
                _deviceTextMacro = deviceTextMacro;
            }

            protected override void OnDoWork(DoWorkEventArgs e)
            {

                //e.Cancel

                base.OnDoWork(e);
            }




        }

    }
}
