using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.ComponentModel;
using Ecs.Edpf.Devices.IO.Cmds;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Input;

namespace Ecs.Edpf.GUI.UI.ViewModels
{
    public class DeviceCommandsViewModel : BaseDeviceViewModel, IDeviceCommandsViewModel
    {

        public BindingList<IDeviceCommandViewModel> DeviceCommandViewModels { get; } = new BindingList<IDeviceCommandViewModel>();

        public Image ViewImage => throw new NotImplementedException();

        public string Name => "Device Commands";


        private IDeviceCommandViewModel _selectedDeviceCommandViewModel;
        public IDeviceCommandViewModel SelectedDeviceCommandViewModel
        {
            get
            {
                return _selectedDeviceCommandViewModel;
            }
            set
            {

                if (_selectedDeviceCommandViewModel != null)
                {
                    // in the event a prior one was set, add the event handler
                    _selectedDeviceCommandViewModel.PropertyChanged -= SelectedDeviceCommandViewModelPropertyChanged;
                }

                _selectedDeviceCommandViewModel = value;
                if (value != null)
                {
                    // if a valid one is set then add the event handler
                    _selectedDeviceCommandViewModel.PropertyChanged += SelectedDeviceCommandViewModelPropertyChanged;
                }
                RaiseNotifyPropertyChanged();
                SetSelectedCommandExecuteButtonText();
                SetSelectedCommandExecuteButtonEnabled();
            }
        }

        private ICommand _selectedCommand;
        public ICommand SelectedCommand => _selectedCommand;

        private string _executeButtonText;
        public string SelectedCommandExecuteButtonText
        {
            get
            {
                return _executeButtonText;
            }
            private set
            {
                _executeButtonText = value;
                RaiseNotifyPropertyChanged();
            }
        }

        private bool _selectedCommandExecuteButtonEnabled;
        public bool SelectedCommandExecuteButtonEnabled
        {
            get
            {
                return _selectedCommandExecuteButtonEnabled;
            }
            private set
            {
                _selectedCommandExecuteButtonEnabled = value;
                RaiseNotifyPropertyChanged();
            }
        }

        public DeviceCommandsViewModel(IDeviceStateMachine deviceStateMachine) : base(deviceStateMachine)
        {
            _selectedCommand = new Ecs.Edpf.GUI.ComponentModel.RelayCommand(canExecute: SelectedCommandCanExecute, execute: SelectedCommandExecute);
            SetSelectedCommandExecuteButtonText();
        }

        private void SetSelectedCommandExecuteButtonText()
        {
            SelectedCommandExecuteButtonText = (_selectedDeviceCommandViewModel == null) ? 
                    "Open device in [Connections] to enable commands" :
                    $"Execute '{_selectedDeviceCommandViewModel.MethodName}' command";
        }

        private void SelectedDeviceCommandViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IDeviceCommandViewModel.IsValid))
            {
                SetSelectedCommandExecuteButtonEnabled();
            }
        }

        private void SelectedCommandExecute(object obj)
        {
            _selectedDeviceCommandViewModel.Execute();
        }


        private bool SelectedCommandCanExecute(object obj)
        {
            return SelectedDeviceCommandViewModel != null && SelectedDeviceCommandViewModel.IsValid;
        }

        private void SetSelectedCommandExecuteButtonEnabled()
        {
            SelectedCommandExecuteButtonEnabled = SelectedCommandCanExecute(null);
        }

        private void RefreshDeviceCommandViewModels()
        {
            DeviceCommandViewModels.Clear();
            foreach (IDeviceCommand deviceCommand in Device.DeviceCommands)
            {
                DeviceCommandViewModels.Add(new DeviceCommandViewModel(Device, deviceCommand));
            }
            DeviceCommandViewModels.ResetBindings();
            SelectedDeviceCommandViewModel = DeviceCommandViewModels.FirstOrDefault();
        }

        protected override void OnDeviceStateChanged()
        {
            if (DeviceState == DeviceState.AssignedDevice)
            {
                RefreshDeviceCommandViewModels();
            }
            else if (DeviceState == DeviceState.OpenedDevice)
            {
                string cmds = Device.GetRegisteredCommands();
                List<string> cmdList = cmds.Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                cmdList = cmdList.Where(testCmd => !testCmd.StartsWith(Constants.CommandNamePrefix) &&
                        !testCmd.StartsWith(Constants.CommandResponseLineEnding.Replace("\r", "").Replace("\n", ""))).ToList();
                CommandByDescriptionBuilder builder = new CommandByDescriptionBuilder();
                List<IDeviceCommand> builtCommands = new List<IDeviceCommand>();
                foreach (string cmdDesc in cmdList)
                {
                    builtCommands.Add(builder.GetCommandByDescription(cmdDesc));
                }
                Device.AddDeviceCommands(builtCommands);
                RefreshDeviceCommandViewModels();
            }
            else if (DeviceState == DeviceState.NoDevice)
            {
                SelectedDeviceCommandViewModel = null;
                DeviceCommandViewModels.Clear();
            }

        }

    }
}
