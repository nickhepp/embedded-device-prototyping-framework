using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.IO.Params
{
    public class UInt32Parameter : BaseParameter<UInt32>
    {
        public UInt32Parameter(string name, int parameterIndex, uint initialValue = 0, string formatStr = "") : base(name, parameterIndex, initialValue, formatStr)
        {
        }

        public override void SetValue(string val)
        {
            uint result;
            if (uint.TryParse(val, out result))
            {
                Value = result;
            }
        }

    }
}
