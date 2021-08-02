using Ecs.Edpf.GUI.ComponentModel;
using Ecs.Edpf.GUI.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.UI.Views
{
    public class ToolBoxWindowCohort : IToolWindowCohort
    {
        public string Name => "Toolbox";

        public string Description => "A toolbox to quickly open the other tools.";

        public Bitmap Image => HostApp.Properties.Resources.construction;

        private Lazy<ToolWindow> _toolWindow;

        private IConsoleViewModel _consoleViewModel = new ConsoleViewModel(new DeviceStateMachine());
        
        public IViewModel ViewModel => _consoleViewModel;

        public string RoadmapIssueUrl => "https://github.com/nickhepp/embedded-device-prototyping-framework/issues/10";

        public ToolState State => ToolState.Roadmap;

        public ToolBoxWindowCohort(List<IToolWindowCohort> cohorts)
        {
            _toolWindow = new Lazy<ToolWindow>(() =>
            {
                //ToolBoxView toolBoxView = new ToolBoxView();
                NotImplementedView notImplementedView = new NotImplementedView(RoadmapIssueUrl);

                ToolWindow toolWindow = new ToolWindow();
                toolWindow.Initialize(notImplementedView, this.Name);

                IntPtr Hicon = HostApp.Properties.Resources.construction.GetHicon();
                Icon toolBoxIcon = Icon.FromHandle(Hicon);
                toolWindow.Icon = toolBoxIcon;
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
