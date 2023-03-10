using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.AddStorageViewModels
{

    public class MongoDBChildAddDataStorageStreamViewModel : BaseChildAddDataStorageStreamViewModel
    {

        public const string MongoDBTypeName = "MongoDB";

        private MongoDBDataStorageStreamSettings _storageStreamSettings = new MongoDBDataStorageStreamSettings();
        public override object ChildDataStorageStreamSettings => _storageStreamSettings;

        public override string TypeName => MongoDBTypeName;

    }

}
