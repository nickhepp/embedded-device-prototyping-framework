using Ecs.Edpf.GUI.ComponentModel;
using Ecs.Edpf.GUI.UI.ViewModels.Logger;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ecs.Edpf.GUI.UI.Views
{
    public partial class LoggerView : UserControl, IRelayCommandExceptionHandler
    {

        private ILoggerViewModel _loggerViewModel;
        public ILoggerViewModel LoggerViewModel
        {
            get
            {
                return _loggerViewModel;
            }
            set
            {
                _loggerViewModel = value;
                UpdateLoggerViewModel();
            }
        }


        private List<RelayCommandHandler> _relayCmdHandlers = new List<RelayCommandHandler>();

        public LoggerView()
        {
            InitializeComponent();
        }

        private void UpdateLoggerViewModel()
        {
            _relayCmdHandlers.Clear();

            if (LoggerViewModel != null)
            {
                _relayCmdHandlers.Add(
                    new RelayCommandHandler(_saveSettingsBtn, LoggerViewModel.SaveLoggerSettingsCommand, this));

                _settingsPpg.SelectedObject = LoggerViewModel.SettingsViewModel;
            }
            else
            {
                _settingsPpg.SelectedObject = null;
            }

        }

        public void HandleException(Exception ex)
        {
            RelayCommandExceptionHandlerUtility.HandleException(ex);
        }
    }
}
