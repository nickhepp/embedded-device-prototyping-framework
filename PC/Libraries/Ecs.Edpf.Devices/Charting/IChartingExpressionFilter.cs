using System.Collections.Generic;

namespace Ecs.Edpf.Devices.Charting
{
    public interface IChartingExpressionFilter
    {
        string Expression { get; set; }

        Dictionary<string, double> GetChartPoints(string lineWithPoints);
        List<string> GetChartValueNames();
    }
}