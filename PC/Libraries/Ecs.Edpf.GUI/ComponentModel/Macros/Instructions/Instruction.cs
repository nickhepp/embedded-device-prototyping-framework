using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.ComponentModel.Macros.Instructions
{
    public abstract class Instruction
    {
        public abstract InstructionType InstructionType { get; }

        public TimeSpan Offset { get; set; } = TimeSpan.Zero;

    }
}
