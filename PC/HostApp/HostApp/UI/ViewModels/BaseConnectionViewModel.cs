using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ecs.Edpf.Devices;
using HostApp.ComponentModel;
using HostApp.UI.ChildUI.ViewModels;

namespace HostApp.UI.ViewModels
{
    public abstract class BaseConnectionViewModel : BaseDeviceViewModel, IConnectionViewModel
    {
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

        public abstract Image ViewImage { get; }

        public string Name { get; }

        public abstract IDeviceConnectionSettingsViewModel DeviceConnectionSettingsViewModel { get; }

        public BaseConnectionViewModel()
        {
            OpenCommand = new RelayCommand(param => this.OpenButtonEnabled, OpenCommandHandler);
            CloseCommand = new RelayCommand(param => this.CloseButtonEnabled, CloseCommandHandler);
            DeviceFactory = GetDeviceFactory();
        }


        protected abstract IDeviceFactory GetDeviceFactory();

        private void SetButtonEnables()
        {
            // we can open the device if its not open
            OpenButtonEnabled = !Device.IsOpen;
            // we can close the device if its open
            CloseButtonEnabled = Device.IsOpen;
        }

        private void DevicePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IDevice.IsOpen))
            {
                SetButtonEnables();
            }
        }

        private void OpenCommandHandler(object obj)
        {
            DeviceFactory.CreateDevice();

            // device is now set
            Device.DeviceOpened += DeviceOpened;
            Device.DeviceClosed += DeviceClosed;

            Device.Open();
            SetButtonEnables();
        }

        private void CloseCommandHandler(object obj)
        {
            Device.Close();
        }

        protected override void OnDeviceChanged(IDevice device)
        {
            SetButtonEnables();

        }

        private void DeviceClosed(object sender, EventArgs e)
        {
            SetButtonEnables();
        }

        private void DeviceOpened(object sender, EventArgs e)
        {
            SetButtonEnables();
        }









}
}
