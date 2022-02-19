using Ecs.Edpf.GUI.ComponentModel.Macros.Instructions;
using System.Linq;

namespace Ecs.Edpf.GUI.ComponentModel.Macros
{
    public class InstructionCollectionFactory
    {

        public InstructionCollection ParseDeviceTextMacroInitArgs(DeviceTextMacroInitArgs initArgs)
        {
            InstructionCollection instructionCollection = new InstructionCollection();

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
                instructionCollection.Instructions.Add(instruction);
            }

            return instructionCollection;
        }

    }
}
