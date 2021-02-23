using Ecs.Edpf.Devices.IO.File;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.UI.Settings
{
    public class RecentSettingsListFactory : IRecentSettingsListFactory
    {

        private IFile _file;

        public RecentSettingsListFactory(IFile file)
        {
            _file = file;
        }

        private static string GetSettingsResourceStoresList()
        {
            string settingsPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            settingsPath = Path.Combine(settingsPath, nameof(Ecs.Edpf), "settings.xml");
            return settingsPath;
        }


        public IRecentSettingsList GetRecentSettingsResourceStoresList()
        {
            RecentSettingsList settingsList = null;

            string settingsPath = GetSettingsResourceStoresList();
            if (_file.Exists(settingsPath))
            {
                // one exists, get it
                string settingsStr = File.ReadAllText(settingsPath);
                settingsList = Newtonsoft.Json.JsonConvert.DeserializeObject<RecentSettingsList>(settingsStr);
            }
            else
            {
                // one does not exist, start with a blank one
                settingsList = new RecentSettingsList(_file);
            }

            return settingsList;
        }
    }
}
