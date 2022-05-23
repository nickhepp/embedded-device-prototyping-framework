using System.Collections.Generic;

namespace Ecs.Edpf.GUI.Settings
{
    public interface ISettingsResourceStore
    {

        void Open();

        void AddSettingsResource(ISettingsResource resource);

        void AddSettingsResources(IEnumerable<ISettingsResource> settingsResources);

        void Save();


    }
}