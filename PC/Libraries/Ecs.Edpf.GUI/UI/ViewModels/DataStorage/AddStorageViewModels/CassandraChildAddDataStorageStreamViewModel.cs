using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.AddStorageViewModels
{
    public class CassandraChildAddDataStorageStreamViewModel : BaseChildAddDataStorageStreamViewModel
    {

        public const string CassandraTypeName = "Cassandra";

        private CassandraDataStorageStreamSettings _storageStreamSettings = new CassandraDataStorageStreamSettings();
        public override IChildDataStorageStreamSettings ChildDataStorageStreamSettings => _storageStreamSettings;

        public override string TypeName => CassandraTypeName;



    }
}
