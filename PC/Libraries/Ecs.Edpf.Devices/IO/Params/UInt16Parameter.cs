using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.IO.Params
{
    public class UInt16Parameter : BaseParameter<UInt16>
    {
        public UInt16Parameter(string name, int parameterIndex, ushort initialValue = 0, string formatStr = "") : base(name, parameterIndex, initialValue, formatStr)
        {
        }

        public override void SetValue(string val)
        {
            ushort result;
            if (ushort.TryParse(val, out result))
            {
                Value = result;
            }
        }

    }
}
