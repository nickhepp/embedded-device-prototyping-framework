using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.AddStorageViewModels
{
    public class SqlServerChildAddDataStorageStreamViewModel : BaseChildAddDataStorageStreamViewModel
    {

        private SqlServerDataStorageStreamSettings _storageStreamSettings = new SqlServerDataStorageStreamSettings();
        public override object ChildDataStorageStreamSettings => _storageStreamSettings;

        public override string TypeName => SqlServerTypeName;

        public const string SqlServerTypeName = "MS SQL Server";

        
    }
}
