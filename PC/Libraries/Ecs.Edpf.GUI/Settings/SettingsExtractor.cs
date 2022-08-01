using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.Settings
{
    internal static class SettingsExtractor
    {

        internal static void ApplyBoolSettingByName(
            Dictionary<string, string> settings,
            string settingsName,
            Action<bool> applySetting)
        {
            ApplySettingByName<bool>(
                settings,
                settingsName,
                tryParse: settingsVal =>
                {
                    bool parsed = bool.TryParse(settingsVal, out bool val);
                    return (parsed, val);
                },
                applySetting);
        }

        private static void ApplySettingByName<T>(
            Dictionary<string, string> settings,
            string settingsName,
            Func<string, (bool parsed, T val)> tryParse,
            Action<T> applySetting)
            where T : struct
        {
            (bool parsed, T? val) parsedVal = GetSettingByName(settings, settingsName, tryParse);
            if (parsedVal.parsed)
            {
                applySetting(parsedVal.val.Value);
            }
        }

        private static (bool parsed, T? val) GetSettingByName<T>(
            Dictionary<string, string> settings, 
            string settingsName,
            Func<string, (bool parsed, T val)> tryParse) 
            where T : struct
        {
            (bool parsed, T? val) parsedVal = (false, null);
            string theSettingStr;
            if (settings.TryGetValue(settingsName, out theSettingStr))
            {
                parsedVal = tryParse(theSettingStr);
            }

            return parsedVal;
        }

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
