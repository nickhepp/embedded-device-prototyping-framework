using Ecs.Edpf.Devices.ComponentModel;
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
    public class ConsoleToolWindowCohort : IToolWindowCohort
    {
        public string Name => "Console";

        public string Description => "Interact with the device as if it were a server that " +
            "provides a terminal interface. The device responds with easy to understand text in a " +
            "'human readable' format.";

        public Bitmap Image => HostApp.Properties.Resources.terminal;

        private Lazy<ToolWindow> _toolWindow;

        private IConsoleViewModel _consoleViewModel = new ConsoleViewModel(new DeviceStateMachine());

        public IViewModel ViewModel => _consoleViewModel;

        public string RoadmapIssueUrl => null;

        public ToolState State => ToolState.Active;

        public ConsoleToolWindowCohort()
        {
            _toolWindow = new Lazy<ToolWindow>(() =>
            {
                ConsoleView consoleView = new ConsoleView
                {
                    ConsoleViewModel = _consoleViewModel
                };

                ToolWindow toolWindow = new ToolWindow();
                toolWindow.DockAreas |= WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
                toolWindow.Initialize(consoleView, this.Name);

                IntPtr terminalIcon = HostApp.Properties.Resources.terminal.GetHicon();
                Icon cmdIcon = Icon.FromHandle(terminalIcon);
                toolWindow.Icon = cmdIcon;
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
