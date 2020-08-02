using HostApp.UI;
using HostApp.UI.ViewModels;
using HostApp.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.Factories
{
    public static class ViewFactory
    {






        public static IMainView GetMainView(IMainViewModel mainViewModel)
        {

            IMainView mainView = null;

            if (mainViewModel is ISimpleMainViewModel simpleMainViewModel)
            {
                mainView = new SimpleMainView();
            }
            else
            {
                mainView = new ParentMainView();
            }

            mainView.SetMainViewModel(mainViewModel);

            return mainView;
        }

    }
}
