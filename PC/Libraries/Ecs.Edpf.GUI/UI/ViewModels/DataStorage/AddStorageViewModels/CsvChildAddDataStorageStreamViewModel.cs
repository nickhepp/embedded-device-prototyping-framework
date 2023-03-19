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

        private CsvDataStorageStreamSettingsViewModel _csvDataStorageStreamSettings = new CsvDataStorageStreamSettingsViewModel();
        public override IChildDataStorageStreamSettings ChildDataStorageStreamSettings => _csvDataStorageStreamSettings;

        public override string TypeName => CsvTypeName;


    }
}
