﻿using Ecs.Edpf.Devices.ComponentModel.Macros.Instructions;
using Ecs.Edpf.GUI.ComponentModel;
using Ecs.Edpf.Devices.ComponentModel.Macros;
using Ecs.Edpf.GUI.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Ecs.Edpf.Devices.ComponentModel;

namespace Ecs.Edpf.GUI.UI.ViewModels
{
    public class DeviceTextMacroViewModel : BaseDeviceViewModel, ISettingsResource, IDeviceTextMacroViewModel, ICloseCancelable //IWaitForCompletable
    {

        private IDeviceTextMacroBgWorkerFactory _deviceTextMacroBgWorkerFactory;

        private IDeviceTextMacroBgWorker _macroBgWorker;

        private IDeviceTextMacroStateMachine _deviceTextMacroStateMachine;

        private IInstructionCollectionFactory _instructionCollectionFactory;

        private IDateTimeProvider _dateTimeProvider;

        public string ResourceName => "DeviceTextMacro";


        private RelayCommand _stopCommand;
        public IRelayCommand StopCommand => _stopCommand;

        private RelayCommand _loopCommand;
        public IRelayCommand LoopCommand => _loopCommand;

        private RelayCommand _oneShotCommand;
        public IRelayCommand OneShotCommand => _oneShotCommand;

        private bool _addCommandTextEnabled = false;
        public bool AddCommandTextEnabled
        {
            get => _addCommandTextEnabled;
            private set
            {
                _addCommandTextEnabled = value;
                RaiseNotifyPropertyChanged();
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

        public const int MinPercentCompete = 0;
        public const int MaxPercentCompete = 100;

        private int _percentComplete = 0;
        public int PercentComplete
        {
            get { return _percentComplete; }
            private set
            {
                value = Math.Min(Math.Max(value, MinPercentCompete), MaxPercentCompete);
                _percentComplete = value;
                RaiseNotifyPropertyChanged();
            }
        }



        public DeviceTextMacroViewModel(
            IDeviceTextMacroStateMachine deviceTextMacroStateMachine,
            IDeviceTextMacroBgWorkerFactory deviceTextMacroBgWorkerFactory,
            IInstructionCollectionFactory instructionCollectionFactory,
            IDateTimeProvider dateTimeProvider) :
            base(deviceTextMacroStateMachine)
        {
            _loopCommand = new RelayCommand(
                canExecute: LoopCommandCanExecute,
                execute: LoopCommandExecute);

            _oneShotCommand = new RelayCommand(
                canExecute: OneShotCommandCanExecute,
                execute: OneShotCommandExecute);

            _stopCommand = new RelayCommand(
                canExecute: StopCommandCanExecute,
                execute: StopCommandExecute);

            _deviceTextMacroStateMachine = deviceTextMacroStateMachine;
            _deviceTextMacroStateMachine.DeviceTextMacroStateChanged += DeviceTextMacroStateMachine_DeviceTextMacroStateChanged;

            _deviceTextMacroBgWorkerFactory = deviceTextMacroBgWorkerFactory;

            _instructionCollectionFactory = instructionCollectionFactory;

            _dateTimeProvider = dateTimeProvider;

            // set the initial state
            DeviceTextMacroStateMachine_DeviceTextMacroStateChanged(null, new EventArgs());

        }

         
        private void DeviceTextMacroStateMachine_DeviceTextMacroStateChanged(object sender, EventArgs e)
        {
            _loopCommand.RaiseCommandCanExecuteChanged();
            _stopCommand.RaiseCommandCanExecuteChanged();
            _oneShotCommand.RaiseCommandCanExecuteChanged();

            MacroTextEnabled = ((_deviceTextMacroStateMachine.DeviceTextMacroState == DeviceTextMacroState.OpenedDevice) || (_deviceTextMacroStateMachine.DeviceTextMacroState == DeviceTextMacroState.NotOpenDevice));
            AddCommandTextEnabled = (_deviceTextMacroStateMachine.DeviceTextMacroState == DeviceTextMacroState.OpenedDevice);
        }

        private void StopCommandExecute(object obj)
        {
            _macroBgWorker.CancelAsync();
        }
        
        private bool StopCommandCanExecute(object obj)
        {
            return ((_deviceTextMacroStateMachine.DeviceTextMacroState == DeviceTextMacroState.LoopingMacro) || 
                (_deviceTextMacroStateMachine.DeviceTextMacroState == DeviceTextMacroState.OneShottingMacro));
        }

        private bool OneShotCommandCanExecute(object obj)
        {
            return (_deviceTextMacroStateMachine.DeviceTextMacroState == DeviceTextMacroState.OpenedDevice);
        }


        private void InternalMacroCommandExecute(InstructionCollection instructionCollection, DeviceTextMacroSignal signal, MacroExecutionType exeType)
        {

            _macroBgWorker = _deviceTextMacroBgWorkerFactory.GetDeviceTextMacroBgWorker(instructionCollection, exeType);

            // set the next state
            _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(signal);

            _macroBgWorker.ProgressChanged += MacroBgWorker_ProgressChanged;
            _macroBgWorker.RunWorkerCompleted += MacroBgWorker_RunWorkerCompleted;

            PercentComplete = MinPercentCompete;

            _macroBgWorker.RunWorkerAsync();

        }

        private void OneShotCommandExecute(object obj)
        {
            if (obj is InstructionCollectionInitArgs initArgs)
            {
                InstructionCollection instructionCollection = _instructionCollectionFactory.ParseDeviceTextMacroInitArgs(initArgs);
                InternalMacroCommandExecute(instructionCollection, DeviceTextMacroSignal.MacroOneShotting, MacroExecutionType.OneShot);
            }
            else
            {
                throw new ArgumentException($"Argument for '{nameof(OneShotCommandExecute)}' is not the expected type.");
            }
        }

        private void MacroBgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(DeviceTextMacroSignal.MacroStop);
            _macroBgWorker.ProgressChanged -= MacroBgWorker_ProgressChanged;
            _macroBgWorker.RunWorkerCompleted -= MacroBgWorker_RunWorkerCompleted;
            _macroBgWorker.Dispose();

            _macroBgWorker = null;
            PercentComplete = 0;
        }

        private void MacroBgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is DeviceTextMacroProgressChanged devTxtMacroProgressChanged)
            {
                if ((_deviceTextMacroStateMachine.DeviceTextMacroState == DeviceTextMacroState.LoopingMacro ||
                    _deviceTextMacroStateMachine.DeviceTextMacroState == DeviceTextMacroState.OneShottingMacro) &&
                    DeviceState == Devices.ComponentModel.DeviceState.OpenedDevice)
                {
                    IEnumerable<DeviceTextInstruction> devTextInstructions = devTxtMacroProgressChanged.TimeGroupings.SelectMany(tGrpng => tGrpng.DeviceTextInstructions);
                    foreach (DeviceTextInstruction deviceTextInstruction in devTextInstructions)
                    {
                        Device.Write(deviceTextInstruction.GetDeviceText());
                    }

                }

                PercentComplete = (int)(100 * devTxtMacroProgressChanged.RatioComplete.GetValueOrDefault());
            }
        }

