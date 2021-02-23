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


        private IFile _file ;



        /// <summary>
        /// The recent files for settings.
        /// </summary>
        private IRecentSettingsListFactory _recentSettingsListFactory;

        public SettingsManager(IRecentSettingsListFactory recentSettingsListFactory, IFile file)
        {
            _recentSettingsListFactory = recentSettingsListFactory;
            _file = file;
        }






        private static DirectoryInfo GetSaveFoldersDirectory()
        {
            string lclSaveDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            lclSaveDir = Path.Combine(lclSaveDir, "ecs", "EdpfSettings");
            DirectoryInfo dirInfo = new DirectoryInfo(lclSaveDir);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            return dirInfo;
        }



        public void ApplyCurrentSettings(ISettingsResourceStore settingsResourceStore)
        {
            Settings settings = _recentSettingsListFactory.GetRecentSettingsResourceStoresList().GetCurrentSettings();


            foreach (string resourceName in settingsResourceStore.SettingsResources.Keys)
            {
                if (settings.ResourceSettingsPayloads.ContainsKey(resourceName))
                {
                    settingsResourceStore.SettingsResources[resourceName].ApplySettings(settings.ResourceSettingsPayloads[resourceName].Settings);
                }
                else
                {
                    settingsResourceStore.SettingsResources[resourceName].ApplyDefaultSettings();
                }
            }

        }


        public void SaveCurrentSettings(ISettingsResourceStore settingsResourceStore)
        {

            DirectoryInfo dirInfo = GetSaveFoldersDirectory();

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Settings *.xml|*.xml",
                InitialDirectory = dirInfo.FullName
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //using (MemoryStream memStream = new MemoryStream())
                //{

                //    dockPanel.SaveAsXml(memStream, Encoding.UTF8);
                //    memStream.GetBuffer()


                //    Encoding.Hex


                //}

            }


        }






    }
}
