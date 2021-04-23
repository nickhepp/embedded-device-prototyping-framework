using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.IO.Cmds;
using Ecs.Edpf.GUI.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ecs.Edpf.GUI.UI.ViewModels
{
    public class DeviceCommandsViewModel : BaseDeviceViewModel, IDeviceCommandsViewModel
    {

        //private IDevice _device;

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
                _selectedDeviceCommandViewModel = value;
                _selectedDeviceCommandViewModel.PropertyChanged += SelectedDeviceCommandViewModelPropertyChanged;
                RaiseNotifyPropertyChanged();
                SelectedCommandExecuteButtonText = (value == null) ? "Open device to enable commands" : $"Execute '{_selectedDeviceCommandViewModel.MethodName}' command";
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


        protected override void OnDeviceStateChanged()
        {
            if (DeviceState == DeviceState.AssignedDevice)
            {
                DeviceCommandViewModels.Clear();
                foreach (IDeviceCommand deviceCommand in Device.DeviceCommands)
                {
                    DeviceCommandViewModel deviceCommandVwMdl = new DeviceCommandViewModel(Device, deviceCommand);
                    if (SelectedDeviceCommandViewModel == null)
                    {
                        SelectedDeviceCommandViewModel = deviceCommandVwMdl;
                    }
                    DeviceCommandViewModels.Add(deviceCommandVwMdl);
                }
                DeviceCommandViewModels.ResetBindings();
            }
            
        }

    }
}
