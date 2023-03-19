using Ecs.Edpf.Data.StreamSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.AddStorageViewModels
{
    public class JsonDataStorageStreamSettings : BaseChildDataStorageStreamSettingsViewModel<JsonStreamSettings>
    {
        public override string TypeName => StreamSettingsConstants.JsonStreamSettingsTypeName;
    }
}
