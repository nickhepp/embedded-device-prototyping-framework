using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.IO.Params
{
    public class Int16Parameter : BaseParameter<Int16>
    {
        public Int16Parameter(string name, int parameterIndex, Int16 initialValue = 0, string formatStr = "") : base(name, parameterIndex, initialValue, formatStr)
        {
        }

        public override void SetValue(string val)
        {
            Int16 result;
            if (Int16.TryParse(val, out result))
            {
                Value = result;
            }
        }

    }
}