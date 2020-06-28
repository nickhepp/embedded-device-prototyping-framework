using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HostApp.Business;
using HostApp.ComponentModel;
using HostApp.UI.ChildUI;

namespace HostApp.UI
{
    public class BaseKernelViewModel : BaseViewModel, IChildViewModelProvider
    {
        private IBaseKernelDevice _baseKernelDevice;
        private IDeviceWithConnectionInfo _deviceWithConnectionInfo;
        private IDeviceWithTimeouts _deviceWithTimeouts;

        public const string DeviceConnectionCategory = Constants.Tab01 + "Device Connection";


        [Category(DeviceConnectionCategory)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public DeviceConnectionInfo ConnectionInfo {
            get => _deviceWithConnectionInfo.ConnectionInfo;
            set => _deviceWithConnectionInfo.ConnectionInfo = value;
        }

        [Category(DeviceConnectionCategory)]
        public int CommandTimeout
        {
            get => _deviceWithTimeouts.CommandTimeout;
            set => _deviceWithTimeouts.CommandTimeout = value;
        }

        [Category(DeviceConnectionCategory)]
        [DisplayName("ConnectionInfo")]
        public string ReadOnlyDeviceConnectionInfo
        {
            get => $"{ConnectionInfo}, Timeout: {CommandTimeout}";
        }

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

        public BaseKernelViewModel() : base()
        {
            _deviceWithConnectionInfo = GetDevice() as IDeviceWithConnectionInfo;
            if (_deviceWithConnectionInfo == null)
            {
                throw new Exception($"'{GetDevice().GetType().ToString()}' does not implement '{nameof(IDeviceWithConnectionInfo)}'.");
            }

            string comString = System.IO.Ports.SerialPort.GetPortNames().FirstOrDefault();
            _deviceWithConnectionInfo.ConnectionInfo = new DeviceConnectionInfo
            {
                DeviceBaudRate = DeviceConnectionInfo.BaudRate.Baudrate115200,
                DevicePort = comString
            };

            _deviceWithTimeouts = GetDevice() as IDeviceWithTimeouts;
            if (_deviceWithTimeouts == null)
            {
                throw new Exception($"'{GetDevice().GetType().ToString()}' does not implement '{nameof(IDeviceWithTimeouts)}'.");
            }

            _baseKernelDevice = GetDevice() as IBaseKernelDevice;
            if (_baseKernelDevice == null)
            {
                throw new Exception($"'{GetDevice().GetType().ToString()}' does not implement '{nameof(IBaseKernelDevice)}'.");
            }

            RegisterPropertyVisibilityHandlers(new[] { nameof(ConnectionInfo), nameof(CommandTimeout) }, () => !GetDevice().IsOpen);
            RegisterPropertyVisibilityHandler(nameof(ReadOnlyDeviceConnectionInfo), () => GetDevice().IsOpen);

            PrintCommandParamsViewModelCommand =  new RelayCommand(param => true, PrintCommandParamsCommandHandler);
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

        public List<IChildViewModel> GetChildViewModels()
        {
            throw new NotImplementedException();
        }
    }
}
