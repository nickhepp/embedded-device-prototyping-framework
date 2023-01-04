using Ecs.Edpf.Devices.Logging;
using Ecs.Edpf.GUI.UI.ViewModels.DataStorage.StreamViewModels;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.StreamViewModelGenerators
{
    public interface IDataStorageStreamViewModelGenerator
    {

        IDataStorageStreamViewModel GetDataStorageStreamViewModel(ILogger logger);

    }
}