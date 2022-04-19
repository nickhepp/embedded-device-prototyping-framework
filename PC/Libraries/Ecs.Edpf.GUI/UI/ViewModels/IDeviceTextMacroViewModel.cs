﻿using Ecs.Edpf.Devices.ComponentModel.Macros.Instructions;
using Ecs.Edpf.Devices.Devices;
using Ecs.Edpf.GUI.ComponentModel;

namespace Ecs.Edpf.GUI.UI.ViewModels
{
    public interface IDeviceTextMacroViewModel : IDeviceViewModel, IDeviceProviderListener
    {
        /// <summary>
        /// Resource identifier for serialization.
        /// </summary>
        string ResourceName { get; }

        /// <summary>
        /// The macro text for the device.
        /// </summary>
        InstructionCollection Instructions { get; set; }

        /// <summary>
        /// Command for a one shot of the macro text.
        /// </summary>
        IRelayCommand OneShotCommand { get; }

        /// <summary>
        /// Command for toggling the record and pause of the device text.
        /// </summary>
        IRelayCommand StopCommand { get; }

        /// <summary>
        /// Command for looping the macro text.
        /// </summary>
        IRelayCommand LoopCommand { get; }

        /// <summary>
        /// Whether the macro text editor is enabled.
        /// </summary>
        bool MacroTextEnabled { get; }


    }
}