using System;
using System.ComponentModel;

using Ecs.Edpf.Devices;

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

        private IDeviceFactory _deviceFactory;
        public IDeviceFactory DeviceFactory
        {
            get
            {
                return _deviceFactory;
            }
            set
            {
                _deviceFactory = value;
                if (_deviceFactory != null)
                {
                    _deviceFactory.DeviceCreated += DeviceFactoryDeviceCreated;
                }
            }
        }

        private void DeviceFactoryDeviceCreated(object sender, EventArgs e)
        {
            Device = _deviceFactory.Device;
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
