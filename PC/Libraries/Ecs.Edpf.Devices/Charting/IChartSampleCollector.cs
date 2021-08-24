using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Ecs.Edpf.Devices.Charting
{
    public interface IChartSampleCollector : INotifyPropertyChanged
    {

        Dictionary<string, List<ChartSample>> ChartSamples { get; }

        event EventHandler<Dictionary<string, ChartSample>> ChartSamplesCollected;

        void AddPossibleSampleLine(string line);
    }
}