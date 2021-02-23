using System.Collections.Generic;

namespace Ecs.Edpf.GUI.Settings
{
    public interface ISettingsResourceStore
    {
        Dictionary<string, ISettingsResource> SettingsResources { get; set; }

        void AddSettingsResource(ISettingsResource resource);

    }
}