        private void LoopCommandExecute(object obj)
        {
            if (obj is InstructionCollectionInitArgs initArgs)
            {
                InstructionCollection instructionCollection = _instructionCollectionFactory.ParseDeviceTextMacroInitArgs(initArgs);
                InternalMacroCommandExecute(instructionCollection, DeviceTextMacroSignal.MacroLooping, MacroExecutionType.Loop);
            }
            else
            {
                throw new ArgumentException($"Argument for '{nameof(OneShotCommandExecute)}' is not the expected type.");
            }
        }

        private static List<DeviceTextMacroState> _loopCanExecuteStates = new List<DeviceTextMacroState>
        { DeviceTextMacroState.OpenedDevice, DeviceTextMacroState.LoopingMacro };
        public bool LoopCommandCanExecute(object obj)
        {
            return (_deviceTextMacroStateMachine.DeviceTextMacroState == DeviceTextMacroState.OpenedDevice);
        }


        public void ApplyDefaultSettings()
        {
            
        }

        // settings names
        private const string DeviceTextMacroSettingsName = "DeviceTextMacro";

        public void ApplySettings(Dictionary<string, string> settings)
        {
            try
            {
                if (settings.ContainsKey(DeviceTextMacroSettingsName))
                {
                    //Instructions = Newtonsoft.Json.JsonConvert.DeserializeObject<InstructionCollection>(settings[DeviceTextMacroSettingsName]);
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
            return new Dictionary<string, string>();
            //string deviceTextMacroStr = Newtonsoft.Json.JsonConvert.SerializeObject(Instructions);
            //Dictionary<string, string> settings = new Dictionary<string, string>
            //{
            //    { DeviceTextMacroSettingsName, deviceTextMacroStr }
            //};

            //return settings;
        }

        private void CheckCommandsCanExecute()
        {
            _loopCommand.RaiseCommandCanExecuteChanged(this);
            _oneShotCommand.RaiseCommandCanExecuteChanged(this);
            _stopCommand.RaiseCommandCanExecuteChanged(this);
        }

        // I think the code below worked just fine, but it ended up not being sufficient to stop exceptions
        //private const double MaxCompletionDurationSeconds = 5.0;
        //private DateTime? _endComplete = null;
        //public void BeginCompletion()
        //{
        //    if (StopCommandCanExecute(null))
        //    {
        //        StopCommandExecute(null);
        //        _endComplete = _dateTimeProvider.GetCurrentDateTime().AddSeconds(MaxCompletionDurationSeconds);
        //    }
        //}

        //public void WaitForCompletion()
        //{
        //    if (_endComplete.HasValue)
        //    {
        //        while (!_macroBgWorker.CancellationAcknowledge && (_endComplete.Value > _dateTimeProvider.GetCurrentDateTime()))
        //        {
        //            System.Threading.Thread.Sleep(100);
        //        }
        //    }
        //}

        public string GetCancelCloseReason()
        {
            string cancelReason = null;
            if (StopCommandCanExecute(null))
            {
                cancelReason = "The application cannot be closed while a macro is executing. Please stop the execution of the macro.";
            }
            return cancelReason;
        }
    }
}
