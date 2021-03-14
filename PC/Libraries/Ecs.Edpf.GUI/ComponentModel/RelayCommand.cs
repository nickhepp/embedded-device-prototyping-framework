using System;
using System.Windows.Input;

namespace Ecs.Edpf.GUI.ComponentModel
{
    public class RelayCommand : ICommand, IRelayCommand
    {
        private Predicate<object> _canExecute;
        private Action<object> _execute;

        public RelayCommand(Predicate<object> canExecute, Action<object> execute)
        {
            this._canExecute = canExecute;
            this._execute = execute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public event EventHandler CommandCanExecuteChanged;

        public void RaiseCommandCanExecuteChanged()
        {
            if (CommandCanExecuteChanged != null)
            {
                CommandCanExecuteChanged(this, new EventArgs());
            }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
