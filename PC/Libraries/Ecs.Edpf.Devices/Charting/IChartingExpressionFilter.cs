using System;
using System.Collections.Generic;

namespace Ecs.Edpf.Devices.Charting
{
    public interface IChartingExpressionFilter
    {

        event EventHandler ExpressionChanged;

        string Expression { get; set; }

        Dictionary<string, double> GetChartPoints(string lineWithPoints);

        List<string> GetSeriesNames();

        List<string> GetChartAreaNames();

        string GetChartAreaNameBySeries(string series);

    }
}
