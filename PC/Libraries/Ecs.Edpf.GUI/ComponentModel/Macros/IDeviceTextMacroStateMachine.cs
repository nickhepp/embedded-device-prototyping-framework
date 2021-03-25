using System;

namespace Ecs.Edpf.GUI.ComponentModel.Macros
{
    public interface IDeviceTextMacroStateMachine : IDeviceStateMachine
    {
        DeviceTextMacroState DeviceTextMacroState { get; }

        event EventHandler DeviceTextMacroStateChanged;

        void SendDeviceTextMacroSignal(DeviceTextMacroSignal signal);
    }
}