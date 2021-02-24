using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.IO.Macros
{
    public class DeviceTextMacro
    {

        public bool Loop { get; set; }

        public List<DeviceTextLine> DeviceTextLines { get; set; } = new List<DeviceTextLine>();
    
    }
}
