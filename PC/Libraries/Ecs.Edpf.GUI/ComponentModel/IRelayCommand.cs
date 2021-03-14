using System;
using System.Windows.Input;

namespace Ecs.Edpf.GUI.ComponentModel
{
    public interface IRelayCommand : ICommand
    {
        event EventHandler CommandCanExecuteChanged;
    }
}