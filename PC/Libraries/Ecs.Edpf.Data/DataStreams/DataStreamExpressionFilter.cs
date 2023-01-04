using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecs.Edpf.Data.DataStreams
{
    public class DataStreamExpressionFilter : IDataStreamExpressionFilter
    {


        public const string UnexpectedExpressionFormatErrorMessage = "Unexpected Expression format.  Simple Expression strings are of the following format: " +
            "'value_prefix:{series-1},{series-2},{series-n}'";


        public const string ValueSeparatorToken = ":";

        public const string SeriesNameBeginToken = "{";

        public const string SeriesNameEndToken = "}";

        public const char ValuesSeparatorToken = ',';


        public List<string> ValueNames { get; private set; }

        private string _valuesPrefix;
        public string ValuesPrefix
        {
            get
            {
                return _valuesPrefix;
            }
            private set
            {
                _valuesPrefix = value;
                _valuesPrefixWithSpace = value + " ";
            }
        }

        private string _valuesPrefixWithSpace;

        public string Expression { get; private set; }

        public DataStreamExpressionFilter(string expression)
        {

            // TODO: look for the correct expression format

            int valSepLocation = expression.IndexOf(ValueSeparatorToken);
            if (valSepLocation == -1)
            {
                throw new ArgumentException(UnexpectedExpressionFormatErrorMessage);
            }

            string valuesExpression = expression.Substring(valSepLocation + 1);
            ValuesPrefix = expression.Substring(0, valSepLocation);
            if (ValuesPrefix.Length == 0)
            {
                throw new ArgumentException(UnexpectedExpressionFormatErrorMessage);
            }

            List<string> valueParts = valuesExpression.
                Split(new char[] { ValuesSeparatorToken }, StringSplitOptions.None).
                ToList().
                ConvertAll(valPart => valPart.Trim());

            if (
                    (valueParts.Count == 0) ||
                    valueParts.Any(valuePart => !valuePart.StartsWith(SeriesNameBeginToken)) ||
                    valueParts.Any(valuePart => !valuePart.EndsWith(SeriesNameEndToken))
                )
            {
                throw new ArgumentException(UnexpectedExpressionFormatErrorMessage);
            }

            List<string> tempValNames = valueParts.ConvertAll(valuePart => valuePart.Substring(1, valuePart.Length - 2));
            if (
                    tempValNames.Any(tempValName => tempValName.Any(c => !char.IsLetterOrDigit(c))) ||
                    tempValNames.Any(tempValName => !char.IsLetter(tempValName.First()))
                )
            {
                throw new ArgumentException(UnexpectedExpressionFormatErrorMessage);
            }

            if (tempValNames.Distinct(StringComparer.OrdinalIgnoreCase).Count() != tempValNames.Count)
            {
                throw new ArgumentException(UnexpectedExpressionFormatErrorMessage);
            }

            ValueNames = tempValNames;
            Expression = expression;
        }

        public LineResultsSet GetResults(string deviceDataLine)
        {
            LineResultsSet resultsSet = null;

            if ((deviceDataLine != null) && deviceDataLine.StartsWith(_valuesPrefixWithSpace))
            {
                List<string> potentialValStrs =
                    deviceDataLine.Substring(_valuesPrefixWithSpace.Length).
                    Split(',').
                    ToList().
                    ConvertAll(potentialVal => potentialVal.Trim());
                if (potentialValStrs.Count == ValueNames.Count)
                {
                    List<LineResult> lineResults = new List<LineResult>();
                    for (int k = 0; k < potentialValStrs.Count; k++)
                    {
                        if (double.TryParse(potentialValStrs[k], out double val))
                        {
                            lineResults.Add(new LineResult { Value = val, ValueName = ValueNames[k] });
                        }
                        else
                        {
                            // not everything was good data -- bail out now
                            k = potentialValStrs.Count;
                        }
                    }

                    if (lineResults.Count == potentialValStrs.Count)
                    {
                        resultsSet = new LineResultsSet { Results = lineResults };
                    }
                }
            }

            return resultsSet;
        }

    }
}
