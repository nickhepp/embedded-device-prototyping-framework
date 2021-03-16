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
    public class ChartingToolWindowCohort : IToolWindowCohort
    {
        public string Name => "Charting";

        public string Description => "Watches for the flow of device data and charts multiple values. " +
            "The charting tools filter on device output to automatically chart data with signatures " +
            "that match the filter.";

        public Bitmap Image => HostApp.Properties.Resources.charts;

        private Lazy<ToolWindow> _toolWindow;

        private IChartingViewModel _chartingViewModel = new ChartingViewModel(new DeviceStateMachine());

        public IViewModel ViewModel => _chartingViewModel;


        public ChartingToolWindowCohort()
        {

            _toolWindow = new Lazy<ToolWindow>(() =>
            {
                ChartingView chartingView = new ChartingView();
                chartingView.ChartingViewModel = _chartingViewModel;
                ToolWindow toolWindow = new ToolWindow();
                toolWindow.DockAreas |= WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
                toolWindow.Initialize(chartingView, this.Name);
                IntPtr chartIconPtr = HostApp.Properties.Resources.charts.GetHicon();
                Icon chartIcon = Icon.FromHandle(chartIconPtr);
                toolWindow.Icon = chartIcon;

                return toolWindow;
            });
        }

        public ToolWindow GetToolWindow()
        {
            return _toolWindow.Value;
        }
    }
}
