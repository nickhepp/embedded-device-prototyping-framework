using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Ecs.Edpf.Devices.IO.File;
using Ecs.Edpf.GUI.Settings;
using Ecs.Edpf.GUI.UI.ViewModels;
using HostApp.Devices;
using HostApp.UI;
using HostApp.UI.Settings;
using HostApp.UI.ViewModels;
using HostApp.UI.Views;
using Ninject;
using WeifenLuo.WinFormsUI.Docking;

namespace HostApp
{
    public partial class MainForm : Form
    {
        private ISettingsManager _settingsManager;
        private ISettingsResourceStore _settingsResourceStore;
        private DockPanelSettingsResource _dockPanelSettingsResource;
        private WeifenLuo.WinFormsUI.Docking.DockPanel _dockPanel;
        private IHostAppMainViewModel _hostAppMainViewModel;
        private List<ToolWindow> _toolWindows;

        public MainForm()
        {
            InitializeComponent();

            this.Load += MainForm_Load;
            this.FormClosing += MainFormFormClosing;   

            this.Text = $"{this.Text} V{System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}";
        }

        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            //_dockPanel.SaveAsXml()


            //string filePath = _recentFrmSettingsLst.Save();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;

            _hostAppMainViewModel = new HostAppMainViewModel();

  
            _dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            _mainPnl.Controls.Add(_dockPanel);
            _dockPanel.Dock = DockStyle.Fill;

         
            _dockPanel.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;

            IDeviceProviderRegistry deviceProviderRegistry = new DeviceProviderRegistry();

            ToolWindowCohortFactory toolWindowCohortFactory = new ToolWindowCohortFactory(deviceProviderRegistry);
            deviceProviderRegistry.SynchronizeRegistry();

            Dictionary<string, IToolWindowCohort> dockContents = new Dictionary<string, IToolWindowCohort>(); 
            _toolWindows = new List<ToolWindow>();
            foreach (IToolWindowCohort toolWindowCohort in toolWindowCohortFactory.GetToolWindowCohorts())
            {
                ToolStripMenuItem tsm = new ToolStripMenuItem(toolWindowCohort.Name);
                ToolWindow toolWindow = toolWindowCohort.GetToolWindow();
                dockContents[toolWindow.GetType().ToString()] = toolWindowCohort;
                tsm.Tag = toolWindow;
                tsm.Click += ToolWindowMenuItemClick;
                _toolsTsm.DropDownItems.Add(tsm);
            }

            _dockPanelSettingsResource = new DockPanelSettingsResource(_dockPanel, dockContents, toolWindowCohortFactory);

            IKernel container = GetConfiguredContainer();

            _settingsResourceStore = new SettingsResourceStore();
            _settingsResourceStore.AddSettingsResource(_dockPanelSettingsResource);

            _settingsManager = container.Get<ISettingsManager>();
            _settingsManager.ApplyCurrentSettings(_settingsResourceStore);
        }

        private IKernel GetConfiguredContainer()
        {
            IKernel container = new StandardKernel();
            container.Bind<ISettingsManager>().To<SettingsManager>();
            container.Bind<IRecentSettingsListFactory>().To<RecentSettingsListFactory>();
            container.Bind<IFile>().To<EdpfFile>();
            container.Bind<ISettingsResourceStore>().To<SettingsResourceStore>();

            return container;
        }


        private void ToolWindowMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem tsm = (ToolStripMenuItem)sender;
            ToolWindow toolWindow = (ToolWindow)tsm.Tag;

            toolWindow.Show(_dockPanel);
        }


        private void _exitTsm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
