using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.Devices.ComponentModel.Macros.Instructions
{
    public class InstructionCollection
    {

        public const double MinimumTimeGroupingOffsetInSeconds = 0.001; // 001 msecs

        private List<Instruction> _instructions;
        public IEnumerable<Instruction> Instructions => _instructions;

        public int InstructionsCount => _instructions.Count;

        private Lazy<IEnumerable<TimeGrouping>> _timeGroupings;

        private Lazy<double> _totalTimeDuration;

        public InstructionCollection(IEnumerable<Instruction> instructions)
        {
            _instructions = instructions.ToList();

            _timeGroupings = new Lazy<IEnumerable<TimeGrouping>>(() =>
            {
                List<TimeGrouping> groupings = new List<TimeGrouping>();
                double timeOffset = MinimumTimeGroupingOffsetInSeconds;
                TimeGrouping currentTimeGrouping = new TimeGrouping { TimeOffsetInSeconds = timeOffset };
                groupings.Add(currentTimeGrouping);
                int idx = 0;

                while (idx < _instructions.Count)
                {
                    if ((_instructions[idx].InstructionType == InstructionType.DeviceText) && (_instructions[idx] is DeviceTextInstruction devTextInstr))
                    {
                        currentTimeGrouping.DeviceTextInstructions.Add(devTextInstr);
                    }
                    else if ((_instructions[idx].InstructionType == InstructionType.Delay) && (_instructions[idx] is DelayInstruction delayInstr))
                    {
                        timeOffset += Math.Max(delayInstr.DelayInSeconds, MinimumTimeGroupingOffsetInSeconds);

                        if (currentTimeGrouping.DeviceTextInstructions.Count == 0)
                        {
                            // these are initial delays, update the current one
                            currentTimeGrouping.TimeOffsetInSeconds = timeOffset;
                        }
                        else
                        {
                            // This is a delay after a DeviceText instruction.  Make a new grouping.
                            currentTimeGrouping = new TimeGrouping { TimeOffsetInSeconds = timeOffset };
                            groupings.Add(currentTimeGrouping);
                        }
                    }
                    idx++;
                }

                return groupings;
            });

        }



        //public List<DelayInstruction> GetDelayInstructions(int startIdx, int count)
        //{
        //    return _instructions.GetRange(startIdx, count).Where(instr => instr.GetType() == typeof(DelayInstruction)).ToList().ConvertAll(instr => (DelayInstruction)instr);
        //}

        //public List<DelayInstruction> GetDelayInstructions()
        //{
        //    return GetDelayInstructions(0, _instructions.Count);
        //}

        public double GetTotalTimeDuration()
        {

            return _timeGroupings.Value.Last().TimeOffsetInSeconds;
        }

        public IEnumerable<TimeGrouping> GetTimeGroupings()
        {
            return _timeGroupings.Value;
        }

        public InstructionCollection Copy()
        {
            InstructionCollection theCopy = new InstructionCollection(this.Instructions.ToList().ConvertAll(instr => instr.Copy()));
            return theCopy;
        }

    }
}
