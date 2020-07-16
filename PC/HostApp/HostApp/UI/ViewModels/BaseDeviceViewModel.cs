﻿using HostApp.Business;
using HostApp.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.UI.ChildUI.ViewModels
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
                OnDeviceChanged(_device);
            }
        }

        [Browsable(false)]
        public BindingList<string> DeviceOutputBuffer => _device.DeviceOutputBuffer;

        protected abstract void OnDeviceChanged(IDevice device);
        protected abstract void InternalDevicePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e);

        private void DevicePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // leave it to the view model specific control as to how it wants to react to device changes
            InternalDevicePropertyChanged(sender, e);
        }

    }
}
