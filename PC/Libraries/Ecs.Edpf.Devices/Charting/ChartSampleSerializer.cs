using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Ecs.Edpf.Devices.Charting
{
    /// <summary>
    /// Serializes chart samples.
    /// </summary>
    public class ChartSampleSerializer
    {

        /// <summary>
        /// Saves the samples to file.
        /// </summary>
        /// <param name="sampleCollector"></param>
        /// <param name="file"></param>
        public void SaveSamplesToCsvFile(IChartSampleCollector sampleCollector, FileInfo file)
        {
            using (FileStream fsStream = new FileStream(file.FullName, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter streamWriter = new StreamWriter(fsStream, encoding: Encoding.ASCII))
                {
                    // ============== write the header
                    List<string> seriesNames = sampleCollector.SeriesSamples.Keys.ToList();
                    List<string> headerNames = new List<string>(seriesNames);
                    headerNames.Insert(0, "SampleNumber");
                    string csvHeader = string.Join(",", headerNames);
                    streamWriter.WriteLine(csvHeader);

                    // ============== write the values
                    List<ChartSample> firstSeries = sampleCollector.SeriesSamples.First().Value;
                    int sampleCnt = firstSeries.Count;

                    for (int sIdx = 0; sIdx < sampleCnt; sIdx++)
                    {
                        // build the list of samples
                        double sampleXVal = firstSeries[sIdx].XNumberValue.Value;
                        List<double> vals = new List<double> { sampleXVal };
                        foreach (string seriesName in seriesNames)
                        {
                            vals.Add(sampleCollector.SeriesSamples[seriesName][sIdx].YValue);
                        }
                        streamWriter.WriteLine(string.Join(",", vals));
                    }

                }
            }


        }


    }
}
