﻿using Ecs.Edpf.GUI.UI.ViewModels;
using Ecs.Edpf.GUI.UI.ViewModels.Connections;
using Ecs.Edpf.GUI.UI.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeifenLuo.WinFormsUI.Docking;

namespace HostApp.UI.Views
{
    public class ConnectionsToolWindowCohort : IToolWindowCohort
    {
        public string Name => "Connections";

        public Bitmap Image => Ecs.Edpf.GUI.Properties.Resources.baseline_cable_black;

        private Lazy<ToolWindow> _toolWindow;


        private IConnectionViewModelFactoryViewModel _connectionViewModelFactoryViewModel;

        public IViewModel ViewModel => _connectionViewModelFactoryViewModel;


        public ConnectionsToolWindowCohort()
        {
            _connectionViewModelFactoryViewModel = new ConnectionViewModelFactoryViewModel();

            _toolWindow = new Lazy<ToolWindow>(() =>
            {
                ConnectionsView connectionsView = new ConnectionsView();
                connectionsView.ViewModel = _connectionViewModelFactoryViewModel;
                ToolWindow toolWindow = new ToolWindow();
                toolWindow.Initialize(connectionsView, this.Name);
                IntPtr Hicon = Ecs.Edpf.GUI.Properties.Resources.baseline_cable_black.GetHicon();
                Icon cmdIcon = Icon.FromHandle(Hicon);
                toolWindow.Icon = cmdIcon;

                return toolWindow;
            });
        }

        public ToolWindow GetToolWindow()
        {
            return _toolWindow.Value;
        }


    }
}