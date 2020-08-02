using System;
using System.Collections.Generic;
using System.Text;

namespace HostApp.UI.ViewModels
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
