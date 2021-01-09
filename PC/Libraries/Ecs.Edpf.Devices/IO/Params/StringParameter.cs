using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.IO.Params
{
    public class StringParameter : BaseParameter<string>
    {

        public override bool IsValid
        {
            get
            {
                return !string.IsNullOrEmpty(Value);
            }
        }


        public StringParameter(string name, int parameterIndex, string initialValue, string formatStr = "") : base(name, parameterIndex, initialValue, formatStr)
        {
        }

        public override void SetValue(string val)
        {
            Value = val;
        }

    }

}
