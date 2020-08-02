using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HostApp;
using HostApp.UI;
using HostApp.UI.ViewModels;
using HostApp.UI.Views;

namespace HostApp.UI
{
    public static class ViewModelFactory
    {

        public static IMainViewModel GetMainViewModel()
        {
            SimpleMainViewModel simpleMainViewModel = new SimpleMainViewModel();
            return simpleMainViewModel;
        }



    }
}
