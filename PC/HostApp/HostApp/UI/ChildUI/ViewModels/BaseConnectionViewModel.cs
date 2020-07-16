using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HostApp.Business;
using HostApp.ComponentModel;
using HostApp.UI.ChildUI.ViewModels;

namespace HostApp.UI.ChildUI
{
    public abstract class BaseConnectionViewModel : BaseDeviceViewModel
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

        public ICommand OpenConnectionCommand { get; private set; }



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



        public BaseConnectionViewModel()
        {
            OpenConnectionCommand = new RelayCommand(obj => OpenConnectionCommandCanExecute(obj), obj => OpenConnectionCommandHandler(obj));

            OpenCommand = new RelayCommand(param => this.OpenButtonEnabled, OpenCommandHandler);
            CloseCommand = new RelayCommand(param => this.CloseButtonEnabled, CloseCommandHandler);

        }

        protected abstract bool OpenConnectionCommandCanExecute(object obj);

        private void OpenConnectionCommandHandler(object obj)
        {
            //Device.
        }


        private void DevicePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IDevice.IsOpen))
            {
                OpenButtonEnabled = !Device.IsOpen;
                CloseButtonEnabled = Device.IsOpen;
            }
        }

        private void OpenCommandHandler(object obj)
        {
            Device.Open();
        }

        private void CloseCommandHandler(object obj)
        {
            Device.Close();
        }


    }
}
