using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.Connections
{
    public interface IConnectionViewModelFactoryViewModel : IChildViewModel, IGlobalDeviceProvider
    {

        List<IConnectionViewModel> ConnectionViewModels { get; }


    }
}
