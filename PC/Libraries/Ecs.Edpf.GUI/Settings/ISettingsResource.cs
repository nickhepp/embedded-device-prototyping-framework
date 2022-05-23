using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.GUI.Settings
{

    /// <summary>
    /// A settings resource which can be serialized and deserialized.
    /// </summary>
    public interface ISettingsResource
    {

        /// <summary>
        /// The name of the resource.
        /// </summary>
        string ResourceName { get; }

        /// <summary>
        /// The settings.
        /// </summary>
        /// <returns></returns>
        Dictionary<string, string> GetSettings();

        /// <summary>
        /// The settings to apply.
        /// </summary>
        void ApplySettings(Dictionary<string, string> settings);


        void ApplyDefaultSettings();
    }
}
