using Ecs.Edpf.GUI.UI.ViewModels.DataStorage.StreamViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.StreamViewModelGenerators
{
    public abstract class BaseDataStorageStreamViewModelGenerator : IDataStorageStreamViewModelGenerator
    {

        protected abstract IDataStorageStreamViewModel InternalGetDataStorageStreamViewModel();

        public IDataStorageStreamViewModel GetDataStorageStreamViewModel()
        {
            return InternalGetDataStorageStreamViewModel();
        }

    }
}
