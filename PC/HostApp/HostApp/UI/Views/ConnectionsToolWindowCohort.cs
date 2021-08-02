using Ecs.Edpf.Devices.Devices;
using Ecs.Edpf.GUI.ComponentModel;
using Ecs.Edpf.GUI.UI.ViewModels;
using Ecs.Edpf.GUI.UI.ViewModels.Connections;
using Ecs.Edpf.GUI.UI.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeifenLuo.WinFormsUI.Docking;

namespace HostApp.UI.Views
{
    public class ConnectionsToolWindowCohort : IToolWindowCohort
    {
        public string Name => "Connections";

        public string Description => "Establish connections to devices over multiple connection options.";


        public Bitmap Image => HostApp.Properties.Resources.baseline_cable_black;

        private Lazy<ToolWindow> _toolWindow;


        private IConnectionViewModelFactoryViewModel _connectionViewModelFactoryViewModel;

        public IViewModel ViewModel => _connectionViewModelFactoryViewModel;

        public string RoadmapIssueUrl => null;

        public ToolState State => ToolState.Active;

        public ConnectionsToolWindowCohort()
        {
            DeviceStateMachine deviceStateMachine = new DeviceStateMachine();

            List<IConnectionViewModel> connectionViewModels = new List<IConnectionViewModel>
            {
                new SerialPortConnectionViewModel(deviceStateMachine),
                //new FakeConnectionViewModel(deviceStateMachine),
            };
            CompositeDeviceProvider compositeDeviceProvider = new CompositeDeviceProvider(connectionViewModels.Select(connViewMdl => connViewMdl.GetDeviceFactory()));

            _connectionViewModelFactoryViewModel = new ConnectionViewModelFactoryViewModel(deviceStateMachine, compositeDeviceProvider, connectionViewModels);

            _toolWindow = new Lazy<ToolWindow>(() =>
            {
                ConnectionsView connectionsView = new ConnectionsView();
                connectionsView.ViewModel = _connectionViewModelFactoryViewModel;
                ToolWindow toolWindow = new ToolWindow();
                toolWindow.Initialize(connectionsView, this.Name);
                IntPtr Hicon = HostApp.Properties.Resources.baseline_cable_black.GetHicon();
                Icon cmdIcon = Icon.FromHandle(Hicon);
                toolWindow.Icon = cmdIcon;

                return toolWindow;
            });
        }

        public ToolWindow GetToolWindow()
        {
            return _toolWindow.Value;
        }


    }
}
