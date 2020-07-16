using HostApp.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.UI.ViewModels
{
    /// <summary>
    /// A view model with a device.
    /// </summary>
    public interface IDeviceViewModel
    {


        IDevice Device { get; set; }


        BindingList<string> DeviceOutputBuffer { get; }


    }
}
