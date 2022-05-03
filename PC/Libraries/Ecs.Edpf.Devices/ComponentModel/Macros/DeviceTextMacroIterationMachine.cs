using Ecs.Edpf.Devices.ComponentModel.Macros.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecs.Edpf.Devices.ComponentModel.Macros
{
    public class DeviceTextMacroIterationMachine : IDeviceTextMacroIterationMachine
    {

        private InstructionCollection _instructions;

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
                double ratio;
                int iterationidx = _currentGroupingIdx % _timeGroupings.Count;
                //if (_currentGroupingIdx == 0)
                //{
                //    ratio = 0.0;
                //}
                //else if ((iterationidx == 0) && (_currentGroupingIdx > 0))
                //{
                //    ratio = 1.0;
                //}
                //else
                //{
                //    ratio = (double)iterationidx / _timeGroupings.Count;
                //}

                ratio = ((double)(iterationidx + 1)) / _timeGroupings.Count;

                return ratio;
            }
        }


        public DeviceTextMacroIterationMachine(InstructionCollection instructions, MacroExecutionType exeType, IDateTimeProvider dateTimeProvider)
        {
            if (instructions.InstructionsCount == 0)
            {
                throw new Exception("DeviceTextLines must have more than 0 lines.");
            }

            _timeGroupings = instructions.GetTimeGroupings().ToList();
            if (_timeGroupings.Count == 0)
            {
                throw new Exception("There were no timing groups in the InstructionCollection.");
            }

            _instructions = instructions;
            ExecutionType = exeType;
            _dateTimeProvider = dateTimeProvider;

            
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
                if (ExecutionType == MacroExecutionType.OneShot)
                {
                    if (_currentGroupingIdx >= _timeGroupings.Count)
                    {
                        Completed = true;
                    }
                    else
                    {
                        timeGroupings.Add(GetTimeGroupingByIndex(_currentGroupingIdx));
                        _currentGroupingIdx++;
                    }
                }
                else //if (ExecutionType == MacroExecutionType.Loop)
                {

                    if (_timeGroupings.Count == 1)
                    {
                        // if we only have 1 time grouping then we simply add that group
                        timeGroupings.Add(_timeGroupings[0]);
                        // and act like we have caught up
                        _currentGroupingIdx = totalIterations;
                    }
                    else
                    {
                        int wholeIterations = (totalIterations - _currentGroupingIdx) / _timeGroupings.Count;
                        if (wholeIterations > 0)
                        {
                            // jump the iterations far ahead, skip the entire groups 
                            _currentGroupingIdx = _currentGroupingIdx + (wholeIterations * _timeGroupings.Count);
                        }
                        else
                        {
                            // add the remaining partials
                            timeGroupings.Add(GetTimeGroupingByIndex(_currentGroupingIdx));
                            _currentGroupingIdx++;
                        }
                    }
                }

            }
            return timeGroupings;

        }

    }
}
