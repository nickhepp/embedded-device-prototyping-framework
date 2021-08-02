using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.IO.Params
{
    public class DoubleParameter : BaseParameter<double>
    {
        public DoubleParameter(string name, int parameterIndex, double initialValue = 0.0, string formatStr = "0.00") : base(name, parameterIndex, initialValue, formatStr)
        {
        }

        public override void SetValue(string val)
        {
            double result;
            if (double.TryParse(val, out result))
            {
                Value = result;
            }
        }

    }
}
