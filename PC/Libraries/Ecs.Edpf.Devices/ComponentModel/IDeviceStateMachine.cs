using System;

namespace Ecs.Edpf.Devices.ComponentModel
{
    public interface IDeviceStateMachine
    {
        DeviceState DeviceState { get; }

        event EventHandler DeviceStateChanged;

        void SendSignal(DeviceSignal signal);
    }
}