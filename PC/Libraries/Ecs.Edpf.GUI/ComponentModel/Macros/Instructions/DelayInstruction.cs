using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.ComponentModel.Macros.Instructions
{
    public class DelayInstruction : Instruction
    {

        public static readonly string[] DelayPrefices = new string[] { "--sleep", "-- sleep"};

        public override InstructionType InstructionType => InstructionType.Delay;

        public double DelayInSeconds { get; set; }

    }
}
