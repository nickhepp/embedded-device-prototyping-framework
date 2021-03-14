using System;

namespace Ecs.Edpf.GUI.ComponentModel
{
    public interface IDeviceStateMachine
    {
        DeviceState DeviceState { get; }

        event EventHandler DeviceStateChanged;

        void SendSignal(DeviceSignal signal);
    }
}