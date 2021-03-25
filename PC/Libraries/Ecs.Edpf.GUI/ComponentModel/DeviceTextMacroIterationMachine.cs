using Ecs.Edpf.Devices.ComponentModel;
using Ecs.Edpf.Devices.IO.Macros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.ComponentModel
{
    public class DeviceTextMacroIterationMachine
    {

        private DeviceTextMacro _deviceTextMacro;
        private int _deviceTextMacroLineIdx;
        private DateTime? _nextTime;
        private DateTime _startTime;

        private IDateTimeProvider _dateTimeProvider;
        private int _totalIterationTime;

        public bool Completed { get; private set; } = false;

        public int IterationCount { get; private set; } = 0;

        public DeviceTextMacroIterationMachine(DeviceTextMacro deviceTextMacro, IDateTimeProvider dateTimeProvider)
        {
            if (deviceTextMacro.DeviceTextLines.Count == 0)
            {
                throw new Exception("DeviceTextLines must have more than 0 lines.");
            }

            _deviceTextMacroLineIdx = 0;
            _deviceTextMacro = deviceTextMacro;
            _dateTimeProvider = dateTimeProvider;
            Completed = false;

            IterationCount = 0;
            _totalIterationTime = 0;
            List<DeviceTextLine> deviceTextLinesWithDelays = deviceTextMacro.DeviceTextLines.Where(devTextLine => devTextLine.Delay.HasValue).ToList();
            if (deviceTextLinesWithDelays.Count > 0)
            {
                _totalIterationTime = deviceTextLinesWithDelays.Select(devTextLine => devTextLine.Delay.Value).Sum();
            }

            _startTime = dateTimeProvider.GetCurrentDateTime();

            SetNextTime();
        }

        private void SetNextTime()
        {
            DateTime baseTime = _startTime + TimeSpan.FromMilliseconds(IterationCount * _totalIterationTime);
            List<DeviceTextLine> deviceTextLinesWithDelays = _deviceTextMacro.DeviceTextLines.GetRange(0, _deviceTextMacroLineIdx + 1).Where(devTextLine => devTextLine.Delay.HasValue).ToList();
            baseTime += TimeSpan.FromMilliseconds(deviceTextLinesWithDelays.Select(devTextLine => devTextLine.Delay.Value).Sum());
            // advance the next run time to the delay + the current time
            _nextTime = baseTime;
        }



        public DeviceTextLine GetNextDeviceTextLine()
        {
            DeviceTextLine devTextLine = null;
            DateTime currTime = _dateTimeProvider.GetCurrentDateTime();
            if (currTime >= _nextTime.Value)
            {
                // get the line and advance the pointer
                devTextLine = _deviceTextMacro.DeviceTextLines[_deviceTextMacroLineIdx];
                _deviceTextMacroLineIdx++;
                if (_deviceTextMacroLineIdx >= _deviceTextMacro.DeviceTextLines.Count)
                {
                    IterationCount++;
                    // see if we need to roll over or are we done
                    if (_deviceTextMacro.Loop)
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
