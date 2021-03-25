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

        private EventHandler _handler;
        public event EventHandler CanExecuteChanged
        {
            add 
            { 
                CommandManager.RequerySuggested += value;
                _handler = value;
            }
            remove { CommandManager.RequerySuggested -= value; }
            
        }

        //public event EventHandler CommandCanExecuteChanged;

        private static EventArgs GetEventArgs()
        {
            return new EventArgs();
        }

        public void RaiseCommandCanExecuteChanged(object sender = null, EventArgs eventArgs = null)
        {
            if (_handler != null)
            {
                if (eventArgs == null)
                {
                    eventArgs = new EventArgs();
                }
                _handler(sender, eventArgs);
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
