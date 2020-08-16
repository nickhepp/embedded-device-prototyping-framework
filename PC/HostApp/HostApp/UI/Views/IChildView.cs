using Ecs.Edpf.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.UI.ChildUI.Views
{
    public interface IChildView
    {

        IChildViewModel ViewModel { get; set; }

    }
}
