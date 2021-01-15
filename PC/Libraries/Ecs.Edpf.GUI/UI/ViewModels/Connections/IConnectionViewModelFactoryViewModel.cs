using Ecs.Edpf.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.Connections
{
    public interface IConnectionViewModelFactoryViewModel : IChildViewModel
    {

        IDeviceProvider GlobalDeviceProvider { get; }

        List<IConnectionViewModel> ConnectionViewModels { get; }


    }
}
