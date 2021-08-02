using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.IO.Macros;
using Ecs.Edpf.GUI.ComponentModel;
using Ecs.Edpf.GUI.ComponentModel.Macros;
using Ecs.Edpf.GUI.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Ecs.Edpf.GUI.UI.ViewModels
{
    public class DeviceTextMacroViewModel : BaseDeviceViewModel, ISettingsResource, IDeviceTextMacroViewModel
    {

        private IDeviceTextMacroBgWorkerFactory _deviceTextMacroBgWorkerFactory;

        private IDeviceTextMacroBgWorker _macroLoopBgWorker;

        private IDeviceTextMacroStateMachine _deviceTextMacroStateMachine;

        public string ResourceName => "DeviceTextMacro";

        public const string RecordText = "Record";
        public const string PauseText = "Pause";

        private string _recordPauseButtonText = RecordText;
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

        public bool IsRecording { get; private set; }

        public DeviceTextMacroViewModel(
            IDeviceTextMacroStateMachine deviceTextMacroStateMachine,
            IDeviceTextMacroBgWorkerFactory deviceTextMacroBgWorkerFactory) :
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

            _deviceTextMacroBgWorkerFactory = deviceTextMacroBgWorkerFactory;

            SetIsRecording();
            SetRecordPauseButtonText();
        }


        private void SetIsRecording()
        {
            IsRecording = (_deviceTextMacroStateMachine.DeviceTextMacroState == DeviceTextMacroState.RecordingMacro);
        }

        private void SetRecordPauseButtonText()
        {
            if (_deviceTextMacroStateMachine.DeviceTextMacroState == DeviceTextMacroState.RecordingMacro)
            {
                RecordPauseButtonText = PauseText;
            }
            else
            {
                RecordPauseButtonText = RecordText;
            }
        }

        private void DeviceTextMacroStateMachine_DeviceTextMacroStateChanged(object sender, EventArgs e)
        {
            _toggleLoopCommand.RaiseCommandCanExecuteChanged();
            _recordPauseCommand.RaiseCommandCanExecuteChanged();
            _oneShotCommand.RaiseCommandCanExecuteChanged();

            SetIsRecording();
            SetRecordPauseButtonText();
        }

        private void RecordPauseCommandExecute(object obj)
        {
            if (_deviceTextMacroStateMachine.DeviceTextMacroState == DeviceTextMacroState.OpenedDevice)
            {
                _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(DeviceTextMacroSignal.MacroRecording);
            }
            else if (_deviceTextMacroStateMachine.DeviceTextMacroState == DeviceTextMacroState.RecordingMacro)
            {
                _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(DeviceTextMacroSignal.MacroStopRecording);
            }
        }

        private bool RecordPauseCommandCanExecute(object obj)
        {
            return ((_deviceTextMacroStateMachine.DeviceTextMacroState == DeviceTextMacroState.OpenedDevice) || 
                (_deviceTextMacroStateMachine.DeviceTextMacroState == DeviceTextMacroState.RecordingMacro));
        }

        private bool OneShotCommandCanExecute(object obj)
        {
            return ((_deviceTextMacroStateMachine.DeviceTextMacroState == DeviceTextMacroState.OpenedDevice) &&
                (_deviceTextMacro?.DeviceTextLines.Count > 0));
        }

        private DeviceTextMacroSignal _macroStoppingNextSignal;
        private void OneShotCommandExecute(object obj)
        {
            // set the next state
            _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(DeviceTextMacroSignal.MacroOneShotting);

            // make a copy so we dont have to worry about changes from one thread to the other
            _macroLoopBgWorker = _deviceTextMacroBgWorkerFactory.GetDeviceTextMacroBgWorker(DeviceTextMacro.Copy());
            _macroLoopBgWorker.ProgressChanged += MacroLoopBgWorker_ProgressChanged;
            _macroLoopBgWorker.RunWorkerCompleted += MacroLoopBgWorker_RunWorkerCompleted;
        }

        private void MacroLoopBgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(_macroStoppingNextSignal);
            _macroLoopBgWorker.Dispose();
        }

        private void MacroLoopBgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is DeviceTextMacroProgressChanged devTxtMacroProgressChanged)
            {
                Device.Write(devTxtMacroProgressChanged.DeviceText);
            }
        }

        private void ToggleLoopCommandExecute(object obj)
        {
            if (_deviceTextMacroStateMachine.DeviceTextMacroState == DeviceTextMacroState.OpenedDevice)
            {
                _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(DeviceTextMacroSignal.MacroLooping);
            }
            else
            {
                _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(DeviceTextMacroSignal.MacroStopLooping);
            }
        }

        private static List<DeviceTextMacroState> _loopCanExecuteStates = new List<DeviceTextMacroState>
        { DeviceTextMacroState.OpenedDevice, DeviceTextMacroState.LoopingMacro };
        public bool ToggleLoopCommandCanExecute(object obj)
        {
            return ((_loopCanExecuteStates.Contains(_deviceTextMacroStateMachine.DeviceTextMacroState)) &&
                (_deviceTextMacro?.DeviceTextLines.Count > 0));
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

        private void CheckCommandsCanExecute()
        {
            _toggleLoopCommand.RaiseCommandCanExecuteChanged(this);
            _oneShotCommand.RaiseCommandCanExecuteChanged(this);
            _recordPauseCommand.RaiseCommandCanExecuteChanged(this);
        }

 
    }
}
