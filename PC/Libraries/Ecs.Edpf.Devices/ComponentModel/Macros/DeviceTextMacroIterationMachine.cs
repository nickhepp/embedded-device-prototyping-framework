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
                    ratio = (double)_deviceTextMacroLineIdx / _instructions.InstructionsCount; 
                }
                return ratio;
            }
        }


        public DeviceTextMacroIterationMachine(InstructionCollection instructions, MacroExecutionType exeType, IDateTimeProvider dateTimeProvider)
        {
            if (instructions.InstructionsCount == 0)
            {
                throw new Exception("DeviceTextLines must have more than 0 lines.");
            }

            _deviceTextMacroLineIdx = 0;
            _instructions = instructions;
            ExecutionType = exeType;
            _dateTimeProvider = dateTimeProvider;

            _timeGroupings = instructions.GetTimeGroupings().ToList();
            _totalIterationTime = instructions.GetTotalTimeDuration();

            _iterationRatios = new List<double>();

            foreach (TimeGrouping tg in _timeGroupings)
            {
                _iterationRatios.Add(tg.TimeOffsetInSeconds / _totalIterationTime);
            }
            _currentGroupingIdx = 0;

            Completed = false;

            _startTime = _dateTimeProvider.GetCurrentDateTime();
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
                    _currentGroupingIdx++;
                }
                
            }
            return timeGroupings;

        }

    }
}
