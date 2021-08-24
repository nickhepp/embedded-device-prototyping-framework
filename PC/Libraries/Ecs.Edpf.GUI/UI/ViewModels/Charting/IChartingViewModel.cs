using Ecs.Edpf.Devices.Charting;
using Ecs.Edpf.Devices.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.Charting
{

    public interface IChartingViewModel : IChildViewModel, IDeviceProviderListener
    {

        Dictionary<string, ChartSettings> ChartNamesToSettings { get; }

        IChartingViewSettingsViewModel SettingsViewModel { get; set; }

        bool ShowSettings { get; set; }

        event EventHandler ChartNamesToSettingsChanged;

        event EventHandler<Dictionary<string, ChartSample>> ChartSamplesCollected;

    }

}
