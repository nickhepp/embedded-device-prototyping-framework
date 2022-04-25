using Ecs.Edpf.Devices.ComponentModel.Macros.Instructions;
using Ecs.Edpf.GUI.ComponentModel;
using Ecs.Edpf.Devices.ComponentModel.Macros;
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


        private RelayCommand _stopCommand;
        public IRelayCommand StopCommand => _stopCommand;

        private RelayCommand _loopCommand;
        public IRelayCommand LoopCommand => _loopCommand;

        private RelayCommand _oneShotCommand;
        public IRelayCommand OneShotCommand => _oneShotCommand;

        private InstructionCollection _instructions;
        public InstructionCollection Instructions
        {
            get
            {
                return _instructions;
            }
            set
            {
                _instructions = value;
                CheckCommandsCanExecute();
            }
        }

        private bool _macroTextEnabled;
        public bool MacroTextEnabled
        {
            get
            {
                return _macroTextEnabled;
            }
            private set
            {
                _macroTextEnabled = value;
                RaiseNotifyPropertyChanged();
            }
        }



        public DeviceTextMacroViewModel(
            IDeviceTextMacroStateMachine deviceTextMacroStateMachine,
            IDeviceTextMacroBgWorkerFactory deviceTextMacroBgWorkerFactory) :
            base(deviceTextMacroStateMachine)
        {
            _loopCommand = new Ecs.Edpf.GUI.ComponentModel.RelayCommand(
                canExecute: LoopCommandCanExecute,
                execute: LoopCommandExecute);

            _oneShotCommand = new Ecs.Edpf.GUI.ComponentModel.RelayCommand(
                canExecute: OneShotCommandCanExecute,
                execute: OneShotCommandExecute);

            _stopCommand = new Ecs.Edpf.GUI.ComponentModel.RelayCommand(
                canExecute: StopCommandCanExecute,
                execute: StopCommandExecute);

            _deviceTextMacroStateMachine = deviceTextMacroStateMachine;
            _deviceTextMacroStateMachine.DeviceTextMacroStateChanged += DeviceTextMacroStateMachine_DeviceTextMacroStateChanged;

            _deviceTextMacroBgWorkerFactory = deviceTextMacroBgWorkerFactory;

            // set the initial state
            DeviceTextMacroStateMachine_DeviceTextMacroStateChanged(null, new EventArgs());

        }

         
        private void DeviceTextMacroStateMachine_DeviceTextMacroStateChanged(object sender, EventArgs e)
        {
            _loopCommand.RaiseCommandCanExecuteChanged();
            _stopCommand.RaiseCommandCanExecuteChanged();
            _oneShotCommand.RaiseCommandCanExecuteChanged();

            MacroTextEnabled = (_deviceTextMacroStateMachine.DeviceTextMacroState == DeviceTextMacroState.OpenedDevice);
        }

        private void StopCommandExecute(object obj)
        {
            _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(DeviceTextMacroSignal.DeviceOpened);
        }

        private bool StopCommandCanExecute(object obj)
        {
            return ((_deviceTextMacroStateMachine.DeviceTextMacroState == DeviceTextMacroState.LoopingMacro) || 
                (_deviceTextMacroStateMachine.DeviceTextMacroState == DeviceTextMacroState.OneShottingMacro));
        }

        private bool OneShotCommandCanExecute(object obj)
        {
            return ((_deviceTextMacroStateMachine.DeviceTextMacroState == DeviceTextMacroState.OpenedDevice) &&
                (_instructions?.InstructionsCount > 0));
        }

        private DeviceTextMacroSignal _macroStoppingNextSignal;
        private void OneShotCommandExecute(object obj)
        {
            // set the next state
            _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(DeviceTextMacroSignal.MacroOneShotting);

            // make a copy so we dont have to worry about changes from one thread to the other
            _macroLoopBgWorker = _deviceTextMacroBgWorkerFactory.GetDeviceTextMacroBgWorker(Instructions.Copy(), MacroExecutionType.OneShot);
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
                //Device.Write(devTxtMacroProgressChanged.DeviceText);
            }
        }

        private void LoopCommandExecute(object obj)
        {
            if (obj is InstructionCollectionInitArgs initArgs)
            {

            }
            _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(DeviceTextMacroSignal.MacroLooping);
        }

        private static List<DeviceTextMacroState> _loopCanExecuteStates = new List<DeviceTextMacroState>
        { DeviceTextMacroState.OpenedDevice, DeviceTextMacroState.LoopingMacro };
        public bool LoopCommandCanExecute(object obj)
        {
            return ((_loopCanExecuteStates.Contains(_deviceTextMacroStateMachine.DeviceTextMacroState)) &&
                (_instructions?.InstructionsCount > 0));
        }


        public void ApplyDefaultSettings()
        {
            Instructions = new InstructionCollection(new List<Instruction>());
        }

        // settings names
        private const string DeviceTextMacroSettingsName = "DeviceTextMacro";

        public void ApplySettings(Dictionary<string, string> settings)
        {
            try
            {
                if (settings.ContainsKey(DeviceTextMacroSettingsName))
                {
                    Instructions = Newtonsoft.Json.JsonConvert.DeserializeObject<InstructionCollection>(settings[DeviceTextMacroSettingsName]);
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
            string deviceTextMacroStr = Newtonsoft.Json.JsonConvert.SerializeObject(Instructions);
            Dictionary<string, string> settings = new Dictionary<string, string>
            {
                { DeviceTextMacroSettingsName, deviceTextMacroStr }
            };

            return settings;
        }

        private void CheckCommandsCanExecute()
        {
            _loopCommand.RaiseCommandCanExecuteChanged(this);
            _oneShotCommand.RaiseCommandCanExecuteChanged(this);
            _stopCommand.RaiseCommandCanExecuteChanged(this);
        }

 
    }
}
