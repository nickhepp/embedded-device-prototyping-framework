﻿using Ecs.Edpf.GUI.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.UI.Views
{
    public class ToolBoxWindowCohort : IToolWindowCohort
    {
        public string Name => "Toolbox";

        public Bitmap Image => HostApp.Properties.Resources.construction;

        private Lazy<ToolWindow> _toolWindow;


        private IConsoleViewModel _consoleViewModel = new ConsoleViewModel();
        public IViewModel ViewModel => _consoleViewModel;

        public ToolBoxWindowCohort(List<IToolWindowCohort> cohorts)
        {
            _toolWindow = new Lazy<ToolWindow>(() =>
            {
                ToolBoxView toolBoxView = new ToolBoxView();

                ToolWindow toolWindow = new ToolWindow();
                toolWindow.Initialize(toolBoxView, this.Name);

                IntPtr Hicon = HostApp.Properties.Resources.construction.GetHicon();
                Icon toolBoxIcon = Icon.FromHandle(Hicon);
                toolWindow.Icon = toolBoxIcon;
                toolWindow.ShowIcon = true;
                return toolWindow;
            });
        }

        public ToolWindow GetToolWindow()
        {
            return _toolWindow.Value;
        }
    }
}