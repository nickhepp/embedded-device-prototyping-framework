using Ecs.Edpf.Devices.Charting;
using Ecs.Edpf.Devices.ComponentModel;
using Ecs.Edpf.GUI.ComponentModel;
using Ecs.Edpf.GUI.UI.ViewModels;
using Ecs.Edpf.GUI.UI.ViewModels.Charting;
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

        private IChartingViewModel _chartingViewModel;

        private IChartSampleCollector _chartSampleCollector;

        private IChartingExpressionFilter _chartingExpressionFilter;

        private ChartingView _chartingView;

        public IViewModel ViewModel => _chartingViewModel;




        public string RoadmapIssueUrl => "https://github.com/nickhepp/embedded-device-prototyping-framework/issues/4";

        public ToolState State => ToolState.Roadmap;

        public ChartingToolWindowCohort()
        {
            // a default set of settings
            ChartSettings chartSettings = new ChartSettings
            {
                Expression = "vals:{a|chart1},{b|chart2},{c|chart2}",
                ExpressionType = Ecs.Edpf.Devices.ComponentModel.ExpressionType.Simple,
                XAxisType = XAxisType.SampleNumber,
            };

            _chartingView = new ChartingView();

            _chartingExpressionFilter = new SimpleChartingExpressionFilter();

            _chartSampleCollector = new ChartSampleCollector(
                    _chartingExpressionFilter,
                    chartSettings,
                    new DateTimeProvider());

            _chartingViewModel = new ChartingViewModel(
                _chartSampleCollector,
                _chartingExpressionFilter,
                _chartingView,
                chartSettings,
                new DeviceStateMachine());

            _toolWindow = new Lazy<ToolWindow>(() =>
            {
                _chartingView.ViewModel = (IChildViewModel)_chartingViewModel;
                ToolWindow toolWindow = new ToolWindow();
                toolWindow.DockAreas |= WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
                toolWindow.Initialize(_chartingView, this.Name);
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
