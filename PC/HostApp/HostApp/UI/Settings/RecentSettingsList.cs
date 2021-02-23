using Ecs.Edpf.Devices.IO.File;
using Ecs.Edpf.GUI.Settings;
using System;
using System.Collections.Generic;
using System.IO;

namespace HostApp.UI.Settings
{

    public class RecentSettingsList : IRecentSettingsList
    {

        private IFile _file;

        public string CurrentSettingsFilePath { get; set; } = null;

        public Dictionary<string, Settings> SettingsList { get; set; } = new Dictionary<string, Settings>();

        public bool HasCurrentSettings
        {
            get
            {
                return (!string.IsNullOrEmpty(CurrentSettingsFilePath) &&
                        SettingsList.ContainsKey(CurrentSettingsFilePath) &&
                        (File.Exists(CurrentSettingsFilePath)));

            }
        }


        public RecentSettingsList(IFile file)
        {
            _file = file;
        }

        public Settings GetCurrentSettings()
        {
            Settings settings = null;
            if (HasCurrentSettings)
            {
                settings = Newtonsoft.Json.JsonConvert.DeserializeObject<Settings>(CurrentSettingsFilePath);
            }
            else
            {
                settings = new Settings();
                SettingsList[""]  = settings;
                CurrentSettingsFilePath = null;
            }
            return settings;
        }

        public void Save()
        {
            //string settingsPath = GetSettingsPath();
            //string settingsStr = Newtonsoft.Json.JsonConvert.SerializeObject(this);
            //File.WriteAllText(settingsPath, settingsStr);
        }

        //public ISettingsResourceStore GetCurrentSettingsResourceStore()
        //{
        //    throw new NotImplementedException();
        //}


        //public static RecentMainFormSettingsList OpenRecentMainFormSettingsList(string filePath)
        //{
        //    string fileContents = File.ReadAllText(filePath);
        //    RecentMainFormSettingsList recentMnFrmSttngs = Newtonsoft.Json.JsonConvert.DeserializeObject<RecentMainFormSettingsList>(fileContents);
        //    return recentMnFrmSttngs;
        //}


        //public string Save(Stream settingsStream)
        //{
        //    if (string.IsNullOrEmpty(SavePath))
        //    {
        //        // we have not saved the settings yet, calc a new path
        //        SavePath = System.Environment.GetEnvironmentVariable("LOCALAPPDATA", EnvironmentVariableTarget.User);
        //        SavePath = Path.Combine(SavePath, nameof(Ecs.Edpf), "settings.xml");
        //        FileInfo savePathInfo = new FileInfo(GetSettingsPath());
        //        if (!savePathInfo.Directory.Exists)
        //        {
        //            savePathInfo.Directory.Create();
        //        }



        //        MainFormSettingsList = new List<MainFormSettings>();
        //    }

        //    using (FileStream fStrm = new FileStream(SavePath, FileMode.Create))
        //    {
        //        settingsStream.CopyTo(fStrm);
        //        fStrm.Close();
        //    }

        //    return null;
        //}
    }

}
