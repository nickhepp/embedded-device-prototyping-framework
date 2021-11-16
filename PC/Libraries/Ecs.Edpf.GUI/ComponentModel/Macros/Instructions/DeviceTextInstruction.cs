using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.ComponentModel.Macros.Instructions
{
    public class DeviceTextInstruction : Instruction
    {
        public override InstructionType InstructionType => InstructionType.DeviceText;

        public string DeviceText { get; set; } = "";

    }
}
