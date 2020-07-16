using HostApp.Business;
using HostApp.UI.ChildUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace HostApp.UI.ViewModels
{
    public class ParentMainViewModel : IParentMainViewModel
    {
        public IDevice Device { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public List<IChildViewModel> GetChildViewModels()
        {
            List<IChildViewModel> childViewModels = new List<IChildViewModel>
            {
                new DeviceConnectionSettingsViewModel()
            };

            return childViewModels;
        }
    }
}
