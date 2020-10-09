using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.IO.Params
{
    public class UInt8Parameter : BaseParameter<byte>
    {
        public UInt8Parameter(string name, int parameterIndex) : base(name, parameterIndex, initialValue:0, formatStr: "")
        {
        }

        public override void SetValue(string val)
        {
            byte result;
            if (byte.TryParse(val, out result))
            {
                Value = result;
            }
        }


    }
}
