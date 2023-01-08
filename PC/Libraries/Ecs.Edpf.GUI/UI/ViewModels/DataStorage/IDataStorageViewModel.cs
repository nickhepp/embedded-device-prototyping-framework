using Ecs.Edpf.Devices.Devices;
using Ecs.Edpf.GUI.ComponentModel;
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

        int StreamsPausedCount { get; }

        int StreamsRunningCount { get; }

        IRelayCommand AddDataStreamCommand { get; }

        IRelayCommand RemoveDataStreamsCommand { get; }

        IRelayCommand RecordAllStreamsCommand { get; }

        IRelayCommand PauseAllStreamsCommand { get; }

        BindingList<IDataStorageStreamViewModel> StreamViewModels { get; }

    }
}
