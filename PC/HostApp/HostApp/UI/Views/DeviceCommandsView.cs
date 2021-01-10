using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;
using HostApp.UI.ChildUI.Views;
using HostApp.UI.ChildUI;
using HostApp.UI.ViewModels;

namespace HostApp.UI.Views
{
    public partial class DeviceCommandsView : UserControl, IChildView
    {

        private IDeviceCommandsViewModel _deviceCommandsViewModel;

        private bool _populatingTabs = false;

        public DeviceCommandsView()
        {
            InitializeComponent();
            _commandsTab.Selected += CommandsTabSelected;
        }

        private void CommandsTabSelected(object sender, TabControlEventArgs e)
        {
            if ((e.Action == TabControlAction.Selected) && (e.TabPage != null))
            {
                IDeviceCommandViewModel selectedDevCmdVwMdl = e.TabPage.Tag as IDeviceCommandViewModel;
                if (!_populatingTabs && (selectedDevCmdVwMdl != null))
                {
                    _deviceCommandsViewModel.SelectedDeviceCommandViewModel = selectedDevCmdVwMdl;
                }
            }
        }

        public IChildViewModel ViewModel
        {
            get
            {
                return _deviceCommandsViewModel;
            }
            set
            {
                _deviceCommandsViewModel = value as IDeviceCommandsViewModel;

                _executeCmdBtn.DataBindings.Clear();
                if (_deviceCommandsViewModel != null)
                {
                    _deviceCommandsViewModel.DeviceCommandViewModels.ListChanged += DeviceCommandViewModelsListChanged;

                    _executeCmdBtn.DataBindings.Add(new Binding(nameof(Button.Text), _deviceCommandsViewModel, nameof(IDeviceCommandsViewModel.SelectedCommandExecuteButtonText)));
                    _executeCmdBtn.DataBindings.Add(new Binding(nameof(Button.Enabled), _deviceCommandsViewModel, nameof(IDeviceCommandsViewModel.SelectedCommandExecuteButtonEnabled)));
                }

            }
        }

        private void DeviceCommandViewModelsListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.Reset)
            {
                _populatingTabs = true;

                _commandsTab.TabPages.Clear();

                foreach (IDeviceCommandViewModel devCmdVwMdl in _deviceCommandsViewModel.DeviceCommandViewModels)
                {
                    DeviceCommandView deviceCommandView = new DeviceCommandView();
                    TabPage tbpg = new TabPage();
                    tbpg.Tag = devCmdVwMdl;
                    tbpg.Text = devCmdVwMdl.MethodName;
                    tbpg.Controls.Add(deviceCommandView);
                    deviceCommandView.Dock = DockStyle.Fill;
                    _commandsTab.TabPages.Add(tbpg);

                    if (object.ReferenceEquals(devCmdVwMdl, _deviceCommandsViewModel.SelectedDeviceCommandViewModel))
                    {
                        tbpg.Select();
                    }

                    deviceCommandView.DeviceCommandViewModel = devCmdVwMdl;
                }

                _populatingTabs = false;
            }

        }

        private void _executeCmdBtn_Click(object sender, EventArgs e)
        {
            _deviceCommandsViewModel.SelectedCommand.Execute(null);
        }
    }
}
