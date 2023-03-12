using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.AddStorageViewModels
{
    public class CsvChildAddDataStorageStreamViewModel : BaseChildAddDataStorageStreamViewModel
    {

        public const string CsvTypeName = "CSV";

        private CsvDataStorageStreamSettings _csvDataStorageStreamSettings = new CsvDataStorageStreamSettings();
        public override IChildDataStorageStreamSettings ChildDataStorageStreamSettings => _csvDataStorageStreamSettings;

        public override string TypeName => CsvTypeName;

 
    }
}
