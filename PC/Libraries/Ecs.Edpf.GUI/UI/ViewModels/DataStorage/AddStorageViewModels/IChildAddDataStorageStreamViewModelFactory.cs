using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.AddStorageViewModels
{
    public interface IChildAddDataStorageStreamViewModelFactory
    {

        /// <summary>
        /// Returns descriptors of child add data storage stream view models.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IChildAddDataStorageStreamViewModel> GetChildAddDataStorageStreamTypes();



    }
}
