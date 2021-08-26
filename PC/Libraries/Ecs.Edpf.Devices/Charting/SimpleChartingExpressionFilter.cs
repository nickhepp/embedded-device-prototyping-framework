using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecs.Edpf.Devices.Charting
{
    public class SimpleChartingExpressionFilter : IChartingExpressionFilter
    {

        public const string UnexpectedExpressionFormatErrorMessage = "Unexpected Expression format.  Simple Expression strings are of the following format: " +
            "'value_prefix:{series-1|chart-1},{series-2|chart-2},{series-n|chart-n}'";


        public const string ValueSeparatorToken = ":";

        public const string SeriesAndChartNameBeginToken = "{";

        public const string SeriesAndChartNameEndToken = "}";

        public const string ValuesSeparatorToken = ",";

        public const string SeriesChartNameSeparatorToken = "|";

        private Lazy<Dictionary<string, string>> _chartSeriesToChartNames;

        private Lazy<string> _chartValuesPrefix;

        private string _expression;

        public event EventHandler ExpressionChanged;

        public string Expression
        {
            get
            {
                return _expression;
            }
            set
            {
                _expression = value;
                InitializeGetters();
                RaiseExpressionChanged();
            }
        }

        public SimpleChartingExpressionFilter()
        {
            InitializeGetters();
        }


        private void RaiseExpressionChanged()
        {
            if (ExpressionChanged != null)
            {
                ExpressionChanged(this, new EventArgs());
            }
        }

        private void InitializeGetters()
        {
            _chartValuesPrefix = new Lazy<string>(() =>
            {
                if (string.IsNullOrEmpty(Expression))
                {
                    throw new Exception(UnexpectedExpressionFormatErrorMessage);
                }

                List<string> splitVals = Expression.Split(new string[] { ValueSeparatorToken }, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (splitVals.Count != 2)
                {
                    throw new Exception(UnexpectedExpressionFormatErrorMessage);
                }

                return splitVals[0];
            });

            _chartSeriesToChartNames = new Lazy<Dictionary<string, string>>(() =>
            {
                string prefix = _chartValuesPrefix.Value + ValueSeparatorToken;
                string seriesAndChartsNamesPart = Expression.Substring(prefix.Length);
                List<string> seriesAndChartsNamesParts = seriesAndChartsNamesPart.Split(new string[] { ValuesSeparatorToken }, StringSplitOptions.RemoveEmptyEntries).ToList();

                Dictionary<string, string> seriesAndChartsNames = new Dictionary<string, string>();
                foreach (string seriesAndChartNamePart in seriesAndChartsNamesParts)
                {
                    if ((seriesAndChartNamePart.Length < (SeriesAndChartNameBeginToken.Length + SeriesAndChartNameEndToken.Length + 1)) ||
                            (seriesAndChartNamePart.Substring(0, SeriesAndChartNameBeginToken.Length) != SeriesAndChartNameBeginToken) ||
                            (seriesAndChartNamePart.Substring(seriesAndChartNamePart.Length - 1, 1) != SeriesAndChartNameEndToken))
                    {
                        throw new Exception(UnexpectedExpressionFormatErrorMessage);
                    }

                    int seriesAndChartNameLength = seriesAndChartNamePart.Length - SeriesAndChartNameBeginToken.Length - SeriesAndChartNameEndToken.Length;
                    string seriesAndChartName = seriesAndChartNamePart.Substring(SeriesAndChartNameBeginToken.Length, seriesAndChartNameLength);

                    List<string> seriesChartParts = seriesAndChartName.Split(new string[] { SeriesChartNameSeparatorToken }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    if (seriesChartParts.Count != 2)
                    {
                        throw new Exception(UnexpectedExpressionFormatErrorMessage);
                    }

                    seriesAndChartsNames[seriesChartParts[0]] = seriesChartParts[1];
                }

                return seriesAndChartsNames;
            });
        }

        public Dictionary<string, double> GetChartPoints(string lineWithPoints)
        {

            Dictionary<string, double> valPoints = null;


            string valsPrefix = _chartValuesPrefix.Value + ValueSeparatorToken;
            if (!string.IsNullOrEmpty(lineWithPoints) &&
                (lineWithPoints.Length > valsPrefix.Length) &&
                lineWithPoints.StartsWith(valsPrefix))
            {
                // at least the beginning is good, see if we can decompose the parts
                List<string> valParts = lineWithPoints.Substring(valsPrefix.Length).Split(new string[] { ValuesSeparatorToken }, StringSplitOptions.RemoveEmptyEntries).ToList();

                List<string> chartValueNames = GetSeriesNames();
                if (valParts.Count == chartValueNames.Count)
                {
                    Dictionary<string, double> tempDictBuilder = new Dictionary<string, double>();
                    for (int kValPartIndex = 0; (kValPartIndex < chartValueNames.Count) && (tempDictBuilder != null); kValPartIndex++)
                    {
                        if (double.TryParse(valParts[kValPartIndex], out double parsedVal))
                        {
                            tempDictBuilder[chartValueNames[kValPartIndex]] = parsedVal;
                        }
                        else
                        {
                            // we didnt successfully parse a float, exit out of the loop
                            tempDictBuilder = null;
                        }
                    }

                    // either reassign the dictionary to a filled out one, or null for an issue
                    valPoints = tempDictBuilder;
                }
            }

            return valPoints;
        }

        public List<string> GetSeriesNames()
        {
            return _chartSeriesToChartNames.Value.Keys.ToList();
        }

        public List<string> GetChartAreaNames()
        {
            return _chartSeriesToChartNames.Value.Values.Distinct().ToList();
        }

        public string GetChartAreaNameBySeries(string series)
        {
            return _chartSeriesToChartNames.Value[series];
        }



    }
}
