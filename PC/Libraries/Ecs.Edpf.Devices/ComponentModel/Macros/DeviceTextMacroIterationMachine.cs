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

        private DateTime _startTime;

        private IDateTimeProvider _dateTimeProvider;
        private double _totalIterationTime;
        private List<TimeGrouping> _timeGroupings;
        private List<double> _iterationRatios;
        private int _currentGroupingIdx;


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

            _timeGroupings = instructions.GetTimeGroupings();
            _totalIterationTime = instructions.GetTotalTimeDuration();

            _iterationRatios = new List<double>();

            double totalRunningOffset = 0.0;
            foreach (TimeGrouping tg in _timeGroupings)
            {
                totalRunningOffset += tg.TimeOffsetInSeconds;
                double iterationRatio = totalRunningOffset / _totalIterationTime;
                _iterationRatios.Add(iterationRatio);
            }
            _currentGroupingIdx = 0;

            Completed = false;

            //IterationCount = 0;
            //_totalIterationTime = 0;
            //List<DelayInstruction> deviceTextLinesWithDelays = GetAllInstructionsWithDelays();
            //if (deviceTextLinesWithDelays.Count > 0)
            //{
            //    _totalIterationTime = deviceTextLinesWithDelays.Select(devTextLine => devTextLine.DelayInSeconds).Sum();
            //}

            _startTime = _dateTimeProvider.GetCurrentDateTime();

            //SetNextTime();
        }


        private TimeGrouping GetTimeGroupingByIndex(int idx)
        {
            int iterationidx = idx % _timeGroupings.Count;
            return _timeGroupings[iterationidx];
        }

        public List<TimeGrouping> GetNextTimeGroupings()
        {
            DateTime currentTime = _dateTimeProvider.GetCurrentDateTime();

            double totalExecutingSeconds = currentTime.Subtract(_startTime).TotalSeconds;

            double iterations = totalExecutingSeconds / _totalIterationTime;

            int roundIterations = (int)iterations;
            double partialIteration = iterations - (double)roundIterations;
            int partialTimeGroups = 0;
            int groupingIdx = 0;
            while ((groupingIdx < _timeGroupings.Count) && (partialIteration > _iterationRatios[groupingIdx]))
            {
                partialTimeGroups++;
                groupingIdx++;
            }

            int totalIterations = roundIterations * _timeGroupings.Count + partialTimeGroups;

            List<TimeGrouping> timeGroupings = new List<TimeGrouping>();
            while ((_currentGroupingIdx < totalIterations) && !Completed)
            {
                if ((ExecutionType == MacroExecutionType.OneShot) && (_currentGroupingIdx >= _timeGroupings.Count))
                {
                    Completed = true;
                }
                else
                {
                    timeGroupings.Add(GetTimeGroupingByIndex(_currentGroupingIdx));
                }
                
            }
            return timeGroupings;

        }



        //private List<DelayInstruction> GetAllInstructionsWithDelays()
        //{
        //    return GetInstructionsWithDelays(0, _instructions.Instructions.Count);
        //}

        //private List<DelayInstruction> GetInstructionsWithDelays(int rangeMin, int count)
        //{
        //    List<DelayInstruction> deviceTextLinesWithDelays = _instructions.Instructions.GetRange(rangeMin, count). Where(instr => instr.InstructionType == InstructionType.Delay).ToList().ConvertAll(instr => (DelayInstruction)instr);
        //    return deviceTextLinesWithDelays;
        //}


        //private void SetNextTime()
        //{
        //    DateTime baseTime = _startTime + TimeSpan.FromMilliseconds(IterationCount * _totalIterationTime);
        //    //List<DelayInstruction> deviceTextLinesWithDelays = GetInstructionsWithDelays();
        //    List<DelayInstruction> deviceTextLinesWithDelays = GetInstructionsWithDelays(0, _deviceTextMacroLineIdx + 1);
        //    baseTime += TimeSpan.FromMilliseconds(deviceTextLinesWithDelays.Select(devTextLine => devTextLine.DelayInSeconds).Sum());
        //    // advance the next run time to the delay + the current time
        //    _nextTime = baseTime;
        //}



        //public Instruction GetNextDeviceTextLine()
        //{
        //    throw new NotImplementedException();
        //    //Instruction devTextLine = null;
        //    //DateTime currTime = _dateTimeProvider.GetCurrentDateTime();
        //    //if (currTime >= _nextTime)
        //    //{
        //    //    // get the line and advance the pointer
        //    //    devTextLine = _instructions.Instructions[_deviceTextMacroLineIdx];
        //    //    _deviceTextMacroLineIdx++;
        //    //    if (_deviceTextMacroLineIdx >= _instructions.Instructions.Count)
        //    //    {
        //    //        IterationCount++;
        //    //        // see if we need to roll over or are we done
        //    //        if (ExecutionType == MacroExecutionType.Loop)
        //    //        {
        //    //            _deviceTextMacroLineIdx = 0;
        //    //        }
        //    //        else
        //    //        {
        //    //            Completed = true;
        //    //        }
        //    //    }
        //    //    if (!Completed)
        //    //    {
        //    //        SetNextTime();
        //    //    }
        //    //}

        //    //return devTextLine;
        //}



    }
}
