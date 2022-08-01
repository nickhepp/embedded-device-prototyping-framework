using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ecs.Edpf.GUI.UI.ViewModels;
using System.Windows.Input;
using Ecs.Edpf.GUI.UI.Views;
using Ecs.Edpf.Devices;
using Ecs.Edpf.GUI.UI;
using Ecs.Edpf.Devices.Connections;
using Ecs.Edpf.GUI.UI.ViewModels.Connections;

namespace Ecs.Edpf.GUI.UI.Views
{
    public partial class ConnectionView : UserControl, IChildView
    {

        private IConnectionViewModel _connectionViewModel;
        public IChildViewModel ViewModel {
            get
            {
                return _connectionViewModel;

            }
            set
            {
                _connectionViewModel = value as IConnectionViewModel;
                UpdateConnectionViewModelBindings();
                _settingsPpg.SelectedObject = _connectionViewModel?.DeviceConnectionSettingsViewModel;
            }
        }

        public ConnectionView()
        {
            InitializeComponent();
        }


        private void UpdateConnectionViewModelBindings()
        {
            _openBtn.DataBindings.Clear();
            _openBtn.DataBindings.Add(new Binding(nameof(Button.Enabled), _connectionViewModel, nameof(IConnectionViewModel.OpenButtonEnabled)));
            _closeBtn.DataBindings.Clear();
            _closeBtn.DataBindings.Add(new Binding(nameof(Button.Enabled), _connectionViewModel, nameof(IConnectionViewModel.CloseButtonEnabled)));

            DataBindings.Clear();
            DataBindings.Add(new Binding(nameof(Control.Enabled), _connectionViewModel, nameof(IConnectionViewModel.Enabled)));
        
            if (_connectionViewModel != null)
            {
                _connectionViewModel.PropertyChanged += ConnectionViewModelPropertyChanged;
            }
            UpdateErrorWarningLabel();
        }

        private void UpdateErrorWarningLabel()
        {
            if (_connectionViewModel == null || string.IsNullOrEmpty(_connectionViewModel.OpenFailedErrorMessage))
            {
                _errMessageTssl.Text = "";
                _errMessageTssl.Visible = false;
            }
            else
            {
                _errMessageTssl.Text = _connectionViewModel.OpenFailedErrorMessage;
                _errMessageTssl.Visible = true;
            }
        }

        private void ConnectionViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IConnectionViewModel.OpenFailedErrorMessage))
            {
                UpdateErrorWarningLabel();
            }
        }

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            _connectionViewModel.OpenCommand.Execute(null);
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            _connectionViewModel.CloseCommand.Execute(null);
        }

    }
}
