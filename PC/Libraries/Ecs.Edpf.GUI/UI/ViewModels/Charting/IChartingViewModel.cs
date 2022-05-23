using Ecs.Edpf.Devices.Charting;
using Ecs.Edpf.Devices.Devices;
using Ecs.Edpf.GUI.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.Charting
{

    public interface IChartingViewModel : IChildViewModel, IDeviceProviderListener, ISettingsResource
    {

        IChartSampleCollector ChartSampleCollector { get; }

        IChartingExpressionFilter ChartingExpressionFilter { get; }

        IChartingViewSettingsViewModel SettingsViewModel { get; set; }

        bool ShowSettings { get; set; }

        event EventHandler<Dictionary<string, ChartSample>> ChartSamplesCollected;

    }

}
