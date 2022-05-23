using System.Collections.Generic;

namespace Ecs.Edpf.GUI.Settings
{
    public interface IPersistedSettingsFactory
    {
        
        PersistedSettings GetPersistedSettings();

        void PersistSettings(PersistedSettings persistedSettings);

    }
}