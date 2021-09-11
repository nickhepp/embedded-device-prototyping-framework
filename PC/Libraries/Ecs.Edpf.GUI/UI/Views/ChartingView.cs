using Ecs.Edpf.Devices.Charting;
using Ecs.Edpf.GUI.UI.ViewModels;
using Ecs.Edpf.GUI.UI.ViewModels.Charting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Ecs.Edpf.GUI.UI.Views
{
    public partial class ChartingView : UserControl, IChildView, IChartProvider
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
                    //_chartingViewModel.ChartNamesToSettingsChanged += ChartingViewModel_ChartNamesToSettingsChanged;
                    _chartingViewModel.ChartSamplesCollected += ChartingViewModel_ChartSamplesCollected;
                    _chartingViewModel.ChartingExpressionFilter.ExpressionChanged += ChartingExpressionFilter_ExpressionChanged;
                }

            }
        }

        private void ChartingExpressionFilter_ExpressionChanged(object sender, EventArgs e)
        {
            InitializeChart();
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
                InitializeChart();
            }
        }

        private void InitializeChart()
        {
            // add new chart areas
            foreach (string chartAreaName in _chartingViewModel.ChartingExpressionFilter.GetChartAreaNames())
            {
                int chartIdx = _mainChrt.ChartAreas.IndexOf(chartAreaName);
                if (chartIdx == -1)
                {
                    ChartArea chartArea = new ChartArea(chartAreaName);
                    _mainChrt.ChartAreas.Add(chartAreaName);
                }
            }



            // add series that need to be added
            foreach (string seriesName in _chartingViewModel.ChartingExpressionFilter.GetSeriesNames())
            {
                string chartName = _chartingViewModel.ChartingExpressionFilter.GetChartAreaNameBySeries(seriesName);
                Series series; 
                int seriesIdx = _mainChrt.Series.IndexOf(seriesName);
                if (seriesIdx == -1)
                {
                    series = new Series(seriesName)
                    {
                        Enabled = true,
                        ChartType = SeriesChartType.Line,
                        BorderWidth = 4
                    };
                    _mainChrt.Series.Add(series);
                }
                else
                {
                    series = _mainChrt.Series[seriesIdx];
                }
                series.ChartArea = chartName;
            }

            // remove series that are no longer needed
            List<string> extraSeriesNames = _mainChrt.Series.Select(series => series.Name).Except(_chartingViewModel.ChartingExpressionFilter.GetSeriesNames()).ToList();
            foreach (string extraSeriesName in extraSeriesNames)
            {
                _mainChrt.Series.Remove(_mainChrt.Series.FindByName(extraSeriesName));
            }

            //remove chart areas that are no longer needed
            List<string> extraChartAreaNames = _mainChrt.ChartAreas.Select(chartArea => chartArea.Name).Except(_chartingViewModel.ChartingExpressionFilter.GetChartAreaNames()).ToList();
            foreach (string extraChartArea in extraChartAreaNames)
            {
                _mainChrt.ChartAreas.Remove(_mainChrt.ChartAreas.FindByName(extraChartArea));
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

        public Chart GetChart()
        {
            return _mainChrt;
        }

        private void _saveSettingsTsb_Click(object sender, EventArgs e)
        {

        }

        private void _loadSettingsTsb_Click(object sender, EventArgs e)
        {

        }

        private void _downloadDataTsb_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            const string CsvFileExtension = ".csv";
            const string XmlFileExtension = ".xml";

            sfd.Filter = $"CSV file (*{CsvFileExtension})|*{CsvFileExtension}|XML file (*{XmlFileExtension}| *{XmlFileExtension}";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (sfd.FileName.EndsWith(CsvFileExtension, StringComparison.OrdinalIgnoreCase))
                {
                    FileInfo file = new FileInfo(sfd.FileName);
                    ChartSampleSerializer chartSampleSerializer = new ChartSampleSerializer();
                    chartSampleSerializer.SaveSamplesToCsvFile(_chartingViewModel.ChartSampleCollector, file);
                }
                else
                {
                    using (FileStream fStream = new FileStream(sfd.FileName, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        _mainChrt.Serializer.Content = SerializationContents.Data;
                        _mainChrt.Serializer.Save(fStream);
                    }
                }

                try
                {
                    Process.Start(sfd.FileName);
                }
                catch (Exception)
                {
                    // TODO: add logging
                }


            }



        }
    }
}
