using Ecs.Edpf.Devices.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels
{
    public interface IConsoleViewModel : IDeviceViewModel, IDeviceProviderListener
    {

        string SelectedPreviousCommand { get; }

        int MaxPreviousCommandCount { get; }

        int PreviousCommandCount { get; }

        int? SelectedPreviousCommandIndex { get; }

        List<ConsoleTokenHighlight> ConsoleTokenHighlights { get; set; }

        string ErrorMessages { get; set; }

        void WriteTextToDevice(string cmdText);

        bool InputTextEnabled { get; }

        void SelectUpPreviousCommand(string currentText);

        void SelectDownPreviousCommand();
    }
}
