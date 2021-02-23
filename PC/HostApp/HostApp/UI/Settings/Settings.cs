using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeifenLuo.WinFormsUI.Docking;

namespace HostApp.UI.Settings
{
    public class Settings
    {

        public DateTime LastAccessed { get; set; }

        public Dictionary<string, ResourceSettingsPayload> ResourceSettingsPayloads { get; set; } = new Dictionary<string, ResourceSettingsPayload>();


    }
}
