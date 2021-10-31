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

        //public XAxisType XAxisType { get; set; } = XAxisType.SampleNumber;

        private uint? _maxDisplaySampleCount = 150;
        public uint? MaxDisplaySampleCount
        {
            get
            {
                return _maxDisplaySampleCount;
            }
            set
            {
                _maxDisplaySampleCount = value;
                RaiseNotifyPropertyChanged();
            }


        }


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

            return errors;
        }

    }
}
