using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.ComponentModel;
using Ecs.Edpf.Devices.Logging;
using Ecs.Edpf.GUI.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.Logger
{
    public class LoggerViewModel : BaseDeviceViewModel, ILoggerViewModel
    {

        private bool _dirtySettings = false;

        private ILogLifeCycleManager _logLifeCycleManager;

        public ILoggerSettingsViewModel SettingsViewModel { get; private set; }

        private RelayCommand _saveLoggerSettingsCommand;
        public IRelayCommand SaveLoggerSettingsCommand => _saveLoggerSettingsCommand;

        public override IDeviceProvider DeviceProvider 
        { 
            get => base.DeviceProvider;
            set
            {
                base.DeviceProvider = value;
                _logLifeCycleManager.DeviceProvider = value;
            }
        }

        public LoggerViewModel(IDeviceStateMachine deviceStateMachine,
            ILoggerSettingsViewModel loggerSettingsViewModel, 
            ILogLifeCycleManager logLifeCycleManager) : base(deviceStateMachine)
        {
            SettingsViewModel = loggerSettingsViewModel;
            _logLifeCycleManager = logLifeCycleManager;

            _saveLoggerSettingsCommand = new RelayCommand(
                canExecute: SaveLoggerSettingsCommandCanExecute,
                execute: SaveLoggerSettingsCommandExecute);

            SettingsViewModel.PropertyChanged += SettingsViewModel_PropertyChanged;
        }

        private bool SaveLoggerSettingsCommandCanExecute(object args)
        {
            return _dirtySettings;
        }

        private void SaveLoggerSettingsCommandExecute(object args)
        {
            _logLifeCycleManager.ChangeLoggerSettings();
            _dirtySettings = false;
            _saveLoggerSettingsCommand.RaiseCommandCanExecuteChanged();
        }


        private void SettingsViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            bool dirtyChanged = (_dirtySettings == false);
            if (dirtyChanged)
            {
                _dirtySettings = true;
                _saveLoggerSettingsCommand.RaiseCommandCanExecuteChanged();
            }
        }
    }
}
