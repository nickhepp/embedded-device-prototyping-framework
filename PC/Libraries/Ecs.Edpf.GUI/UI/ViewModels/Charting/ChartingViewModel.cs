using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.Charting;
using Ecs.Edpf.GUI.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.Charting
{
    public class ChartingViewModel : BaseDeviceViewModel, IChartingViewModel
    {

        private ChartSettings _chartSettings;

        private IChartSampleCollector _chartSampleCollector;


        public event EventHandler<Dictionary<string, ChartSample>> ChartSamplesCollected;

        public event EventHandler ChartNamesToSettingsChanged;

        public IChartingViewSettingsViewModel SettingsViewModel { get; set; }

        public Image ViewImage => throw new NotImplementedException();

        public string Name => "Charting";

        private Dictionary<string, ChartSettings> _pubChartSettings;
        public Dictionary<string, ChartSettings> ChartNamesToSettings
        {
            get
            {
                return _pubChartSettings;
            }
            private set
            {
                _pubChartSettings = value;
                RaiseChartNamesToSettingsChanged();
            }
        }
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

        public ChartingViewModel(IChartSampleCollector chartSampleCollector, 
            ChartSettings chartSettings,
            IDeviceStateMachine deviceStateMachine) : base(deviceStateMachine)
        {
            _chartSampleCollector = chartSampleCollector;
            SettingsViewModel = new ChartingViewSettingsViewModel(chartSettings);
            _chartSettings = chartSettings;
            _chartSettings.PropertyChanged += ChartSettings_PropertyChanged;
            _chartSampleCollector.ChartSamplesCollected += ChartSampleCollector_ChartSamplesCollected;
            _chartSampleCollector.PropertyChanged += ChartSampleCollector_PropertyChanged;
            SetPubChartSettings();
        }

        private void ChartSettings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SetPubChartSettings();
        }

        private void ChartSampleCollector_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IChartSampleCollector.ChartSamples))
            {
                SetPubChartSettings();
            }
        }

        private void SetPubChartSettings()
        {
            Dictionary<string, ChartSettings> chartNamesToSettings = new Dictionary<string, ChartSettings>();
            foreach (string seriesName in _chartSampleCollector.ChartSamples.Keys)
            {
                chartNamesToSettings[seriesName] = _chartSettings;
            }
            ChartNamesToSettings = chartNamesToSettings;
        }


        private void RaiseChartNamesToSettingsChanged()
        {
            if (ChartNamesToSettingsChanged != null)
            {
                ChartNamesToSettingsChanged(this, new EventArgs());
            }
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
                    _chartSampleCollector.AddPossibleSampleLine(possibleValLine);
                }
            }
        }



    }
}
