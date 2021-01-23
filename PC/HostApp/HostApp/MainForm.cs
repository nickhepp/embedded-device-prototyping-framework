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
using HostApp.UI;
using HostApp.UI.ViewModels;

namespace HostApp
{
    public partial class MainForm : Form
    {

        private WeifenLuo.WinFormsUI.Docking.DockPanel _dockPanel;
        private IHostAppMainViewModel _hostAppMainViewModel;

        public MainForm()
        {
            InitializeComponent();

            this.Load += MainForm_Load;

            this.Text = $"{this.Text} V{System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}";


            _hostAppMainViewModel = new HostAppMainViewModel();

            _dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.Controls.Add(_dockPanel);
            _dockPanel.Dock = DockStyle.Fill;

  
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //_mainSpl.SplitterDistance = (int)(this.Width * 0.75);
            //_leftSpl.SplitterDistance = (int)(this.Height * 0.75);
        }

        private void _exitTsm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
