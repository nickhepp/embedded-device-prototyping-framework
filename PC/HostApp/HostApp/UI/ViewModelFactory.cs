using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HostApp;
using HostApp.UI;

namespace HostApp.UI
{
    public static class ViewModelFactory
    {

        public static IViewModel GetViewModel()
        {
            return GetViewModel(AppInfo.ViewModelTypeName);
        }

        private static IViewModel GetViewModel(string viewModelType)
        {
            // fill this with any actual view model to test it out

            Type type = Type.GetType(viewModelType);
            if (type == null)
            {
                throw new Exception(string.Format("Could not create view model '{0}'.", viewModelType));
            }

            IViewModel vwMdl = (IViewModel)Activator.CreateInstance(type);
            return vwMdl;
        }


    }
}
