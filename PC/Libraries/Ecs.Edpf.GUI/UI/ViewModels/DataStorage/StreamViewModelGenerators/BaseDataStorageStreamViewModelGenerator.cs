using Ecs.Edpf.Devices.Logging;
using Ecs.Edpf.GUI.UI.ViewModels.DataStorage.StreamViewModels;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.StreamViewModelGenerators
{
    public abstract class BaseDataStorageStreamViewModelGenerator : IDataStorageStreamViewModelGenerator
    {

        protected abstract IDataStorageStreamViewModel InternalGetDataStorageStreamViewModel();

        public IDataStorageStreamViewModel GetDataStorageStreamViewModel(ILogger logger)
        {
            return InternalGetDataStorageStreamViewModel();
        }

    }
}
