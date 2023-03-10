using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.AddStorageViewModels
{
    public abstract class BaseChildAddDataStorageStreamViewModel : IChildAddDataStorageStreamViewModel
    {
        public abstract object ChildDataStorageStreamSettings { get; }

        public abstract string TypeName { get; }
    }
}
