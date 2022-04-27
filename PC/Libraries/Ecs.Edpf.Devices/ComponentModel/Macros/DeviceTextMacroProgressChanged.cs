
using Ecs.Edpf.Devices.ComponentModel.Macros.Instructions;
using System.Collections.Generic;

namespace Ecs.Edpf.Devices.ComponentModel.Macros
{
    public class DeviceTextMacroProgressChanged
    {

        public double? RatioComplete { get; set; }

        public List<TimeGrouping> TimeGroupings { get; set; }

    }
}
