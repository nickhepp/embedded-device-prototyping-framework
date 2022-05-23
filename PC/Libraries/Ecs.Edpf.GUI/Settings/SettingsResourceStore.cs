using Ecs.Edpf.Devices.ComponentModel;
using Ecs.Edpf.Devices.IO.File;
using Ecs.Edpf.Devices.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Ecs.Edpf.GUI.Settings
{
    public class SettingsResourceStore : ISettingsResourceStore
    {
        private readonly ILogger _logger;
        private readonly IPersistedSettingsFactory _persistedSettingsFactory;


        public SettingsResourceStore(ILogger logger, IPersistedSettingsFactory persistedSettingsFactory)
        {
            _logger = logger;
            _persistedSettingsFactory = persistedSettingsFactory;
        }

        public Dictionary<string, ISettingsResource> SettingsResources { get; set; } = new Dictionary<string, ISettingsResource>();




        public void AddSettingsResource(ISettingsResource resource)
        {
            if (SettingsResources.ContainsKey(resource.ResourceName))
            {
                throw new Exception($"Settings resource with name '{resource.ResourceName}' is already added.");
            }

            SettingsResources[resource.ResourceName] = resource;
        }

        public void AddSettingsResources(IEnumerable<ISettingsResource> settingsResources)
        {
            foreach (ISettingsResource resource in settingsResources)
            {
                AddSettingsResource(resource);
            }
        }


  

        public void Save()
        {
            try
            {
                PersistedSettings persistedSettings = new PersistedSettings();
                foreach (ISettingsResource settingsRsrc in SettingsResources.Values)
                {
                    try
                    {
                        Dictionary<string, string> settings = settingsRsrc.GetSettings();
                        persistedSettings.SettingsGroups.Add(new SettingsGroup { ResourceName = settingsRsrc.ResourceName, Settings = settings });
                    }
                    catch (Exception ex)
                    {
                        _logger.LogException($"Error generating settings for resource '{settingsRsrc.ResourceName}'.", ex);
                    }
                }
                _persistedSettingsFactory.PersistSettings(persistedSettings);
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
            }

        }

        public void Open()
        {

            PersistedSettings persistedSttings = null;
            try
            {
                persistedSttings = _persistedSettingsFactory.GetPersistedSettings();

                foreach (ISettingsResource settingsRsrc in SettingsResources.Values)
                {
                    SettingsGroup settingsGroup = null;
                    
                        
                    settingsGroup = persistedSttings.SettingsGroups.FirstOrDefault(s => string.Equals(s.ResourceName, settingsRsrc.ResourceName));
                    if (settingsGroup != null)
                    {
                        try
                        {
                            settingsRsrc.ApplySettings(settingsGroup.Settings);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogException($"Error applying settings for resource '{settingsRsrc.ResourceName}'.", ex);
                        }
                    }
                    else
                    {
                        try
                        {
                            _logger.LogWarning($"Did not find resource with name '{settingsRsrc.ResourceName}'.  Applying default settings.");
                            settingsRsrc.ApplyDefaultSettings();
                        }
                        catch (Exception ex)
                        {
                            _logger.LogException($"Error applying default settings to resource '{settingsRsrc.ResourceName}'.", ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                foreach (ISettingsResource settingsRsrc in SettingsResources.Values)
                {
                    settingsRsrc.ApplyDefaultSettings();
                }
            }

     
        }

    }
}
