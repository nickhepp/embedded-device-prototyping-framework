using Ecs.Edpf.Devices.ComponentModel.Macros.Instructions;
using System.Collections.Generic;
using System.Linq;

namespace Ecs.Edpf.Devices.ComponentModel.Macros.Instructions
{
    public class InstructionCollectionFactory
    {

        public InstructionCollection ParseDeviceTextMacroInitArgs(InstructionCollectionInitArgs initArgs)
        {

            List<Instruction> instructions = new List<Instruction>();
            foreach (string instructionLine in initArgs.Instructions)
            {
                Instruction instruction = null;
                if (instructionLine.StartsWith(CommentInstruction.CommentPrefix))
                {
                    instruction = new CommentInstruction(instructionLine);
                }
                else if (DelayInstruction.DelayPrefices.Any(delayPrefix => instructionLine.StartsWith(delayPrefix)))
                {
                    instruction = new DelayInstruction(instructionLine);
                }
                else
                {
                    instruction = new DeviceTextInstruction(instructionLine);
                }
                instructions.Add(instruction);
            }

            InstructionCollection instructionCollection = new InstructionCollection(instructions);
            return instructionCollection;
        }

    }
}
