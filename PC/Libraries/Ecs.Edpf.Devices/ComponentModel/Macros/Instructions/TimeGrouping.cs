using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.ComponentModel.Macros.Instructions
{
    public class TimeGrouping
    {

        public double TimeOffsetInSeconds { get; set; }

        public List<DeviceTextInstruction> DeviceTextInstructions { get; set; } = new List<DeviceTextInstruction>();

    }
}
