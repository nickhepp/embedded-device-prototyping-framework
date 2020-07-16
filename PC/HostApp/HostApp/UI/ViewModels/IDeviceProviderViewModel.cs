using HostApp.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HostApp.UI.ViewModels
{
    public interface IDeviceProviderViewModel
    {

        IDevice Device { get; }

        ICommand OpenDeviceCommand { get; }

        ICommand CloseDeviceCommand { get;  }

        event EventHandler DeviceConnected;

    }
}
