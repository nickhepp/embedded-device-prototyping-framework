using Ecs.Edpf.Devices.ComponentModel;
using Ecs.Edpf.Devices.IO.File;
using Ecs.Edpf.Devices.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.Settings
{
    public class PersistedSettingsFactory : IPersistedSettingsFactory
    {

        private ILogger _logger;
        private IDirectoryManager _dirMgr;
        private IFileManager _fileMgr;

        public PersistedSettingsFactory(ILogger logger, IDirectoryManager dirMgr, IFileManager fileMgr)
        {
            _logger = logger;
            _dirMgr = dirMgr;
            _fileMgr = fileMgr;
        }

        private string GetSettingsResourceDirectory()
        {
            string settingsDirPath = System.IO.Path.Combine(BaseDirectoryProvider.GetEdpfBaseDirectory(), "Settings");
            if (!_dirMgr.DirectoryExists(settingsDirPath))
            {
                _dirMgr.CreateDirectory(settingsDirPath);
            }
            return settingsDirPath;
        }

        private string GetSettingsResourcePath()
        {
            string settingsDirPath = GetSettingsResourceDirectory();
            string settingsFilePath = Path.Combine(settingsDirPath, "settings.json");
            return settingsFilePath;
        }

        public PersistedSettings GetPersistedSettings()
        {
            PersistedSettings persistedSettings;
            string settingsFilePath = GetSettingsResourcePath();
            if (_fileMgr.FileExists(settingsFilePath))
            {
                persistedSettings = Newtonsoft.Json.JsonConvert.DeserializeObject<PersistedSettings>(_fileMgr.ReadAllText(settingsFilePath));
            }
            else
            {
                _logger.LogWarning($"Did not find settings at expected path '{settingsFilePath}'.");
                persistedSettings = new PersistedSettings();
            }
            return persistedSettings;
        }

        public void PersistSettings(PersistedSettings persistedSettings)
        {
            try
            {
                string settingsFilePath = GetSettingsResourcePath();
                string serializedData = Newtonsoft.Json.JsonConvert.SerializeObject(persistedSettings, Newtonsoft.Json.Formatting.Indented);
                using (FileStream fs = new FileStream(settingsFilePath, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(serializedData);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
            }
        }



    }
}
