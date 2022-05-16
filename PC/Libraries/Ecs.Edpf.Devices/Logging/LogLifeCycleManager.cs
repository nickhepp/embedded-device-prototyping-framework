using System;

namespace Ecs.Edpf.Devices.Logging
{
    public class LogLifeCycleManager : ILogLifeCycleManager
    {

        private ILoggerFactory _loggerFactory;
        private ILogger _logger;

        private string _deviceDesc;
        private IDevice _device;

        private IDeviceProvider _deviceProvider;
        public IDeviceProvider DeviceProvider
        {
            get => _deviceProvider;
            set
            {
                _deviceProvider = value;
                if (_deviceProvider != null)
                {
                    _deviceProvider.DeviceCreated += DeviceProvider_DeviceCreated;
                    if (_deviceProvider.Device != null)
                    {
                        _device = _deviceProvider.Device;
                        ResetLogger();
                    }
                }
            }
        }


        public LogLifeCycleManager(
            ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
            
        }

        public void ChangeLoggerSettings()
        {
            ResetLogger();
        }


        private void ResetLogger()
        {
            if (_logger != null)
            {
                _logger.Dispose();
            }
            _logger = _loggerFactory.GetLogger();

            if (_device != null)
            {
                _device.DeviceLogger = _logger;
            }
        }


        private void DeviceProvider_DeviceCreated(object sender, EventArgs e)
        {
            _device = _deviceProvider.Device;
            _device.DeviceLogger = _logger;
            _device.DeviceClosed += DeviceClosed;
            _deviceDesc = $"{_device.ConnectionInfo.ConnectionType}-[{_device.ConnectionInfo.ConnectionName}]";
            _logger.LogInformation($"Device created: {_deviceDesc}");
        }

        private void DeviceClosed(object sender, EventArgs e)
        {
            _logger.LogInformation($"Device closed: {_deviceDesc}");
            _device.DeviceLogger = null;
        }

    }
}
