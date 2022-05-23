using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.Settings
{
    internal static class SettingsExtractor
    {

        internal static uint? GetUIntSettingByName(Dictionary<string, string> settings, string settingsName)
        {
            uint? setting = null;
            string theSettingStr;
            if (settings.TryGetValue(settingsName, out theSettingStr))
            {
                uint settingInt;
                if (uint.TryParse(theSettingStr, out settingInt))
                {
                    setting = settingInt;
                }
            }

            return setting;
        }



        internal static int? GetIntSettingByName(Dictionary<string, string> settings, string settingsName)
        {
            int? setting = null;
            string theSettingStr;
            if (settings.TryGetValue(settingsName, out theSettingStr))
            {
                int settingInt;
                if (int.TryParse(theSettingStr, out settingInt))
                {
                    setting = settingInt;
                }
            }

            return setting;
        }



    }
}
