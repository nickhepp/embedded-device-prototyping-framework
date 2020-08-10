using HostApp.ManualTest.Business;
using HostApp.ManualTest.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostApp.ManualTest
{
    public partial class MainTestForm : Form
    {

        private MainTestViewModel _mainTestViewModel;

        public class ViewConfigurationWrapper
        {
            public string ViewName { get; set; }

            public ViewConfiguration ViewConfiguration { get; set; }
        }

        public MainTestForm()
        {
            InitializeComponent();

            _mainTestViewModel = new MainTestViewModel();

            List<ViewConfiguration> viewConfigs = _mainTestViewModel.ViewConfigurationFactory.GetViewConfigurations();
            List<ViewConfigurationWrapper> viewConfigWrappers = viewConfigs.Select(viewConfig => new ViewConfigurationWrapper
            { ViewName = viewConfig.ViewName, ViewConfiguration = viewConfig }).ToList();

            _ctrlSelectionCbx.DataSource = viewConfigWrappers;
            _ctrlSelectionCbx.DisplayMember = nameof(ViewConfigurationWrapper.ViewName);
            _ctrlSelectionCbx.ValueMember = nameof(ViewConfigurationWrapper.ViewConfiguration);
            _ctrlSelectionCbx.SelectedIndexChanged += CtrlSelectionCbx_SelectedIndexChanged1;
        }

        private void CtrlSelectionCbx_SelectedIndexChanged1(object sender, EventArgs e)
        {
            _ctrlPnl.Controls.Clear();

            ViewConfiguration viewConfigWrapper = _ctrlSelectionCbx.SelectedValue as ViewConfiguration;
            Control ctrl = viewConfigWrapper.GetControl();
            _ctrlPnl.Controls.Add(ctrl);
            ctrl.Dock = DockStyle.Fill;

        }


    }
}
