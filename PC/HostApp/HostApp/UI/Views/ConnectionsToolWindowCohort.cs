using Ecs.Edpf.GUI.UI.ViewModels.Connections;
using Ecs.Edpf.GUI.UI.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.UI.Views
{
    public class ConnectionsToolWindowCohort : IToolWindowCohort
    {
        public string Name => "Connections";

        public Bitmap Image => throw new NotImplementedException();

        private Lazy<ToolWindow> _toolWindow;

        public ConnectionsToolWindowCohort()
        {
            _toolWindow = new Lazy<ToolWindow>(() =>
            {
                IConnectionViewModelFactoryViewModel connectionViewModelFactoryViewModel = new ConnectionViewModelFactoryViewModel();
                ConnectionsView connectionsView = new ConnectionsView();
                connectionsView.ViewModel = connectionViewModelFactoryViewModel;

                ToolWindow toolWindow = new ToolWindow();
                toolWindow.Initialize(connectionsView, this.Name);
                return toolWindow;
            });
        }

        public ToolWindow GetToolWindow()
        {
            return _toolWindow.Value;
        }

    }
}
