using Ecs.Edpf.GUI.ComponentModel;
using Ecs.Edpf.GUI.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecs.Edpf.GUI.UI.Views
{
    public partial class AddDeviceCommandsToMacroView : UserControl
    {

        private List<RelayCommandHandler> _relayCmdHandlers = new List<RelayCommandHandler>();

        private bool _populatingTabs = false;

        private IAddDeviceCommandsToMacroViewModel _deviceCommandsViewModel;
        public IAddDeviceCommandsToMacroViewModel ViewModel
        {
            get
            {
                return _deviceCommandsViewModel;
            }
            set
            {
                _deviceCommandsViewModel = value;

                _executeCmdBtn.DataBindings.Clear();
                if (_deviceCommandsViewModel != null)
                {
                    _deviceCommandsViewModel.DeviceCommandViewModels.ListChanged += DeviceCommandViewModelsListChanged;

                    _executeCmdBtn.DataBindings.Add(new Binding(nameof(Button.Text), _deviceCommandsViewModel, nameof(IDeviceCommandsViewModel.SelectedCommandExecuteButtonText)));

                    _relayCmdHandlers.Clear();

                    //_relayCmdHandlers.Add(
                    //    new RelayCommandHandler(_executeCmdBtn, _deviceCommandsViewModel.SelectedCommand, relayCommandExHandler: this, getCommandArgHandler: GetInstructionCollectionInitArgs));



                    _executeCmdBtn.DataBindings.Add(new Binding(nameof(Button.Enabled), _deviceCommandsViewModel, nameof(IDeviceCommandsViewModel.SelectedCommandExecuteButtonEnabled)));
                }

            }
        }


        public AddDeviceCommandsToMacroView()
        {
            InitializeComponent();
            _commandsTab.Selected += CommandsTabSelected;
        }

        private void CommandsTabSelected(object sender, TabControlEventArgs e)
        {
            if ((e.Action == TabControlAction.Selected) && (e.TabPage != null))
            {
                IGetDeviceCommandLinesViewModel selectedDevCmdVwMdl = e.TabPage.Tag as IGetDeviceCommandLinesViewModel;
                if (!_populatingTabs && (selectedDevCmdVwMdl != null))
                {
                    _deviceCommandsViewModel.SelectedDeviceCommandViewModel = selectedDevCmdVwMdl;
                }
            }
        }


        private void DeviceCommandViewModelsListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.Reset)
            {
                _populatingTabs = true;

                _commandsTab.TabPages.Clear();

                TabPage selectedTabPage = null;
                foreach (IDeviceCommandViewModel devCmdVwMdl in _deviceCommandsViewModel.DeviceCommandViewModels)
                {
                    DeviceCommandView deviceCommandView = new DeviceCommandView();
                    TabPage tbpg = new TabPage();
                    tbpg.Tag = devCmdVwMdl;
                    tbpg.Text = devCmdVwMdl.MethodName;
                    tbpg.Controls.Add(deviceCommandView);
                    deviceCommandView.Dock = DockStyle.Fill;
                    _commandsTab.TabPages.Add(tbpg);

                    if (_deviceCommandsViewModel.SelectedDeviceCommandViewModel != null &&
                        _deviceCommandsViewModel.SelectedDeviceCommandViewModel.MethodName == devCmdVwMdl.MethodName)
                    {
                        selectedTabPage = tbpg;
                    }

                    deviceCommandView.DeviceCommandViewModel = devCmdVwMdl;
                }

                if (selectedTabPage != null)
                {
                    selectedTabPage.BringToFront();
                }

                _populatingTabs = false;
            }

        }



    }
}
