using System;
using System.ComponentModel;

using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.Devices;

namespace Ecs.Edpf.GUI.UI.ViewModels
{
    public abstract class BaseDeviceViewModel : BaseViewModel, IDeviceViewModel
    {

        private IDevice _device;

        public IDevice Device { 
            get
            {
                return _device;
            }
            set
            {
                _device = value;
                if (_device != null)
                {
                    _device.PropertyChanged += DevicePropertyChanged;
                }
                if (DeviceOutputBufferChanged != null)
                {
                    DeviceOutputBufferChanged(this, new EventArgs());
                }
                OnDeviceChanged(_device);
            }
        }

        private IDeviceProvider _deviceProvider;
        public IDeviceProvider DeviceProvider
        {
            get
            {
                return _deviceProvider;
            }
            set
            {
                _deviceProvider = value;
                if (_deviceProvider != null)
                {
                    _deviceProvider.DeviceCreated += DeviceProviderDeviceCreated;
                }
            }
        }

        private void DeviceProviderDeviceCreated(object sender, EventArgs e)
        {
            Device = _deviceProvider.Device;
            Device.PropertyChanged += DevicePropertyChanged;
            DeviceOutputBuffer = Device.DeviceOutputBuffer;
        }





        public event EventHandler DeviceOutputBufferChanged;

        private BindingList<string> _deviceOutputBuffer = new BindingList<string>();
        [Browsable(false)]
        public BindingList<string> DeviceOutputBuffer 
        { 
            get
            {
                return _deviceOutputBuffer;
            }
            private set
            {
                _deviceOutputBuffer = value;
                if (DeviceOutputBufferChanged != null)
                {
                    DeviceOutputBufferChanged(this, new EventArgs());
                }
            }
        }


        protected abstract void OnDeviceChanged(IDevice device);

        protected abstract void InternalDevicePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e);

        private void DevicePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // leave it to the view model specific control as to how it wants to react to device changes
            InternalDevicePropertyChanged(sender, e);
        }

    }
}
