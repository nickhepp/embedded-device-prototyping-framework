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

        public Bitmap Image => throw new NotImplementedException();


        private Lazy<ToolWindow> _toolWindow;

        private IDeviceCommandsViewModel _deviceCommandsViewModel;
        public IViewModel ViewModel => _deviceCommandsViewModel;


        public DeviceCommandsToolWindowCohort()
        {
            _deviceCommandsViewModel = new DeviceCommandsViewModel();
            _toolWindow = new Lazy<ToolWindow>(() => 
            {
                
                DeviceCommandsView deviceCommandsView = new DeviceCommandsView
                {
                    ViewModel = _deviceCommandsViewModel
                };

                ToolWindow toolWindow = new ToolWindow();
                toolWindow.Initialize(deviceCommandsView, this.Name);
                return toolWindow;
            });

        }



        public ToolWindow GetToolWindow()
        {
            return _toolWindow.Value;
        }
    }
}
