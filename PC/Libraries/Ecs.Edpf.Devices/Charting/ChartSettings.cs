using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.Devices.Charting
{
    public class ChartSettings : INotifyPropertyChanged
    {
        private string _chartName;
        public string ChartName {
            get
            {
                return _chartName;
            }
            set
            {
                if (value != null)
                {
                    _chartName = value.Trim();
                }
                else
                {
                    _chartName = null;
                }
            }
        }

        public XAxisType XAxisType { get; set; } = XAxisType.SampleNumber;

        public Range XRange { get; set; } = new Range();

        public YAxisScale YAxisScale { get; set; } = YAxisScale.Linear;

        public Range YRange { get; set; } = new Range();

        public Ecs.Edpf.Devices.ComponentModel.ExpressionType ExpressionType { get; set; }

        private string _expression;
        public string Expression
        {
            get
            {
                return _expression;
            }
            set
            {
                _expression = value;
                RaiseNotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaiseNotifyPropertyChanged([CallerMemberName] string propName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }


        public List<string> GetErrors()
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrEmpty(Expression))
            {
                errors.Add($"'{nameof(Expression)}' is not set.");
            }
            else if (Expression.Trim() == string.Empty)
            {
                errors.Add($"'{nameof(Expression)}' is not set.");
            }

            if (string.IsNullOrEmpty(ChartName))
            {
                errors.Add($"'{nameof(ChartName)}' is not set.");
            }
            else if (ChartName.Trim() == string.Empty)
            {
                errors.Add($"'{nameof(ChartName)}' is not set.");
            }

            if ((XRange.RangeType != RangeType.Auto) && (XRange.Max <= XRange.Min))
            {
                errors.Add($"'{nameof(XRange)}.{nameof(Range.Min)}' must be less than '{nameof(XRange)}.{nameof(Range.Max)}'.");
            }

            if ((YRange.RangeType != RangeType.Auto) && (YRange.Max <= YRange.Min))
            {
                errors.Add($"'{nameof(YRange)}.{nameof(Range.Min)}' must be less than '{nameof(YRange)}.{nameof(Range.Max)}'.");
            }


            return errors;
        }



    }
}
