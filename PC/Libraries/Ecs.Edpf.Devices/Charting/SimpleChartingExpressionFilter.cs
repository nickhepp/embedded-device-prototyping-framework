using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecs.Edpf.Devices.Charting
{
    public class SimpleChartingExpressionFilter
    {

        public const string UnexpectedExpressionFormatErrorMessage = "Unexpected Expression format.  Simple Expression strings are of the following format: " +
            "'value_prefix:{val1},{val2},{valn}'";


        public const string ValueSeparatorToken = ":";

        public const string ValueNameBeginToken = "{";

        public const string ValueNameEndToken = "}";

        public const string ValuesSeparatorToken = ",";

        private Lazy<List<string>> _chartValueNames;

        private Lazy<string> _chartValuesPrefix;

        public string Expression { get; set; }

        public SimpleChartingExpressionFilter()
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

            _chartValueNames = new Lazy<List<string>>(() =>
            {
                string prefix = _chartValuesPrefix.Value + ValueSeparatorToken;
                string valueNamesPart = Expression.Substring(prefix.Length);
                List<string> valueNameParts = valueNamesPart.Split(new string[] { ValuesSeparatorToken }, StringSplitOptions.RemoveEmptyEntries).ToList();

                List<string> valueNames = new List<string>();
                foreach (string valueNamePart in valueNameParts)
                {
                    if ((valueNamePart.Length < (ValueNameBeginToken.Length + ValueNameEndToken.Length + 1)) ||
                            (valueNamePart.Substring(0, ValueNameBeginToken.Length) != ValueNameBeginToken) ||
                            (valueNamePart.Substring(valueNamePart.Length - 1, 1) != ValueNameEndToken))
                    {
                        throw new Exception(UnexpectedExpressionFormatErrorMessage);
                    }

                    int valueNameLength = valueNamePart.Length - ValueNameBeginToken.Length - ValueNameEndToken.Length;
                    valueNames.Add(valueNamePart.Substring(ValueNameBeginToken.Length, valueNameLength));
                }

                return valueNames;
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

                List<string> chartValueNames = GetChartValueNames();
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


        public List<string> GetChartValueNames()
        {
            return new List<string>(_chartValueNames.Value);
        }


    }
}
