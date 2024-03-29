﻿using Ecs.Edpf.Devices.IO.Params;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Ecs.Edpf.Devices.IO.Cmds
{
    public interface IDeviceCommand : INotifyPropertyChanged
    {

        ReadOnlyCollection<IParameter> Parameters { get; }

        string MethodName { get; }

        List<string> GetCommandTextLines();

        /// <summary>
        /// Gets whether the device is valid.
        /// </summary>
        bool IsValid { get; }


    }
}
