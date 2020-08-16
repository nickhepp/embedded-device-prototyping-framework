﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HostApp.UI.ViewModels;
using System.Windows.Input;
using HostApp.UI.ChildUI.Views;
using Ecs.Edpf.Devices;
using HostApp.UI.ChildUI;
using Ecs.Edpf.Devices.Connections;

namespace HostApp.UI.Views
{
    public partial class ConnectionView : UserControl, IChildView
    {


        public IDevice Device { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
        }


        private void UpdateConnectionSettingsPpg()
        {

        }

        private void SetDevice()
        {
            if (Device == null)
            {
                _settingsPpg.SelectedObject = null;
            }
            else
            {

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