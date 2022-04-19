using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.Devices.ComponentModel.Macros.Instructions
{
    public class InstructionCollection
    {

        public List<Instruction> Instructions { get; set; } = new List<Instruction>();


        public List<DelayInstruction> GetDelayInstructions(int startIdx, int count)
        {
            return Instructions.GetRange(startIdx, count).Where(instr => instr.GetType() == typeof(DelayInstruction)).ToList().ConvertAll(instr => (DelayInstruction)instr);
        }

        public List<DelayInstruction> GetDelayInstructions()
        {
            return GetDelayInstructions(0, Instructions.Count);
        }

        public double GetTotalTimeDuration()
        {
            return GetDelayInstructions().Select(delayInstr => delayInstr.DelayInSeconds).Sum();
        }

        public List<TimeGrouping> GetTimeGroupings()
        {
            List<TimeGrouping> groupings = new List<TimeGrouping>();
            double timeOffset = 0.0;
            TimeGrouping currentTimeGrouping = new TimeGrouping {  TimeOffsetInSeconds = timeOffset };
            groupings.Add(currentTimeGrouping);
            int idx = 0;

            while (idx < Instructions.Count)
            {
                if ((Instructions[idx].InstructionType == InstructionType.DeviceText) && (Instructions[idx] is DeviceTextInstruction devTextInstr))
                {
                    currentTimeGrouping.DeviceTextInstructions.Add(devTextInstr);
                }
                else if ((Instructions[idx].InstructionType == InstructionType.Delay) && (Instructions[idx] is DelayInstruction delayInstr))
                {
                    timeOffset += delayInstr.DelayInSeconds;
                    currentTimeGrouping = new TimeGrouping { TimeOffsetInSeconds = timeOffset };
                    groupings.Add(currentTimeGrouping);
                }
                idx++;
            }


            return groupings;

        }

        public InstructionCollection Copy()
        {
            InstructionCollection theCopy = new InstructionCollection
            {
                Instructions = this.Instructions.ConvertAll(instr => instr.Copy())
            };
            return theCopy;
        }

    }
}
