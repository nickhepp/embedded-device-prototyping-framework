using Ecs.Edpf.GUI.ComponentModel;
using Ecs.Edpf.GUI.UI.ViewModels;
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


        private IConsoleViewModel _consoleViewModel = new ConsoleViewModel(new DeviceStateMachine());
        public IViewModel ViewModel => _consoleViewModel;

        public LoggingToolWindowCohort()
        {
            _toolWindow = new Lazy<ToolWindow>(() =>
            {
                LoggingView loggingView = new LoggingView
                {
                    //ConsoleViewModel = _consoleViewModel
                };
                //consoleView.ShowConsoleHeader = false;

                ToolWindow toolWindow = new ToolWindow();
                toolWindow.DockAreas |= WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
                toolWindow.Initialize(loggingView, this.Name);

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
