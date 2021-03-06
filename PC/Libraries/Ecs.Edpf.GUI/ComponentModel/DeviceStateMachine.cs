using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.ComponentModel
{
    public class DeviceStateMachine 
    {

        private DeviceState _deviceState = DeviceState.NoDevice;
        public DeviceState DeviceState
        {
            get
            {
                return _deviceState;
            }
            private set
            {
                bool changed = (value != _deviceState);
                _deviceState = value;
                if (changed && (DeviceStateChanged != null))
                {
                    DeviceStateChanged(this, new EventArgs());
                }
            }

        }

        private void ThrowUnexpectedSendSignalArgs(DeviceSignal signal)
        {
            throw new ArgumentException($"Unexpected signal '{signal}' for current device state '{_deviceState}'.");
        }

        public void SendSignal(DeviceSignal signal)
        {
            switch (_deviceState)
            {
                case DeviceState.NoDevice:
                    if (signal == DeviceSignal.DeviceSet)
                    {
                        DeviceState = DeviceState.AssignedDevice;
                    }
                    else
                    {
                        ThrowUnexpectedSendSignalArgs(signal);
                    }
                    break;

                case DeviceState.OpenedDevice:
                    if (signal == DeviceSignal.DeviceClosed)
                    {
                        DeviceState = DeviceState.AssignedDevice;
                    }
                    else if (signal == DeviceSignal.DeviceCleared)
                    {
                        DeviceState = DeviceState.NoDevice;
                    }
                    else
                    {
                        ThrowUnexpectedSendSignalArgs(signal);
                    }
                    break;

                case DeviceState.AssignedDevice:
                    if (signal == DeviceSignal.DeviceCleared)
                    {
                        DeviceState = DeviceState.NoDevice;
                    }
                    else if (signal == DeviceSignal.DeviceOpened)
                    {
                        DeviceState = DeviceState.OpenedDevice;
                    }
                    else
                    {
                        ThrowUnexpectedSendSignalArgs(signal);
                    }
                    break;


                default:
                    throw new NotImplementedException($"Device state {_deviceState} is not handled.");

            }
        }

        public event EventHandler DeviceStateChanged;


    }
}
