using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.IO.Macros
{
    public class DeviceTextMacro
    {

        public bool Loop { get; set; }

        public List<DeviceTextLine> DeviceTextLines { get; set; } = new List<DeviceTextLine>();

        public DeviceTextMacro Copy()
        {
            DeviceTextMacro cpy = new DeviceTextMacro
            {
                Loop = this.Loop
            };
            foreach (DeviceTextLine devTextLine in DeviceTextLines)
            {
                cpy.DeviceTextLines.Add(devTextLine.Copy());
            }
            return cpy;
        }

    }
}
