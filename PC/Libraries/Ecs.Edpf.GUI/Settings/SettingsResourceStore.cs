using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.Settings
{
    public class SettingsResourceStore : ISettingsResourceStore
    {

        public Dictionary<string, ISettingsResource> SettingsResources { get; set; } = new Dictionary<string, ISettingsResource>();

        public void AddSettingsResource(ISettingsResource resource)
        {
            if (SettingsResources.ContainsKey(resource.ResourceName))
            {
                throw new Exception($"Settings resource with name '{resource.ResourceName}' is already added.");
            }

            SettingsResources[resource.ResourceName] = resource;
        }

 
    }
}
