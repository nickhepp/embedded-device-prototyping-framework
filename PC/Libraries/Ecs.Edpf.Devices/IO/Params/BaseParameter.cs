using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ecs.Edpf.Devices.IO.Params
{
    public abstract class BaseParameter<T> : IParameterBase<T>, IParameter, INotifyPropertyChanged
    {


        private const string CommandParameterPrefix = "p[";
        private const string CommandParameterSuffix = "]=";


        private int _parameterIndex;
        public int ParameterIndex => _parameterIndex;


        private string _formatStr;
        public string FormatString => _formatStr;

        private T _val;

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual T Value
        {
            get
            {
                return _val;
            }
            set
            {
                bool oldIsValid = IsValid;
                _val = value;
                if (IsValid != oldIsValid)
                {
                    RaiseNotifyPropertyChanged(nameof(IsValid));
                }

            }
        }


        public virtual bool IsValid => true;

        public string Name { get; }

        public BaseParameter(string name, int parameterIndex, T initialValue, string formatStr = "")
        {
            Name = name;
            _parameterIndex = parameterIndex;
            SetValue(initialValue.ToString());
            _formatStr = formatStr;
        }


        protected virtual string GetFormattedValueString()
        {
            string formattedVal = string.Format("{0:" + FormatString + "}", Value);
            return formattedVal;
        }

        public string GetParameterText()
        {
            string formattedVal = GetFormattedValueString();
            string res = $"{CommandParameterPrefix}{ParameterIndex}{CommandParameterSuffix}{formattedVal}";
            return res;
        }

        public string GetName()
        {
            return Name;
        }

        public int GetParameterIndex()
        {
            return ParameterIndex;
        }

        public string GetValue()
        {
            return GetFormattedValueString();
        }

        public abstract void SetValue(string val);

        public string GetFormatString()
        {
            return FormatString;
        }

        protected void RaiseNotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }


        
    }
}
