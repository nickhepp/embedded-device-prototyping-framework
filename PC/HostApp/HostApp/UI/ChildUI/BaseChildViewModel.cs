using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HostApp.Business;

namespace HostApp.UI.ChildUI
{
    public abstract class BaseChildViewModel : IChildViewModel
    {

        private IDevice _device;
        public IDevice Device { get => _device;
            set
            {
                _device = value;
                _device.PropertyChanged += Device_PropertyChanged;

            }
        }

        public abstract string Name { get; }

        
        protected abstract void InternalDevice_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e);

        private void Device_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // leave it to the view model specific control as to how it wants to react to device changes
            InternalDevice_PropertyChanged(sender, e);
        }
    }
}
