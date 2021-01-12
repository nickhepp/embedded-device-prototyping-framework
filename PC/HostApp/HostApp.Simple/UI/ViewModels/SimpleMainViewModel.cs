
using Ecs.Edpf.Devices;
using Ecs.Edpf.GUI.ComponentModel;
using Ecs.Edpf.GUI.UI.ViewModels;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Input;

namespace HostApp.Simple.UI.ViewModels
{
    public class SimpleMainViewModel :  BaseDeviceViewModel, ISimpleMainViewModel
    {

        private IBaseKernelDevice _baseKernelDevice;

        public const string DeviceConnectionCategory = Constants.Tab01 + "Device Connection";


        //[Category(DeviceConnectionCategory)]
        //[TypeConverter(typeof(ExpandableObjectConverter))]
        //public IConnectionInfo ConnectionInfo
        //{
        //    get => _deviceWithConnectionInfo.ConnectionInfo;
        //    set => _deviceWithConnectionInfo.ConnectionInfo = value;
        //}

        //[Category(DeviceConnectionCategory)]
        //public int CommandTimeout
        //{
        //    get => _deviceWithTimeouts.CommandTimeout;
        //    set => _deviceWithTimeouts.CommandTimeout = value;
        //}

        //[Category(DeviceConnectionCategory)]
        //[DisplayName("ConnectionInfo")]
        //public string ReadOnlyDeviceConnectionInfo
        //{
        //    get => $"{ConnectionInfo}, Timeout: {CommandTimeout}";
        //}

        private ICommand _printCommandParamsViewModelCommand;
        [Browsable(false)]
        public System.Windows.Input.ICommand PrintCommandParamsViewModelCommand
        {
            get { return _printCommandParamsViewModelCommand; }
            private set
            {
                _printCommandParamsViewModelCommand = value;
            }
        }


        private ICommand _printRegisteredCommandsViewModelCommand;
        [Browsable(false)]
        public System.Windows.Input.ICommand PrintRegisteredCommandsViewModelCommand
        {
            get { return _printRegisteredCommandsViewModelCommand; }
            private set
            {
                _printRegisteredCommandsViewModelCommand = value;
            }
        }

        public SimpleMainViewModel() : base()
        {
            //_deviceWithConnectionInfo = Device as IDeviceWithConnectionInfo;
            //if (_deviceWithConnectionInfo == null)
            //{
            //    throw new Exception($"'{Device.GetType().ToString()}' does not implement '{nameof(IDeviceWithConnectionInfo)}'.");
            //}

            //string comString = System.IO.Ports.SerialPort.GetPortNames().FirstOrDefault();
            //_deviceWithConnectionInfo.ConnectionInfo = new DeviceConnectionInfo
            //{
            //    DeviceBaudRate = DeviceConnectionInfo.BaudRate.Baudrate115200,
            //    DevicePort = comString
            //};

            //_deviceWithTimeouts = Device as IDeviceWithTimeouts;
            //if (_deviceWithTimeouts == null)
            //{
            //    throw new Exception($"'{Device.GetType().ToString()}' does not implement '{nameof(IDeviceWithTimeouts)}'.");
            //}

            //_baseKernelDevice = Device as IBaseKernelDevice;
            //if (_baseKernelDevice == null)
            //{
            //    throw new Exception($"'{Device.GetType().ToString()}' does not implement '{nameof(IBaseKernelDevice)}'.");
            //}

            //RegisterPropertyVisibilityHandlers(new[] { nameof(ConnectionInfo), nameof(CommandTimeout) }, () => !Device.IsOpen);
            //RegisterPropertyVisibilityHandler(nameof(ReadOnlyDeviceConnectionInfo), () => Device.IsOpen);

            PrintCommandParamsViewModelCommand = new RelayCommand(param => true, PrintCommandParamsCommandHandler);
            PrintRegisteredCommandsViewModelCommand = new RelayCommand(param => true, PrintRegisteredCommandsCommandHandler);
        }

        private void PrintCommandParamsCommandHandler(object obj)
        {
            _baseKernelDevice.ExecuteCommand("printCommandParams");
        }

        private void PrintRegisteredCommandsCommandHandler(object obj)
        {
            _baseKernelDevice.ExecuteCommand("printRegisteredCommands");
        }

        private ConnectionViewModel _connectionViewModel = null;
        public IConnectionViewModel GetConnectionViewModel()
        {
            if (_connectionViewModel == null)
            {
                _connectionViewModel = new ConnectionViewModel();
            }

            return _connectionViewModel;
        }

        private ConsoleControlViewModel _consoleControlViewModel = null;
        public IConsoleControlViewModel GetConsoleControlViewModel()
        {
            if (_consoleControlViewModel == null)
            {
                _consoleControlViewModel = new ConsoleControlViewModel();
            }
            return _consoleControlViewModel;
        }


        protected override void OnDeviceChanged(IDevice device)
        {
            throw new NotImplementedException();
        }

        protected override void InternalDevicePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }



        public class ConnectionViewModel : BaseConnectionViewModel
        {
            public override Image ViewImage => throw new NotImplementedException();

            public override IDeviceConnectionSettingsViewModel DeviceConnectionSettingsViewModel => throw new NotImplementedException();

            protected override IDeviceFactory GetDeviceFactory()
            {
                throw new NotImplementedException();
            }

            protected override void InternalDevicePropertyChanged(object sender, PropertyChangedEventArgs e)
            {
 
            }

       
        }

    }
}