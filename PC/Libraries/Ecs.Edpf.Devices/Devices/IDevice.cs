﻿using Ecs.Edpf.Devices.Connections;
using Ecs.Edpf.Devices.IO.Cmds;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace Ecs.Edpf.Devices
{
    public interface IDevice : INotifyPropertyChanged
    {


        ReadOnlyCollection<IDeviceCommand> DeviceCommands { get; } 


        int CommandTimeout { get; set; }

        IConnectionInfo ConnectionInfo { get; }

        BindingList<string> DeviceInputBuffer { get; }


        BindingList<string> DeviceOutputBuffer { get; }

        bool IsOpen { get; }

        bool Open();

        void Close();

        string Write(string cmdText);

        /// <summary>
        /// Executes the device command.
        /// </summary>
        /// <param name="cmd">Command to execute.</param>
        void ExecuteCommand(IDeviceCommand cmd);

        string GetDeviceInfo();

        string GetRegisteredCommands();


        /// <summary>
        /// Event that is raised when the device is opened.
        /// </summary>
        event EventHandler DeviceOpened;

        /// <summary>
        /// Event that is raised when the device is closed.
        /// </summary>
        event EventHandler DeviceClosed;

        void AddDeviceCommands(List<IDeviceCommand> builtCommands);

    }
}
