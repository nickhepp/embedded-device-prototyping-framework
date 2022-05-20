using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.IO.Cmds;
using Ecs.Edpf.GUI.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ecs.Edpf.GUI.UI.ViewModels
{
    public class AddDeviceCommandsToMacroViewModel : BaseViewModel, IAddDeviceCommandsToMacroViewModel
    {

        public BindingList<IGetDeviceCommandLinesViewModel> DeviceCommandViewModels { get; } = new BindingList<IGetDeviceCommandLinesViewModel>();


        private IGetDeviceCommandLinesViewModel _selectedDeviceCommandViewModel;
        public IGetDeviceCommandLinesViewModel SelectedDeviceCommandViewModel
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

        private IRelayCommand _selectedCommand;
        public IRelayCommand SelectedCommand => _selectedCommand;

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


        public AddDeviceCommandsToMacroViewModel(IDevice device)
        {

            DeviceCommandViewModels.Clear();
            foreach (IDeviceCommand deviceCommand in device.DeviceCommands)
            {
                DeviceCommandViewModels.Add(new GetDeviceCommandLinesViewModel(deviceCommand));
            }
            DeviceCommandViewModels.ResetBindings();
            SelectedDeviceCommandViewModel = DeviceCommandViewModels.FirstOrDefault();

            _selectedCommand = new RelayCommand(SelectedCommandCanExecute, SelectedCommandExecute);
        }

        private void SetSelectedCommandExecuteButtonText()
        {
            SelectedCommandExecuteButtonText = $"Add '{_selectedDeviceCommandViewModel.MethodName}' command";
        }

        private void SelectedDeviceCommandViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IDeviceCommandViewModel.IsValid))
            {
                SetSelectedCommandExecuteButtonEnabled();
            }
        }

        private bool SelectedCommandCanExecute(object obj)
        {
            return SelectedDeviceCommandViewModel != null && SelectedDeviceCommandViewModel.IsValid;
        }

        private void SelectedCommandExecute(object obj)
        {

        }



        private void SetSelectedCommandExecuteButtonEnabled()
        {
            SelectedCommandExecuteButtonEnabled = SelectedCommandCanExecute(null);
        }


    }
}
