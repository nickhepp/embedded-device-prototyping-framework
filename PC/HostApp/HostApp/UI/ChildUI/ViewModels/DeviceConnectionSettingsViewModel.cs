using Ecs.Edpf.Devices;
using HostApp.ComponentModel;
using HostApp.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HostApp.UI.ChildUI.ViewModels
{

    public abstract class DeviceConnectionSettingsViewModel : BaseChildViewModel, IDeviceProviderViewModel
    {
        public override string Name => "Device Connection";

        private IDevice _device;
        [Browsable(false)]
        public IDevice Device => _device;

        private RelayCommand _openDeviceCommand;
        [Browsable(false)]
        public ICommand OpenDeviceCommand => _openDeviceCommand;

        private RelayCommand _closeDeviceCommand;
        [Browsable(false)]
        public ICommand CloseDeviceCommand => _closeDeviceCommand;

        public DeviceConnectionSettingsViewModel()
        {
            _openDeviceCommand = new RelayCommand(OpenDeviceCommandCanExecute, OpenDeviceCommandHandler);
            _closeDeviceCommand = new RelayCommand(CloseDeviceCommandCanExecute, CloseDeviceCommandHandler);
        }

        protected abstract IDevice GetDevice();

        protected abstract bool OpenDeviceCommandCanExecute(object obj);

        protected abstract void OpenDeviceCommandHandler(object obj);

        protected abstract bool CloseDeviceCommandCanExecute(object obj);


        protected abstract void CloseDeviceCommandHandler(object obj);



        public event EventHandler DeviceConnected;

        //protected override void InternalDevice_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
