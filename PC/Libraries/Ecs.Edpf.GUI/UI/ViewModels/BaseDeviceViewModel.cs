﻿using System;
using System.ComponentModel;
using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.ComponentModel;

namespace Ecs.Edpf.GUI.UI.ViewModels
{
    public abstract class BaseDeviceViewModel : BaseViewModel, IDeviceViewModel
    {

        private IDeviceStateMachine _deviceStateMachine;
        protected DeviceState DeviceState => _deviceStateMachine.DeviceState;

        private IDevice _device;

        public IDevice Device { 
            get
            {
                return _device;
            }
            protected set
            {
                _device = value;
                if (_device != null)
                {
                    _deviceStateMachine.SendSignal(DeviceSignal.DeviceAssigned);
                    _device.DeviceClosed += DeviceClosed;
                    _device.DeviceSafeClosed += DeviceSafeClosed;
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
            }
        }


        private IDeviceProvider _deviceProvider;
        public virtual IDeviceProvider DeviceProvider
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


        public BaseDeviceViewModel(IDeviceStateMachine deviceStateMachine)
        {
            _deviceStateMachine = deviceStateMachine;
            _deviceStateMachine.DeviceStateChanged += DeviceStateMachineDeviceStateChanged;
        }


        private void DeviceOpened(object sender, EventArgs e)
        {
            _deviceStateMachine.SendSignal(DeviceSignal.DeviceOpened);
        }

        private void DeviceClosed(object sender, EventArgs e)
        {
            _deviceStateMachine.SendSignal(DeviceSignal.DeviceClosed);
            Device = null;
        }

        private void DeviceSafeClosed(object sender, EventArgs e)
        {
            _deviceStateMachine.SendSignal(DeviceSignal.DeviceSafeClosed);
            Device = null;
        }

        private void DeviceProviderDeviceCreated(object sender, EventArgs e)
        {
            Device = _deviceProvider.Device;
            DeviceOutputBuffer = Device.DeviceOutputBuffer;
        }


        private void DeviceStateMachineDeviceStateChanged(object sender, EventArgs e)
        {
            OnDeviceStateChanged();
        }

        protected virtual void OnDeviceStateChanged()
        {

        }

    }
}
