using Ecs.Edpf.Data.DataStreams;
using Ecs.Edpf.Data.StreamSettings;
using Ecs.Edpf.Devices.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.AddStorageViewModels
{
    public abstract class BaseFileDataStorageStreamSettingsViewModel<TFileDataStreamSettings> : BaseChildDataStorageStreamSettingsViewModel<TFileDataStreamSettings>
        where TFileDataStreamSettings : BaseFileStreamSettings, new()
    {
        // 
        public const string FileSettingsCategoryName = "\t\tFile Settings";

        [Category(FileSettingsCategoryName)]
        [DisplayName("Directory")]
        [Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
        public string Directory
        {
            get
            {
                if (string.IsNullOrEmpty(StreamSettings.DirectoryPath))
                {
                    StreamSettings.DirectoryPath = System.IO.Path.Combine(BaseDirectoryProvider.GetEdpfBaseDirectory(),
                        "DataStreams",
                        this.StreamName);
                }

                return StreamSettings.DirectoryPath;
            }
            set
            {
                StreamSettings.DirectoryPath = value;
                RaiseNotifyPropertyChanged();
            }
        }

        [Category(FileSettingsCategoryName)]
        [DisplayName("Rollover Period")]
        public FileStreamRolloverPeriod RolloverPeriod
        {
            get { return StreamSettings.RolloverPeriod; }
            set
            {
                StreamSettings.RolloverPeriod = value;
                RaiseNotifyPropertyChanged();
            }
        }

    }
}
