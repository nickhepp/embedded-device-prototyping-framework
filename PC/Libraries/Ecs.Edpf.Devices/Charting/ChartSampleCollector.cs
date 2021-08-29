using Ecs.Edpf.Devices.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ecs.Edpf.Devices.Charting
{
    public class ChartSampleCollector : IChartSampleCollector
    {
        private readonly ChartSettings _chartSettings;

        private IChartingExpressionFilter _chartingExpressionFilter;

        private IDateTimeProvider _dateTimeProvider;

        private int _sampleCount = 0;


        public event EventHandler<Dictionary<string, ChartSample>> ChartSamplesCollected;

        public event PropertyChangedEventHandler PropertyChanged;

        public Dictionary<string, List<ChartSample>> SeriesSamples { get; private set; }



        public ChartSampleCollector(IChartingExpressionFilter chartingExpressionFilter,
            ChartSettings chartSettings,
            IDateTimeProvider dateTimeProvider)
        {
            _chartingExpressionFilter = chartingExpressionFilter;
            _chartSettings = chartSettings;
            _dateTimeProvider = dateTimeProvider;

            _chartSettings.PropertyChanged += ChartSettingsPropertyChanged;
            UpdateChartSamplesContainer();
        }

        private void UpdateChartSamplesContainer()
        {
            try
            {
                _chartingExpressionFilter.Expression = _chartSettings.Expression;
                List<string> seriesNames = _chartingExpressionFilter.GetSeriesNames();

                SeriesSamples = new Dictionary<string, List<ChartSample>>();
                foreach (string seriesName in seriesNames)
                {
                    SeriesSamples[seriesName] = new List<ChartSample>();
                }
            }
            catch (Exception ex)
            {
                ex = ex; // TODO: add logging
                SeriesSamples = new Dictionary<string, List<ChartSample>>();
            }

            RaiseNotifyPropertyChanged(nameof(SeriesSamples));

        }

        private void RaiseNotifyPropertyChanged([CallerMemberName]string propName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        
        private void ChartSettingsPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ChartSettings.Expression))
            {
                UpdateChartSamplesContainer();
            }
        }

        public void AddPossibleSampleLine(string line)
        {
            Dictionary<string, double> values = _chartingExpressionFilter.GetChartPoints(line);
            if (values != null)
            {
                _sampleCount++;
                Dictionary<string, ChartSample> chartSamples = new Dictionary<string, ChartSample>();

                //if (_chartSettings.XAxisType == XAxisType.SampleNumber)
                //{
                foreach (KeyValuePair<string, double> value in values)
                {
                    chartSamples[value.Key] = new ChartSample { XNumberValue = _sampleCount, YValue = value.Value };
                }
                //}
                //else if (_chartSettings.XAxisType == XAxisType.Time)
                //{
                //    foreach (KeyValuePair<string, double> value in values)
                //    {
                //        chartSamples[value.Key] = new ChartSample
                //        {
                //            XTimestampValue = _dateTimeProvider.GetCurrentDateTime(),
                //            YValue = value.Value
                //        };
                //    }
                //}

                if (ChartSamplesCollected != null)
                {
                    ChartSamplesCollected(this, chartSamples);
                }

            }
        }
    }
}
