using System.Collections.Generic;
using System.ComponentModel;

namespace Ecs.Edpf.GUI.UI.ViewModels
{
    public interface IGetDeviceCommandLinesViewModel : INotifyPropertyChanged
    {

        string MethodName { get; }

        bool IsValid { get; }

        List<string> GetCommandTextLines();
    }
}