using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecs.Edpf.Data.DataStreams
{
    public class DataStreamExpressionFilter
    {


        public const string UnexpectedExpressionFormatErrorMessage = "Unexpected Expression format.  Simple Expression strings are of the following format: " +
            "'value_prefix:{series-1},{series-2},{series-n}'";


        public const string ValueSeparatorToken = ":";

        public const string SeriesAndChartNameBeginToken = "{";

        public const string SeriesAndChartNameEndToken = "}";

        public const char ValuesSeparatorToken = ',';

        //public const string SeriesChartNameSeparatorToken = "|";

        private Lazy<Dictionary<string, string>> _chartSeriesToChartNames;

        private string _valuesPrefix;

        private string _expression;

        public event EventHandler ExpressionChanged;

        public string Expression
        {
            get
            {
                return _expression;
            }
        }

        public DataStreamExpressionFilter(string expression)
        {

            // TODO: look for the correct expression format

            int valSepLocation = expression.IndexOf(ValueSeparatorToken);
            if (valSepLocation == -1)
                throw new ArgumentException(UnexpectedExpressionFormatErrorMessage);

            string valuesExpression = expression.Substring(valSepLocation + 1);

            List<string> valueParts = valuesExpression.
                Split(new char[] { ValuesSeparatorToken }, StringSplitOptions.None).
                ToList().
                ConvertAll(valPart => valPart.Trim())

        //public const string ValueSeparatorToken = ":";
        //public const string SeriesAndChartNameBeginToken = "{";
        //public const string SeriesAndChartNameEndToken = "}";
        //public const string ValuesSeparatorToken = ",";

        _expression = expression;
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

        }




    }
}
