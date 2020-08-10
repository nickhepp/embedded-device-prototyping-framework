using Ecs.Edpf.Devices;

using HostApp.UI.ChildUI;
using HostApp.UI.ChildUI.ViewModels;
using System;
using System.Collections.Generic;

namespace HostApp.UI.ViewModels
{
    public class ParentMainViewModel : IParentMainViewModel
    {
        public IDevice Device { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IDeviceFactory DeviceFactory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public List<IChildViewModel> GetChildViewModels()
        {
            List<IChildViewModel> childViewModels = new List<IChildViewModel>
            {
                new ComPortConnectionSettingsViewModel()
            };

            return childViewModels;
        }
    }
}
