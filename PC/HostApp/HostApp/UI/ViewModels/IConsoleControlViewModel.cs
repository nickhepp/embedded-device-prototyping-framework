﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.UI.ViewModels
{
    public interface IConsoleControlViewModel : IDeviceViewModel
    {
        List<ConsoleTokenHighlight> ConsoleTokenHighlights { get; set; }

        string ErrorMessages { get; set; }

        void WriteTextToDevice(string cmdText);


        bool InputTextEnabled { get; }

    }
}
