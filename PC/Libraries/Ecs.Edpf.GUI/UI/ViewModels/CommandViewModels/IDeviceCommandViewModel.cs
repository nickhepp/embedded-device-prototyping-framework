﻿using Ecs.Edpf.GUI.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels
{
    public interface IDeviceCommandViewModel : INotifyPropertyChanged
    {

        string MethodName { get; }

        bool IsValid { get; }

        void Execute();

    }
}
