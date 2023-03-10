using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.AddStorageViewModels
{

    public class ChildAddDataStorageStreamViewModelFactory : IChildAddDataStorageStreamViewModelFactory
    {
        public IEnumerable<IChildAddDataStorageStreamViewModel> GetChildAddDataStorageStreamTypes()
        {
            List<IChildAddDataStorageStreamViewModel> childAddDataStorageStreamViewModels = new List<IChildAddDataStorageStreamViewModel>
            {
                new CassandraChildAddDataStorageStreamViewModel(),
                new CsvChildAddDataStorageStreamViewModel(),
                new JsonChildAddDataStorageStreamViewModel(),
                new MongoDBChildAddDataStorageStreamViewModel(),
                new SqlServerChildAddDataStorageStreamViewModel(),
                new XmlChildAddDataStorageStreamViewModel(),
            };

            return childAddDataStorageStreamViewModels;
        }

    }

}
