using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.AddStorageViewModels

{
    public interface IAddDataStorageStreamViewModel : INotifyPropertyChanged
    {

        IChildAddDataStorageStreamViewModel SelectedStreamType { get; set; }

        IEnumerable<IChildAddDataStorageStreamViewModel> StreamTypes { get; }


    }
}
