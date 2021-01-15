using Ecs.Edpf.GUI.UI.ViewModels;
using Ecs.Edpf.GUI.UI.Views;
using HostApp.Simple.UI.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostApp.Simple
{
    public partial class MainForm : Form
    {

        private SimpleMainView _mainView;



        public MainForm()
        {
            InitializeComponent();

            Load += MainFormLoad;

        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            _mainView = new SimpleMainView();
            this.Controls.Add(_mainView);
            _mainView.Dock = DockStyle.Fill;
        }

    }
}
