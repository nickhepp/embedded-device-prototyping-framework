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

        string SelectedStreamType { get; set; }

        IEnumerable<string> StreamTypes { get; }


    }
}
