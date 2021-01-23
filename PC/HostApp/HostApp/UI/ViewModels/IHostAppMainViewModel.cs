using Ecs.Edpf.GUI.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HostApp.UI.ViewModels
{
    public interface IHostAppMainViewModel : IMainViewModel
    {


        List<IChildViewModel> GetChildViewModels();

    }
}
