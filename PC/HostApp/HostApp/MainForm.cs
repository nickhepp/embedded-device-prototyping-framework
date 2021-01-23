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
using Ecs.Edpf.GUI.UI.ViewModels;
using HostApp.Devices;
using HostApp.UI;
using HostApp.UI.ViewModels;
using HostApp.UI.Views;

namespace HostApp
{
    public partial class MainForm : Form
    {

        private WeifenLuo.WinFormsUI.Docking.DockPanel _dockPanel;
        private IHostAppMainViewModel _hostAppMainViewModel;
        private List<ToolWindow> _toolWindows;


        public MainForm()
        {
            InitializeComponent();

            this.Load += MainForm_Load;

            this.Text = $"{this.Text} V{System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}";





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

            _toolWindows = new List<ToolWindow>();
            foreach (IToolWindowCohort toolWindowCohort in toolWindowCohortFactory.GetToolWindowCohorts())
            {
                ToolStripMenuItem tsm = new ToolStripMenuItem(toolWindowCohort.Name);
                tsm.Tag = toolWindowCohort.GetToolWindow();
                tsm.Click += ToolWindowMenuItemClick;
                _toolsTsm.DropDownItems.Add(tsm);
            }
        }

        private void ToolWindowMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem tsm = (ToolStripMenuItem)sender;
            ToolWindow toolWindow = (ToolWindow)tsm.Tag;
            //toolWindow.MdiParent = this;
 
            toolWindow.Show(_dockPanel);
        }


        private void _exitTsm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
