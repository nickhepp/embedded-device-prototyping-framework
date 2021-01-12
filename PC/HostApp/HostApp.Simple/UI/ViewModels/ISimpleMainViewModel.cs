using Ecs.Edpf.GUI.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HostApp.Simple.UI.ViewModels
{
    public interface ISimpleMainViewModel : IMainViewModel
    {

        /// <summary>
        /// Gets the connection view model.
        /// </summary>
        /// <returns></returns>
        IConnectionViewModel GetConnectionViewModel();


        IConsoleControlViewModel GetConsoleControlViewModel();



    }
}
