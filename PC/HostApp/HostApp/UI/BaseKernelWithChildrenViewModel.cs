using HostApp.UI.ChildUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace HostApp.UI
{
    public class BaseKernelWithChildrenViewModel : BaseKernelViewModel, IChildViewModelProvider
    {
 


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
