using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.IO.Params
{
    public class Int32Parameter : BaseParameter<int>
    {
        public Int32Parameter(string name, int parameterIndex, int initialValue = 0, string formatStr = "") : base(name, parameterIndex, initialValue, formatStr)
        {
        }

        public override void SetValue(string val)
        {
            int result;
            if (int.TryParse(val, out result))
            {
                Value = result;
            }
        }

    }
}
