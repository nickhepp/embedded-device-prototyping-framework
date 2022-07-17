using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Input;
using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.ComponentModel;
using Ecs.Edpf.GUI.ComponentModel;

namespace Ecs.Edpf.GUI.UI.ViewModels.Connections
{
    public abstract class BaseConnectionViewModel : BaseDeviceViewModel, IConnectionViewModel
    {

        private IDeviceFactory _deviceFactory;

        private bool _isOpened = false;
        public bool IsOpened {
            get
            {
                return _isOpened;
            }
            set
            {
                _isOpened = value;
            }
        }

        private bool _openButtonEnabled = true;
        [Browsable(false)]
        public bool OpenButtonEnabled
        {
            get
            {
                return _openButtonEnabled;
            }
            private set
            {
                _openButtonEnabled = value;
                RaiseNotifyPropertyChanged();
            }
        }

        private bool _closeButtonEnabled = false;
        [Browsable(false)]
        public bool CloseButtonEnabled
        {
            get
            {
                return _closeButtonEnabled;
            }
            private set
            {
                _closeButtonEnabled = value;
                RaiseNotifyPropertyChanged();
            }
        }

        private ICommand _openCommand;
        [Browsable(false)]
        public System.Windows.Input.ICommand OpenCommand
        {
            get { return _openCommand; }
            private set
            {
                _openCommand = value;
            }
        }

        private ICommand _closeCommand;
        [Browsable(false)]
        public System.Windows.Input.ICommand CloseCommand
        {
            get { return _closeCommand; }
            private set
            {
                _closeCommand = value;
            }
        }


        public bool HasDevice
        {
            get
            {
                bool hasDev = false;
                if (_deviceFactory != null)
                {
                    hasDev = (_deviceFactory.Device != null);
                }
                return hasDev;
            }
        }


        private bool _enabled = true;
        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
                RaiseNotifyPropertyChanged();
            }
        }

        public abstract Image ViewImage { get; }

        public virtual string Name { get; }

        public abstract IDeviceConnectionSettingsViewModel DeviceConnectionSettingsViewModel { get; }

        private string _openFailedErrorMessage;
        public string OpenFailedErrorMessage
        {
            get
            {
                return _openFailedErrorMessage;
            }
            private set
            {
                _openFailedErrorMessage = value;
                RaiseNotifyPropertyChanged();
            }
        }

        public BaseConnectionViewModel(IDeviceStateMachine deviceStateMachine) : base(deviceStateMachine)
        {
            OpenCommand = new RelayCommand(param => this.OpenButtonEnabled, OpenCommandHandler);
            CloseCommand = new RelayCommand(param => this.CloseButtonEnabled, CloseCommandHandler);
            _deviceFactory = GetDeviceFactory();
            //DeviceProvider = _deviceFactory;
        }

        public abstract IDeviceFactory GetDeviceFactory();

        private void OpenCommandHandler(object obj)
        {
            _deviceFactory.CreateDevice();
            Device = _deviceFactory.Device;
            try
            {
                Device.Open();
            }
            catch (Exception ex)
            {
                OpenFailedErrorMessage = ex.Message;
                Device.SafeClose();
            }
        }

        private void CloseCommandHandler(object obj)
        {
            Device.Close();
        }

        protected override void OnDeviceStateChanged()
        {
            // we can open the device if its not open
            OpenButtonEnabled = (DeviceState == DeviceState.AssignedDevice || DeviceState == DeviceState.NoDevice);
            // we can close the device if its open
            CloseButtonEnabled = (DeviceState == DeviceState.OpenedDevice);
        }

    }
}
