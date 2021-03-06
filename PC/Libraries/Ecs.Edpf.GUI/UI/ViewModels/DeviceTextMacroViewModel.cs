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

        private string _recordPauseButtonText = "Record";
        public string RecordPauseButtonText
        {
            get
            {
                return _recordPauseButtonText;
            }
            private set
            {
                _recordPauseButtonText = value;
                RaiseNotifyPropertyChanged();
            }
        }

        private ICommand _recordPauseCommand;
        public ICommand RecordPauseCommand => _recordPauseCommand;

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
            _toggleLoopCommand = new Ecs.Edpf.GUI.ComponentModel.RelayCommand(
                canExecute: ToggleLoopCommandCanExecute, 
                execute: ToggleLoopCommandExecute);

            _oneShotCommand = new Ecs.Edpf.GUI.ComponentModel.RelayCommand(
                canExecute: OneShotCommandCanExecute, 
                execute: OneShotCommandExecute);

            _recordPauseCommand = new Ecs.Edpf.GUI.ComponentModel.RelayCommand(
                canExecute: RecordPauseCommandCanExecute,
                execute: RecordPauseCommandExecute);
        }

        protected override void OnDeviceStateChanged()
        {
            
        }

        private void RecordPauseCommandExecute(object obj)
        {

        }

        private bool RecordPauseCommandCanExecute(object obj)
        {
            return false;
        }

        private bool OneShotCommandCanExecute(object obj)
        {
            return false;
            //return (_deviceTextMacro?.DeviceTextLines.Count > 0) && (Device != null);
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
                ex = ex;
                //throw new Exception(ex, "Add logging.");
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
