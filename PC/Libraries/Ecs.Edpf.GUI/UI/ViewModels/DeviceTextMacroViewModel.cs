using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.IO.Macros;
using Ecs.Edpf.GUI.ComponentModel;
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
    public class DeviceTextMacroViewModel : BaseDeviceViewModel, ISettingsResource, IDeviceTextMacroViewModel
    {
        private DeviceTextMacroBackgroundWorker _oneShotBgWorker = null;
        private DeviceTextMacroBackgroundWorker _loopBgWorker = null;

        private IDeviceTextMacroStateMachine _deviceTextMacroStateMachine;

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

        private RelayCommand _recordPauseCommand;
        public IRelayCommand RecordPauseCommand => _recordPauseCommand;

        private RelayCommand _toggleLoopCommand;
        public IRelayCommand ToggleLoopCommand => _toggleLoopCommand;

        private RelayCommand _oneShotCommand;
        public IRelayCommand OneShotCommand => _oneShotCommand;

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




        public DeviceTextMacroViewModel(
            IDeviceTextMacroStateMachine deviceTextMacroStateMachine) :
            base(deviceTextMacroStateMachine)
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

            _deviceTextMacroStateMachine = deviceTextMacroStateMachine;
            _deviceTextMacroStateMachine.DeviceTextMacroStateChanged += DeviceTextMacroStateMachine_DeviceTextMacroStateChanged;
        }

        private void DeviceTextMacroStateMachine_DeviceTextMacroStateChanged(object sender, EventArgs e)
        {
            _toggleLoopCommand.RaiseCommandCanExecuteChanged();
            _recordPauseCommand.RaiseCommandCanExecuteChanged();
            _oneShotCommand.RaiseCommandCanExecuteChanged();
        }



        private void RecordPauseCommandExecute(object obj)
        {

        }

        private bool RecordPauseCommandCanExecute(object obj)
        {
            return (_deviceTextMacroStateMachine.DeviceTextMacroState == DeviceTextMacroState.RecordingMacro);
        }

        private bool OneShotCommandCanExecute(object obj)
        {
            return ((_deviceTextMacroStateMachine.DeviceTextMacroState == DeviceTextMacroState.OpenedDevice) &&
                (_deviceTextMacro?.DeviceTextLines.Count > 0));
        }

        private void OneShotCommandExecute(object obj)
        {
            // set the next state
            _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(DeviceTextMacroSignal.MacroOneShotting);

            // make a copy so we dont have to worry about changes from one thread to the other
            DeviceTextMacro deviceTextMacro = DeviceTextMacro.Copy();
            _oneShotBgWorker = new DeviceTextMacroBackgroundWorker(deviceTextMacro);


            //            private DeviceTextMacroBackgroundWorker _oneShotBgWorker = null;
            //private DeviceTextMacroBackgroundWorker _loopBgWorker = null;


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
