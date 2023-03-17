using Ecs.Edpf.Data.StreamSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.AddStorageViewModels
{
    public class SqlServerDataStorageStreamSettings : BaseChildDataStorageStreamSettings<SqlServerStreamSettings>
    {
    
        public override string TypeName => SqlServerChildAddDataStorageStreamViewModel.SqlServerTypeName;
    
    }
}
