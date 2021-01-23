using Ecs.Edpf.Devices;

using Ecs.Edpf.GUI.UI;
using Ecs.Edpf.GUI.UI.ViewModels;
using System;
using System.Collections.Generic;

namespace HostApp.UI.ViewModels
{
    public class HostAppMainViewModel : IHostAppMainViewModel
    {

        public List<IChildViewModel> GetChildViewModels()
        {
            List<IChildViewModel> childViewModels = new List<IChildViewModel>
            {

            };

            return childViewModels;
        }
    }
}
