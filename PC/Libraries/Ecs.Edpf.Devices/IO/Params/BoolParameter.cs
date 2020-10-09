using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.IO.Params
{
    public class BoolParameter : BaseParameter<bool>
    {
        public BoolParameter(string name, int parameterIndex, bool initialValue=false) : base(name, parameterIndex, initialValue, formatStr: "")
        {
        }

        public override void SetValue(string val)
        {
            if (val == "1")
            {
                Value = true;
            }
            else
            {
                Value = false;
            }
        }

        protected override string GetFormattedValueString()
        {
            string result;
            if (Value)
                result = "1";
            else
                result = "0";
            return result;
        }


    }
}
