using Ecs.Edpf.Devices.ComponentModel.Macros.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecs.Edpf.Devices.ComponentModel.Macros
{
    public class DeviceTextMacroIterationMachine
    {

        private InstructionCollection _instructions;
        private int _deviceTextMacroLineIdx;
        private DateTime _nextTime;
        private DateTime _startTime;

        private IDateTimeProvider _dateTimeProvider;
        private double _totalIterationTime;

        public bool Completed { get; private set; } = false;

        public int IterationCount { get; private set; } = 0;

        public MacroExecutionType ExecutionType { get; }

        public double RatioComplete
        {
            get
            {
                double ratio = 1.0;
                if (_deviceTextMacroLineIdx != 0)
                {
                    ratio = (double)_deviceTextMacroLineIdx / _instructions.Instructions.Count; 
                }
                return ratio;
            }
        }


        public DeviceTextMacroIterationMachine(InstructionCollection instructions, MacroExecutionType exeType, IDateTimeProvider dateTimeProvider)
        {
            if (instructions.Instructions.Count == 0)
            {
                throw new Exception("DeviceTextLines must have more than 0 lines.");
            }

            _deviceTextMacroLineIdx = 0;
            _instructions = instructions;
            ExecutionType = exeType;
            _dateTimeProvider = dateTimeProvider;
            Completed = false;

            IterationCount = 0;
            _totalIterationTime = 0;
            List<DelayInstruction> deviceTextLinesWithDelays = GetAllInstructionsWithDelays();
            if (deviceTextLinesWithDelays.Count > 0)
            {
                _totalIterationTime = deviceTextLinesWithDelays.Select(devTextLine => devTextLine.DelayInSeconds).Sum();
            }

            _startTime = dateTimeProvider.GetCurrentDateTime();

            SetNextTime();
        }

        private List<DelayInstruction> GetAllInstructionsWithDelays()
        {
            return GetInstructionsWithDelays(0, _instructions.Instructions.Count);
        }

        private List<DelayInstruction> GetInstructionsWithDelays(int rangeMin, int count)
        {
            List<DelayInstruction> deviceTextLinesWithDelays = _instructions.Instructions.GetRange(rangeMin, count). Where(instr => instr.InstructionType == InstructionType.Delay).ToList().ConvertAll(instr => (DelayInstruction)instr);
            return deviceTextLinesWithDelays;
        }


        private void SetNextTime()
        {
            DateTime baseTime = _startTime + TimeSpan.FromMilliseconds(IterationCount * _totalIterationTime);
            //List<DelayInstruction> deviceTextLinesWithDelays = GetInstructionsWithDelays();
            List<DelayInstruction> deviceTextLinesWithDelays = GetInstructionsWithDelays(0, _deviceTextMacroLineIdx + 1);
            baseTime += TimeSpan.FromMilliseconds(deviceTextLinesWithDelays.Select(devTextLine => devTextLine.DelayInSeconds).Sum());
            // advance the next run time to the delay + the current time
            _nextTime = baseTime;
        }



        public Instruction GetNextDeviceTextLine()
        {
            Instruction devTextLine = null;
            DateTime currTime = _dateTimeProvider.GetCurrentDateTime();
            if (currTime >= _nextTime)
            {
                // get the line and advance the pointer
                devTextLine = _instructions.Instructions[_deviceTextMacroLineIdx];
                _deviceTextMacroLineIdx++;
                if (_deviceTextMacroLineIdx >= _instructions.Instructions.Count)
                {
                    IterationCount++;
                    // see if we need to roll over or are we done
                    if (ExecutionType == MacroExecutionType.Loop)
                    {
                        _deviceTextMacroLineIdx = 0;
                    }
                    else
                    {
                        Completed = true;
                    }
                }
                if (!Completed)
                {
                    SetNextTime();
                }
            }

            return devTextLine;
        }



    }
}
