using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecs.Edpf.GUI.ComponentModel
{
    public class RelayCommandHandler
    {

        private Button _button;
        private IRelayCommand _relayCommand;
        private Func<object> _getCommandArgHandler;
        private IRelayCommandExceptionHandler _relayCommandExHandler;

        public RelayCommandHandler(Button button, IRelayCommand relayCommand, IRelayCommandExceptionHandler relayCommandExHandler, Func<object> getCommandArgHandler = null)
        {
            _button = button;
            _relayCommand = relayCommand;
            _relayCommandExHandler = relayCommandExHandler;
            _getCommandArgHandler = getCommandArgHandler;

            _relayCommand.CanExecuteChanged += RelayCommand_CanExecuteChanged;
            _button.Click += Button_Click;

            RelayCommand_CanExecuteChanged(this, EventArgs.Empty);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            try
            {
                object arg = (_getCommandArgHandler != null) ? _getCommandArgHandler() : null;
                _relayCommand.Execute(arg);
            }
            catch (Exception ex)
            {
                _relayCommandExHandler.HandleException(ex);
            }
        }

        private void RelayCommand_CanExecuteChanged(object sender, EventArgs e)
        {
            _button.Enabled = _relayCommand.CanExecute(null);
        }



    }
}
