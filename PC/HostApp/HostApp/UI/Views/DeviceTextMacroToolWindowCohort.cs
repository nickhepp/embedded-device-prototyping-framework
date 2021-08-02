using Ecs.Edpf.GUI.ComponentModel;
using Ecs.Edpf.GUI.ComponentModel.Macros;
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
    public class DeviceTextMacroToolWindowCohort : IToolWindowCohort
    {
        public string Name => "Macros";

        public string Description => "Record and playback multiple operations to send to the device. Supports both " +
            "oneshot and looping macros on a timer.";

        public Bitmap Image => HostApp.Properties.Resources.repeat;

        private Lazy<ToolWindow> _toolWindow;

        private IDeviceTextMacroViewModel _deviceTextMacroViewModel = new DeviceTextMacroViewModel(new DeviceTextMacroStateMachine(), new DeviceTextMacroBgWorkerFactory());

        public IViewModel ViewModel => _deviceTextMacroViewModel;

        public string RoadmapIssueUrl => "https://github.com/nickhepp/embedded-device-prototyping-framework/issues/5";

        public ToolState State => ToolState.InProgress;

        public DeviceTextMacroToolWindowCohort()
        {

            _toolWindow = new Lazy<ToolWindow>(() =>
            {
                DeviceTextMacroView deviceTextMacroView = new DeviceTextMacroView();
                deviceTextMacroView.Enabled = false;
                deviceTextMacroView.DeviceTextMacroViewModel = _deviceTextMacroViewModel;
                ToolWindow toolWindow = new ToolWindow();

                NotImplementedView notImplementedView = new NotImplementedView(deviceTextMacroView, RoadmapIssueUrl);
                toolWindow.Initialize(notImplementedView, this.Name);
                IntPtr repeatIconPtr = HostApp.Properties.Resources.repeat.GetHicon();
                Icon repeatIcon = Icon.FromHandle(repeatIconPtr);
                toolWindow.Icon = repeatIcon;

                return toolWindow;
            });
        }

        public ToolWindow GetToolWindow()
        {
            return _toolWindow.Value;
        }
    }
}
