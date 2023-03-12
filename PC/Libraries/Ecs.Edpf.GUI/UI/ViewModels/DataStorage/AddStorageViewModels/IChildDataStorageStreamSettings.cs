using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.AddStorageViewModels
{
    public interface IChildDataStorageStreamSettings
    {

        string TypeName { get; }

        string StreamName { get; set; }

    }
}
