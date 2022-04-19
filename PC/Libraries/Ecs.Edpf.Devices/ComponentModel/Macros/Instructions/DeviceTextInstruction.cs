using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.Devices.ComponentModel.Macros.Instructions
{
    public class DeviceTextInstruction : Instruction
    {
        public override InstructionType InstructionType => InstructionType.DeviceText;

        public string DeviceText { get; set; } = "";

        public DeviceTextInstruction(string instructionLine)
        {
            DeviceText = instructionLine;
        }

        public override string GetDeviceText()
        {
            return DeviceText;
        }

        public override Instruction Copy()
        {
            return new DeviceTextInstruction(DeviceText);
        }

    }
}
