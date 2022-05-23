using Ecs.Edpf.Devices.IO.File;
using Ecs.Edpf.GUI.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace HostApp.UI.Settings
{

    public class SettingsManager : ISettingsManager
    {

        ///// <summary>
        ///// The recent files for settings.
        ///// </summary>
        //private IRecentSettingsListFactory _recentSettingsListFactory;

        //public SettingsManager(IRecentSettingsListFactory recentSettingsListFactory)
        //{
        //    _recentSettingsListFactory = recentSettingsListFactory;
        //}

        //public void ApplyCurrentSettings(ISettingsResourceStore settingsResourceStore)
        //{
        //    Settings settings = _recentSettingsListFactory.GetRecentSettingsResourceStoresList().GetCurrentSettings();


        //    foreach (string resourceName in settingsResourceStore.SettingsResources.Keys)
        //    {
        //        if (settings.ResourceSettingsPayloads.ContainsKey(resourceName))
        //        {
        //            settingsResourceStore.SettingsResources[resourceName].ApplySettings(settings.ResourceSettingsPayloads[resourceName].Settings);
        //        }
        //        else
        //        {
        //            settingsResourceStore.SettingsResources[resourceName].ApplyDefaultSettings();
        //        }
        //    }

        //}

        //public void SaveCurrentSettings(ISettingsResourceStore settingsResourceStore)
        //{
        //    settingsResourceStore.Save();
        //}

    }
}
