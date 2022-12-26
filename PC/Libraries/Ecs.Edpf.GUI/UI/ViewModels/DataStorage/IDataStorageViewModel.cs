using Ecs.Edpf.Devices.Devices;
using Ecs.Edpf.GUI.UI.ViewModels.DataStorage.StreamViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage
{
    public interface IDataStorageViewModel : IDeviceViewModel, IDeviceProviderListener
    {

        ICommand AddDataStreamCommand { get; }

        BindingList<IDataStorageStreamViewModel> StreamViewModels { get; }

    }
}
