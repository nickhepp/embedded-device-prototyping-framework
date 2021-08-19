using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.Devices.Charting
{
    public class ChartSettings
    {

        public string ChartName { get; set; }

        public XAxisType XAxisType { get; set; } = XAxisType.DirectFromDevice;

        public Range XRange { get; set; } = new Range();

        public YAxisScale YAxisScale { get; set; } = YAxisScale.Linear;

        public Range YRange { get; set; } = new Range();

        public Ecs.Edpf.Devices.ComponentModel.ExpressionType ExpressionType { get; set; }

        public string Expression { get; set; }

        public List<string> GetErrors()
        {
            return null;
        }



    }
}
