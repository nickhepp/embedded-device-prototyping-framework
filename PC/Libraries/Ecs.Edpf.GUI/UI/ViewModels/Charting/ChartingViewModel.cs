using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.Charting;
using Ecs.Edpf.Devices.ComponentModel;
using Ecs.Edpf.GUI.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace Ecs.Edpf.GUI.UI.ViewModels.Charting
{
    public class ChartingViewModel : BaseDeviceViewModel, IChartingViewModel
    {

        private ChartSettings _chartSettings;

        public IChartSampleCollector ChartSampleCollector { get; private set;  }


        public IChartingExpressionFilter ChartingExpressionFilter { get; private set; }


        public event EventHandler<Dictionary<string, ChartSample>> ChartSamplesCollected;

        public IChartingViewSettingsViewModel SettingsViewModel { get; set; }

        public Image ViewImage => throw new NotImplementedException();

        public string Name => "Charting";

        private bool _showSettings = true;
        public bool ShowSettings 
        { 
            get
            {
                return _showSettings;
            }
            set
            {
                _showSettings = value;
                RaiseNotifyPropertyChanged();
            }
        }

        public string ResourceName => "Charting";

        public ChartingViewModel(IChartSampleCollector chartSampleCollector,
            IChartingExpressionFilter chartingExpressionFilter,
            IChartProvider chartProvider,
            ChartSettings chartSettings,
            IDeviceStateMachine deviceStateMachine) : base(deviceStateMachine)
        {
            ChartSampleCollector = chartSampleCollector;
            ChartingExpressionFilter = chartingExpressionFilter;
            SettingsViewModel = new ChartingViewSettingsViewModel(chartProvider, chartSettings);
            _chartSettings = chartSettings;
            ChartSampleCollector.ChartSamplesCollected += ChartSampleCollector_ChartSamplesCollected;
        }

        private void ChartSampleCollector_ChartSamplesCollected(object sender, Dictionary<string, ChartSample> e)
        {
            if (ChartSamplesCollected != null)
            {
                ChartSamplesCollected(this, e);
            }
        }

        private IDevice _currentDevice;
        protected override void OnDeviceStateChanged()
        {

            if (DeviceState == DeviceState.OpenedDevice)
            {
                // drop any refs to old devices
                if (_currentDevice != null)
                {
                    _currentDevice.DeviceOutputBuffer.ListChanged -= DeviceOutputBufferListChanged;
                }
                // latch on the to the newest device
                _currentDevice = Device;
                _currentDevice.DeviceOutputBuffer.ListChanged += DeviceOutputBufferListChanged;
            }

        }

        private void DeviceOutputBufferListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                string newLinesStr = _currentDevice.DeviceOutputBuffer[e.NewIndex];
                List<string> possibleValLines = newLinesStr.Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (string possibleValLine in possibleValLines)
                {
                    ChartSampleCollector.AddPossibleSampleLine(possibleValLine);
                }
            }
        }

        private const string MaxDisplaySampleCountSettingsName = "ChartingSettings.MaxDisplaySampleCount";
        private const string ExpressionSettingsName = "ChartSettings.Expression";

        public Dictionary<string, string> GetSettings()
        {
            Dictionary<string, string> settings = new Dictionary<string, string>
            {
                { MaxDisplaySampleCountSettingsName, _chartSettings.MaxDisplaySampleCount.ToString() },
                { ExpressionSettingsName, _chartSettings.Expression },
            };

            return settings;
        }

        public void ApplySettings(Dictionary<string, string> settings)
        {
            uint? maxSampleDisplayCount = SettingsExtractor.GetUIntSettingByName(settings, MaxDisplaySampleCountSettingsName);
            if (maxSampleDisplayCount.HasValue)
            {
                _chartSettings.MaxDisplaySampleCount = maxSampleDisplayCount.Value;
            }
            if (settings.ContainsKey(ExpressionSettingsName))
            {
                _chartSettings.Expression = settings[ExpressionSettingsName];
            }
            
        }

        public void ApplyDefaultSettings()
        {
        }

    }
}
