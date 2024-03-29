﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.Devices.ComponentModel.Macros
{
    public class DeviceTextMacroStateMachine : DeviceStateMachine, IDeviceTextMacroStateMachine
    {

        public DeviceTextMacroStateMachine()
        {

        }

        private List<DeviceState> _deviceNotOpenStates = new List<DeviceState>
        { DeviceState.AssignedDevice, DeviceState.NoDevice};
        protected override void OnDeviceStateChanged()
        {

            if (DeviceState == ComponentModel.DeviceState.OpenedDevice)
            {
                SendDeviceTextMacroSignal(DeviceTextMacroSignal.DeviceOpened);
            }
            else if (_deviceNotOpenStates.Contains(DeviceState))
            {
                SendDeviceTextMacroSignal(DeviceTextMacroSignal.DeviceNotOpened);
            }


        }

        private DeviceTextMacroState _deviceTextMacroState = DeviceTextMacroState.NotOpenDevice;
        public DeviceTextMacroState DeviceTextMacroState
        {
            get
            {
                return _deviceTextMacroState;
            }
            private set
            {
                bool changed = (value != _deviceTextMacroState);
                _deviceTextMacroState = value;
                if (changed && (DeviceTextMacroStateChanged != null))
                {
                    DeviceTextMacroStateChanged(this, new EventArgs());
                }
            }
        }


        private void ThrowUnexpectedSendSignalArgs(DeviceTextMacroSignal signal)
        {
            throw new ArgumentException($"Unexpected signal '{signal}' for current device state '{_deviceTextMacroState}'.");
        }

        public void SendDeviceTextMacroSignal(DeviceTextMacroSignal signal)
        {
            switch (_deviceTextMacroState)
            {
                case DeviceTextMacroState.NotOpenDevice:
                    if (signal == DeviceTextMacroSignal.DeviceOpened)
                    {
                        DeviceTextMacroState = DeviceTextMacroState.OpenedDevice;
                    }
                    else if (signal == DeviceTextMacroSignal.DeviceNotOpened)
                    {
                        // no change
                    }
                    else
                    {
                        ThrowUnexpectedSendSignalArgs(signal);
                    }
                    break;

                case DeviceTextMacroState.OpenedDevice:
                    if (signal == DeviceTextMacroSignal.MacroLooping)
                    {
                        DeviceTextMacroState = DeviceTextMacroState.LoopingMacro;
                    }
                    else if (signal == DeviceTextMacroSignal.MacroOneShotting)
                    {
                        DeviceTextMacroState = DeviceTextMacroState.OneShottingMacro;
                    }
                    else if (signal == DeviceTextMacroSignal.DeviceNotOpened)
                    {
                        DeviceTextMacroState = DeviceTextMacroState.NotOpenDevice;
                    }
                    else
                    {
                        ThrowUnexpectedSendSignalArgs(signal);
                    }
                    break;

                case DeviceTextMacroState.OneShottingMacro:
                    if (signal == DeviceTextMacroSignal.MacroStop)
                    {
                        DeviceTextMacroState = DeviceTextMacroState.OpenedDevice;
                    }
                    else if (signal == DeviceTextMacroSignal.DeviceNotOpened)
                    {
                        DeviceTextMacroState = DeviceTextMacroState.NotOpenDevice;
                    }
                    else
                    {
                        ThrowUnexpectedSendSignalArgs(signal);
                    }
                    break;

                case DeviceTextMacroState.LoopingMacro:
                    if (signal == DeviceTextMacroSignal.MacroStop)
                    {
                        DeviceTextMacroState = DeviceTextMacroState.OpenedDevice;
                    }
                    else if (signal == DeviceTextMacroSignal.DeviceNotOpened)
                    {
                        DeviceTextMacroState = DeviceTextMacroState.NotOpenDevice;
                    }
                    else
                    {
                        ThrowUnexpectedSendSignalArgs(signal);
                    }
                    break;

                default:
                    throw new NotImplementedException($"DeviceTextMacroState {_deviceTextMacroState} is not handled.");

            }


        }


        public event EventHandler DeviceTextMacroStateChanged;


    }
}
