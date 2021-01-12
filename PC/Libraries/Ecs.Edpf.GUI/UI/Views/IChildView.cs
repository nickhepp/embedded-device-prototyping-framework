using Ecs.Edpf.Devices;
using Ecs.Edpf.GUI.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.Views
{
    public interface IChildView
    {

        IChildViewModel ViewModel { get; set; }

    }
}
