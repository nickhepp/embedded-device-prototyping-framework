using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.IO.Params
{
    public class Int8Parameter : BaseParameter<sbyte>
    {

        public Int8Parameter(string name, int parameterIndex) : base(name, parameterIndex, initialValue: 0, formatStr: "")
        {
        }

        public override void SetValue(string val)
        {
            sbyte result;
            if (sbyte.TryParse(val, out result))
            {
                Value = result;
            }
        }
    }
}
