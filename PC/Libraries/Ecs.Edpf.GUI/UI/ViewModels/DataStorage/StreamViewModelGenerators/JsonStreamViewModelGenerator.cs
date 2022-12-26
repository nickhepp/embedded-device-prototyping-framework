using Ecs.Edpf.Data.StreamSettings;
using Ecs.Edpf.GUI.UI.ViewModels.DataStorage.StreamViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.StreamViewModelGenerators
{
    public class JsonStreamViewModelGenerator : BaseDataStorageStreamViewModelGenerator
    {

        private JsonStreamSettings _jsonStreamSettings;

        public JsonStreamViewModelGenerator(JsonStreamSettings jsonStreamSettings)
        {
            _jsonStreamSettings = jsonStreamSettings;
        }

        protected override IDataStorageStreamViewModel InternalGetDataStorageStreamViewModel()
        {
            throw new NotImplementedException();
        }
    }
}
