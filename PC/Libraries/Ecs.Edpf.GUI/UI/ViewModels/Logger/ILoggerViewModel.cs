using Ecs.Edpf.Devices.Devices;
using Ecs.Edpf.GUI.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.Logger
{
    public interface ILoggerViewModel :  IDeviceViewModel, IDeviceProviderListener
    {

        IRelayCommand SaveLoggerSettingsCommand { get; }

        ILoggerSettingsViewModel SettingsViewModel { get; }

    }
}
