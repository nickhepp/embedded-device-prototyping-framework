using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.UI.Settings
{
    public class ResourceSettingsPayload
    {

        public string ResourceName { get; set; }

        public Dictionary<string, string> Settings { get; set; }


    }
}
