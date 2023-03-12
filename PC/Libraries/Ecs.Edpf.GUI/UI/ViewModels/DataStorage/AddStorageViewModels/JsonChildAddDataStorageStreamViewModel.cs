using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.AddStorageViewModels
{
    public class JsonChildAddDataStorageStreamViewModel : BaseChildAddDataStorageStreamViewModel
    {

        private JsonDataStorageStreamSettings _storageStreamSettings = new JsonDataStorageStreamSettings();
        public override IChildDataStorageStreamSettings ChildDataStorageStreamSettings => _storageStreamSettings;

        public override string TypeName => JsonTypeName;

        public const string JsonTypeName = "JSON";


    }
}
