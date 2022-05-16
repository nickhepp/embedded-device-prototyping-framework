using Ecs.Edpf.Devices.ComponentModel;
using Ecs.Edpf.Devices.Logging;
using Ecs.Edpf.GUI.ComponentModel;
using Ecs.Edpf.GUI.UI.ViewModels;
using Ecs.Edpf.GUI.UI.ViewModels.Logger;
using Ecs.Edpf.GUI.UI.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.UI.Views
{
    public class LoggingToolWindowCohort : IToolWindowCohort
    {
        public string Name => "Logging";

        public string Description => "Interact with the device as if it were a server that " +
            "provides a terminal interface. The device responds with easy to understand text in a " +
            "'human readable' format.";

        public Bitmap Image => HostApp.Properties.Resources.clipboard_list;

        private Lazy<ToolWindow> _toolWindow;

        private ILoggerSettingsViewModel _loggerSettingsViewModel;
        private ILoggerViewModel _loggerViewModel; 

        public IViewModel ViewModel => _loggerViewModel;

        public string RoadmapIssueUrl => "https://github.com/nickhepp/embedded-device-prototyping-framework/issues/3";

        public ToolState State => ToolState.Roadmap;

        public LoggingToolWindowCohort()
        {

            _loggerSettingsViewModel = new LoggerSettingsViewModel();
            ILoggerFactory loggerFactory = new LoggerFactory(new FileLoggerSettings());
            ILogLifeCycleManager logLifeCycleManager = new LogLifeCycleManager(loggerFactory);
            _loggerViewModel = new LoggerViewModel(new DeviceStateMachine(), _loggerSettingsViewModel, logLifeCycleManager);

            _toolWindow = new Lazy<ToolWindow>(() =>
            {
                LoggerView loggerView = new LoggerView();
                loggerView.Enabled = true;
                loggerView.LoggerViewModel = _loggerViewModel;
                ToolWindow toolWindow = new ToolWindow();
                toolWindow.Initialize(loggerView, this.Name);
                IntPtr loggingIconPtr = HostApp.Properties.Resources.clipboard_list.GetHicon();
                Icon loggingIcon = Icon.FromHandle(loggingIconPtr);
                toolWindow.Icon = loggingIcon;
                toolWindow.ShowIcon = true;
                return toolWindow;
            });
        }

        public ToolWindow GetToolWindow()
        {
            return _toolWindow.Value;
        }

    }
}
