using Ecs.Edpf.GUI.UI.ViewModels;
using HostApp.UI;
using HostApp.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp
{
    /// <summary>
    /// Class acts as a poor man's implementation of dependency injection.
    /// </summary>
    public static class AppInfo
    {

        public const string DeviceConnectionCategory = "Device Connection";

        public const string ViewModelCommandSuffix = "ViewModelCommand";

        public static string ViewModelTypeName { get; set; }

        public static string DeviceTypeName { get; set; }


        public static IMainViewModel GetMainViewModel()
        {
            IMainViewModel mainViewMdl = new ParentMainViewModel();
            return mainViewMdl;
        }


        public static void InitializeTypesWithBaseKernel()
        {
            ViewModelTypeName = "HostApp.UI.BaseKernelViewModel, HostApp";
            DeviceTypeName = "HostApp.Business.BaseKernelDevice, HostApp";

        }

    }
}
