#define DATA_STORAGE_VIEW

using Ecs.Edpf.Devices.ComponentModel;
using Ecs.Edpf.Devices.Logging;
using Ecs.Edpf.GUI.ComponentModel;
using Ecs.Edpf.GUI.Logger;
using Ecs.Edpf.GUI.UI.ViewModels;
using Ecs.Edpf.GUI.UI.ViewModels.DataStorage;
using Ecs.Edpf.GUI.UI.Views;
using System;
using System.Drawing;

namespace HostApp.UI.Views
{

    public class DataStorageToolWindowCohort : IToolWindowCohort
    {
        public string Name => "Data Storage";

        public string Description => "Watches for the flow of device data and stores values to persistent storage. " +
            "The data storage tools filter on device output to automatically store data with signatures " +
            "that match the filters.";

        public Bitmap Image => HostApp.Properties.Resources.database;

        private Lazy<ToolWindow> _toolWindow;


        private IDataStorageViewModel _dataStorageViewModel;
        //private IChartingViewModel _chartingViewModel;

        //private IChartSampleCollector _chartSampleCollector;

        //private IChartingExpressionFilter _chartingExpressionFilter;

#if DATA_STORAGE_VIEW
        private DataStorageView _dataStorageView;

#else
        private NotImplementedView _dataStorageView;
#endif
        public IViewModel ViewModel => null;


        private const string _roadmapIssueUrl = "https://github.com/nickhepp/embedded-device-prototyping-framework/issues/55";

        public string RoadmapIssueUrl => _roadmapIssueUrl;

        public ToolState State => ToolState.InProgress;

        public DataStorageToolWindowCohort()
        {

#if DATA_STORAGE_VIEW
            _dataStorageView = new DataStorageView();

            LoggerFactory loggerFactory = new LoggerFactory(new DataStreamFileLoggerSettings());
            ILogger logger = loggerFactory.GetLogger();
            _dataStorageViewModel = new DataStorageViewModel(
                    logger,
                    new DeviceStateMachine());
#else
            _dataStorageView = new NotImplementedView(_roadmapIssueUrl);
#endif


            _toolWindow = new Lazy<ToolWindow>(() =>
            {
                ToolWindow toolWindow = new ToolWindow();
                toolWindow.DockAreas |= WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
                toolWindow.Initialize(_dataStorageView, this.Name);
                IntPtr dbIconPtr = HostApp.Properties.Resources.database.GetHicon();
                Icon dbIcon = Icon.FromHandle(dbIconPtr);
                toolWindow.Icon = dbIcon;

                return toolWindow;
            });
        }

        public ToolWindow GetToolWindow()
        {
            return _toolWindow.Value;
        }
    }



}
