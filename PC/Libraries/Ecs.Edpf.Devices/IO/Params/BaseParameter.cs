using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.IO.Params
{
    public abstract class BaseParameter<T> : IParameterBase<T>, IParameter
    {


        private const string CommandParameterPrefix = "p[";
        private const string CommandParameterSuffix = "]=";


        private int _parameterIndex;
        public int ParameterIndex => _parameterIndex;


        private string _formatStr;
        public string FormatString => _formatStr;

        private T _val;
        public T Value
        {
            get
            {
                return _val;
            }
            set
            {
                _val = value;
            }
        }

        public string Name { get; }

        public BaseParameter(string name, int parameterIndex, T initialValue, string formatStr = "")
        {

            _parameterIndex = parameterIndex;
            _val = initialValue;
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
        
    }
}
