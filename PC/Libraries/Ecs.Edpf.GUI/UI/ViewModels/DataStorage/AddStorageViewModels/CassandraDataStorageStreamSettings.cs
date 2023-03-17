#if INCLUDE_CASSANDRA

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.AddStorageViewModels
{
    public class CassandraDataStorageStreamSettings : BaseChildDataStorageStreamSettings
    {
        public override string TypeName => CassandraChildAddDataStorageStreamViewModel.CassandraTypeName;
    
        // TODO: settings

    }

}

#endif
