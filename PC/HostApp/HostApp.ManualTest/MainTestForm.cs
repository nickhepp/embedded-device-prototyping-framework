using HostApp.ManualTest.Business;
using HostApp.ManualTest.UI.ViewModels;
using HostApp.UI.ChildUI.ViewModels;
using HostApp.UI.ViewModels;
using HostApp.UI.ViewModels.Connections;
using HostApp.UI.Views;
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

        private FakeConnectionViewModel _fakeConnViewModel;


        public class ViewConfigurationWrapper
        {
            public string ViewName { get; set; }

            public ViewConfiguration ViewConfiguration { get; set; }
        }

        public MainTestForm()
        {
            InitializeComponent();

        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _mainTestViewModel = new MainTestViewModel();

            List<ViewConfiguration> viewConfigs = _mainTestViewModel.ViewConfigurationFactory.GetViewConfigurations();
            List<ViewConfigurationWrapper> viewConfigWrappers = viewConfigs.Select(viewConfig => new ViewConfigurationWrapper
            { ViewName = viewConfig.ViewName, ViewConfiguration = viewConfig }).ToList();

            _ctrlSelectionCbx.DataSource = viewConfigWrappers;
            _ctrlSelectionCbx.DisplayMember = nameof(ViewConfigurationWrapper.ViewName);
            _ctrlSelectionCbx.ValueMember = nameof(ViewConfigurationWrapper.ViewConfiguration);
            _ctrlSelectionCbx.SelectedIndexChanged += CtrlSelectionCbx_SelectedIndexChanged;


            _fakeConnViewModel = new FakeConnectionViewModel();
            ConnectionView connView = new ConnectionView();
            _connectionTpg.Controls.Add(connView);
            connView.Dock = DockStyle.Fill;
            connView.ViewModel = _fakeConnViewModel;

            _mainSpl.SplitterDistance = this.Width >> 1;

            // seed the first selection
            CtrlSelectionCbx_SelectedIndexChanged(this, new EventArgs());
        }



        private void CtrlSelectionCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ctrlPnl.Controls.Clear();

            ViewConfiguration viewConfigWrapper = _ctrlSelectionCbx.SelectedValue as ViewConfiguration;
            Control ctrl = viewConfigWrapper.GetControl();

            if (viewConfigWrapper.GetViewModel() is IDeviceViewModel deviceViewModel)
            {
                deviceViewModel.DeviceFactory = _fakeConnViewModel.DeviceFactory;
            }

            _ctrlPnl.Controls.Add(ctrl);
            ctrl.Dock = DockStyle.Fill;
        }


    }
}
