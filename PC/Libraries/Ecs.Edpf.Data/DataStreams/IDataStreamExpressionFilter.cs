using System.Collections.Generic;

namespace Ecs.Edpf.Data.DataStreams
{
    public interface IDataStreamExpressionFilter
    {
        string Expression { get; }
        List<string> ValueNames { get; }
        string ValuesPrefix { get; }

        LineResultsSet GetResults(string deviceDataLine);
    }
}