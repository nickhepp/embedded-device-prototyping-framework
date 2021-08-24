using Ecs.Edpf.GUI.UI.ViewModels;
using Ecs.Edpf.GUI.UI.ViewModels.Charting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Ecs.Edpf.GUI.UI.Views
{
    public partial class ChartingView : UserControl, IChildView
    {

        private IChartingViewModel _chartingViewModel = null;

        public IChildViewModel ViewModel
        {
            get
            {
                return _chartingViewModel;
            }
            set
            {
                if (_chartingViewModel != null)
                {
                    _chartingViewModel.PropertyChanged -= ChartingViewModel_PropertyChanged;
                }


                _chartingViewModel = value as IChartingViewModel;
                InitializeSubComponents();
                ShowHideSettings();

                if (_chartingViewModel != null)
                {
                    _chartingViewModel.ChartNamesToSettingsChanged += ChartingViewModel_ChartNamesToSettingsChanged;
                    _chartingViewModel.ChartSamplesCollected += ChartingViewModel_ChartSamplesCollected;
                }

            }
        }

        private void ChartingViewModel_ChartSamplesCollected(object sender, Dictionary<string, Devices.Charting.ChartSample> e)
        {
            foreach (string seriesName in e.Keys)
            {
                int seriesIdx = _mainChrt.Series.IndexOf(seriesName);
                if (seriesIdx != -1)
                {
                    Devices.Charting.ChartSample chartSample = e[seriesName];
                    _mainChrt.Series[seriesIdx].Points.Add(new DataPoint(chartSample.XNumberValue.Value, chartSample.YValue));
                }
            }
            
        }

        private void ChartingViewModel_ChartNamesToSettingsChanged(object sender, EventArgs e)
        {
            InitializeSeries();
        }

        public ChartingView()
        {
            InitializeComponent();

            // clear the example that is there
            _mainChrt.Series.Clear();

            InitializeSubComponents();
            ShowHideSettings();

            _showSettingsTsb.CheckedChanged += _showSettingsTsb_CheckedChanged;

        }

        private void _showSettingsTsb_CheckedChanged(object sender, EventArgs e)
        {
            _chartingViewModel.ShowSettings = _showSettingsTsb.Checked;
        }

        private void InitializeSubComponents()
        {
            if (_chartingViewModel == null)
            {
                _chartSettingsPpg.SelectedObject = null;
            }
            else
            {
                _chartSettingsPpg.SelectedObject = _chartingViewModel.SettingsViewModel;
                _chartingViewModel.PropertyChanged += ChartingViewModel_PropertyChanged;
                InitializeSeries();
            }
        }

        private void InitializeSeries()
        {
            const string chartAreaName = "chart-area";
            ChartArea chartArea;
            if (_mainChrt.ChartAreas.Count == 0)
            {
                chartArea = new ChartArea(chartAreaName);
                _mainChrt.ChartAreas.Add(chartArea);
                chartArea.AxisX = new Axis
                {
                    Enabled = AxisEnabled.Auto,
                };
            }
            else
            {
                chartArea = _mainChrt.ChartAreas[0];
            }

            // add series that need to be added
            foreach (string seriesName in _chartingViewModel.ChartNamesToSettings.Keys)
            {
                Series series;
                int seriesIdx = _mainChrt.Series.IndexOf(seriesName);
                if (seriesIdx == -1)
                {
                    series = new Series(seriesName)
                    {
                        ChartArea = chartArea.Name,
                        Enabled = true,
                        ChartType = SeriesChartType.Line,
                    };
                    _mainChrt.Series.Add(series);
                }
                //else
                //{
                //    series = _mainChrt.Series[seriesIdx];
                //}
                
            }

            // remove series that are no longer needed
            List<string> extraSeriesNames = _mainChrt.Series.Select(series => series.Name).Except(_chartingViewModel.ChartNamesToSettings.Keys).ToList();
            foreach (string extraSeriesName in extraSeriesNames)
            {
                _mainChrt.Series.Remove(_mainChrt.Series.FindByName(extraSeriesName));
            }

        }



        private void ShowHideSettings()
        {
            if (_chartingViewModel != null)
            {
                if (_chartingViewModel.ShowSettings && 
                    ((_mainPnl.Controls.Count != 1) || 
                    !object.ReferenceEquals(_mainPnl.Controls[0], _mainSpl)))
                {
                    // set the splitter as the main control
                    _mainPnl.Controls.Clear();
                    _mainPnl.Controls.Add(_mainSpl);
                    _mainSpl.Dock = DockStyle.Fill;

                    // add the chart to the left splitter
                    _mainSpl.Panel1.Controls.Clear();
                    _mainSpl.Panel1.Controls.Add(_chartPnl);
                    _chartPnl.Dock = DockStyle.Fill;
                }
                else if (!_chartingViewModel.ShowSettings &&
                    ((_mainPnl.Controls.Count != 1) ||
                    !object.ReferenceEquals(_mainPnl.Controls[0], _chartPnl)))
                {
                    // remove the chart from the left split panel
                    _mainSpl.Panel1.Controls.Clear();

                    // make the chart the main control
                    _mainPnl.Controls.Clear();
                    _mainPnl.Controls.Add(_chartPnl);
                    _chartPnl.Dock = DockStyle.Fill;
                }
            }
            else
            {
                _mainPnl.Controls.Clear();
            }
        }

        private void ChartingViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IChartingViewModel.ShowSettings))
            {
                ShowHideSettings();
            }
        }

    }
}
