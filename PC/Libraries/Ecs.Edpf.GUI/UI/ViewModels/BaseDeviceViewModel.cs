using System;
using System.ComponentModel;

using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.Devices;
using Ecs.Edpf.GUI.ComponentModel;

namespace Ecs.Edpf.GUI.UI.ViewModels
{
    public abstract class BaseDeviceViewModel : BaseViewModel, IDeviceViewModel
    {

        private DeviceStateMachine _deviceStateMachine;
        protected DeviceState DeviceState => _deviceStateMachine.DeviceState;

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
                    _deviceStateMachine.SendSignal(DeviceSignal.DeviceAssigned);
                    _device.DeviceClosed += DeviceClosed;
                    _device.DeviceOpened += DeviceOpened;
                }
                else
                {
                    if (_device != null)
                    {
                        //_device.DeviceClosed 
                    }


                    _deviceStateMachine.SendSignal(DeviceSignal.DeviceCleared);
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


        public BaseDeviceViewModel()
        {
            _deviceStateMachine = new DeviceStateMachine();
            _deviceStateMachine.DeviceStateChanged += DeviceStateMachineDeviceStateChanged;
        }


        private void DeviceOpened(object sender, EventArgs e)
        {
            _deviceStateMachine.SendSignal(DeviceSignal.DeviceOpened);
        }

        private void DeviceClosed(object sender, EventArgs e)
        {
            _deviceStateMachine.SendSignal(DeviceSignal.DeviceClosed);
        }

        private void DeviceProviderDeviceCreated(object sender, EventArgs e)
        {
            Device = _deviceProvider.Device;
            Device.PropertyChanged += DevicePropertyChanged;
            DeviceOutputBuffer = Device.DeviceOutputBuffer;

        }


        private void DeviceStateMachineDeviceStateChanged(object sender, EventArgs e)
        {
            OnDeviceStateChanged();
        }

        protected virtual void OnDeviceStateChanged()
        {

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
