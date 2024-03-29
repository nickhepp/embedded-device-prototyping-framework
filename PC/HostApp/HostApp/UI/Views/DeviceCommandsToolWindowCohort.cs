﻿using Ecs.Edpf.Devices.ComponentModel;
using Ecs.Edpf.GUI.ComponentModel;
using Ecs.Edpf.GUI.UI.ViewModels;
using Ecs.Edpf.GUI.UI.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.UI.Views
{
    public class DeviceCommandsToolWindowCohort : IToolWindowCohort
    {
        public string Name => "Device Commands";

        public string Description => "Send arguments and execution instructions, much like a software " +
            "program calls methods. The host application queries the attached device to learn of " +
            "its capabilities and automatically creates a UI that honors the device's constraints.";

        public Bitmap Image => HostApp.Properties.Resources.function;


        private Lazy<ToolWindow> _toolWindow;

        private IDeviceCommandsViewModel _deviceCommandsViewModel;

        public IViewModel ViewModel => _deviceCommandsViewModel;

        public string RoadmapIssueUrl => null;

        public ToolState State => ToolState.Active;

        public DeviceCommandsToolWindowCohort()
        {
            _deviceCommandsViewModel = new DeviceCommandsViewModel(new DeviceStateMachine());
            _toolWindow = new Lazy<ToolWindow>(() => 
            {
                DeviceCommandsView deviceCommandsView = new DeviceCommandsView
                {
                    ViewModel = _deviceCommandsViewModel
                };

                ToolWindow toolWindow = new ToolWindow();
                toolWindow.Initialize(deviceCommandsView, this.Name);

                IntPtr functionIconPtr = HostApp.Properties.Resources.function.GetHicon();
                Icon functionIcon = Icon.FromHandle(functionIconPtr);
                toolWindow.Icon = functionIcon;
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
