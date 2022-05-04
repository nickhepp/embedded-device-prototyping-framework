using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
using HostApp.ComponentModel;
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
        private DockPanel _dockPanel;
        private IHostAppMainViewModel _hostAppMainViewModel;
        private List<ToolWindow> _toolWindows;
        private List<IToolWindowCohort> _toolWindowCohorts;
        private bool _showSplash;
        private SplashScreen _splashScreen;
        private IWarningMessageBoxService _warningMessageBoxService;

        public MainForm()
        {
            InitializeComponent();

            _warningMessageBoxService = new WarningMessageBoxService();
            this.Load += MainForm_Load;
            this.FormClosing += MainFormFormClosing;  
            
            this.Text = $"{this.Text} V{System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}";
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            List<ICloseCancelable> closeCancelables = _toolWindowCohorts.Where(twc => twc.ViewModel is ICloseCancelable).ToList().ConvertAll(twc => (ICloseCancelable)twc.ViewModel);
            List<string> cancelReasons = closeCancelables.Select(cc => cc.GetCancelCloseReason()).Where(cancelReason => cancelReason != null).ToList();
            if (cancelReasons.Count > 0)
            {
                e.Cancel = true;
                MessageBox.Show(text: string.Join(Environment.NewLine, cancelReasons), caption: "Close Canceled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // intitiate the start of closing
                List<IWaitForCompletable> completables = _toolWindowCohorts.Where(twc => twc.ViewModel is IWaitForCompletable).ToList().ConvertAll(twc => (IWaitForCompletable)twc.ViewModel);
                foreach (IWaitForCompletable completable in completables)
                {
                    completable.BeginCompletion();
                }

                // wait for the closing actions to complete
                foreach (IWaitForCompletable completable in completables)
                {
                    completable.WaitForCompletion();
                }

                // when attempting the above, the lines below still created issues
                //IDeviceViewModel deviceViewModel = _toolWindowCohorts.Where(twc => twc.ViewModel is IDeviceViewModel).Select(twc => (IDeviceViewModel)twc.ViewModel).FirstOrDefault();
                //if (deviceViewModel != null && deviceViewModel.Device != null && deviceViewModel.Device.IsOpen)
                //{
                //    deviceViewModel.Device.Close();
                //}
            }

            base.OnFormClosing(e);
        }


        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {


        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;

            _hostAppMainViewModel = new HostAppMainViewModel();
  
            _dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            _mainPnl.Controls.Add(_dockPanel);
            _dockPanel.Dock = DockStyle.Fill;
            _dockPanel.ShowDocumentIcon = true;

            _dockPanel.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;

            IDeviceProviderRegistry deviceProviderRegistry = new DeviceProviderRegistry();

            ToolWindowCohortFactory toolWindowCohortFactory = new ToolWindowCohortFactory(deviceProviderRegistry);
            toolWindowCohortFactory.Initialize();

            deviceProviderRegistry.SynchronizeRegistry();

            _toolWindowCohorts = toolWindowCohortFactory.GetToolWindowCohorts();
            Dictionary<string, IToolWindowCohort> dockContents = new Dictionary<string, IToolWindowCohort>(); 
            _toolWindows = new List<ToolWindow>();
            foreach (IToolWindowCohort toolWindowCohort in _toolWindowCohorts)
            {
                ToolStripMenuItem tsm = new ToolStripMenuItem(toolWindowCohort.Name);
                ToolWindow toolWindow = toolWindowCohort.GetToolWindow();
                if (toolWindowCohort.Image != null)
                {
                    tsm.Image = toolWindowCohort.Image;
                }
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

            SetSplashScreen(toolWindowCohortFactory.GetToolWindowCohorts());

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

        private void SetSplashScreen(List<IToolWindowCohort> cohorts)
        {

            _showSplash = true;
            _splashScreen = new SplashScreen();
            _splashScreen.SetToolWindows(cohorts);

            ResizeSplash();
            _splashScreen.Visible = true;
            _splashScreen.TopMost = true;

        }

        private void ResizeSplash()
        {
            if (_showSplash)
            {

                var centerXMain = (this.Location.X + this.Width) / 2.0;
                var LocationXSplash = Math.Max(0, centerXMain - (_splashScreen.Width / 2.0));

                var centerYMain = (this.Location.Y + this.Height) / 2.0;
                var LocationYSplash = Math.Max(0, centerYMain - (_splashScreen.Height / 2.0));

                _splashScreen.Location = new Point((int)Math.Round(LocationXSplash), (int)Math.Round(LocationYSplash));
            }
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

        private void _shareAnIdeaTsm_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Ecs.Edpf.Devices.Constants.ProjectDiscussionsUrl);
            }
            catch (Exception ex)
            {
                _warningMessageBoxService.ShowWarningMessageBox(ex.Message, "!!Error visiting project discussions!!");
            }
        }

        private void _reportBugTsm_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Ecs.Edpf.Devices.Constants.ProjectBugsUrl);
            }
            catch (Exception ex)
            {
                _warningMessageBoxService.ShowWarningMessageBox(ex.Message, "!!Error visiting project bugs!!");
            }
        }
    }
}
