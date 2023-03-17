using Ecs.Edpf.Devices.Logging;
using Ecs.Edpf.GUI.UI.ViewModels.DataStorage.AddStorageViewModels;
using Ecs.Edpf.GUI.UI.ViewModels.DataStorage.StreamViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.StreamViewModelGenerators
{
    public class DataStorageStreamViewModelGenerator : IDataStorageStreamViewModelGenerator
    {

        private IChildDataStorageStreamSettings _settings;

        // CassandraDataStorageStreamSettings
        // CsvDataStorageStreamSettings
        // JsonDataStorageStreamSettings
        // MongoDBDataStorageStreamSettings
        // SqlServerDataStorageStreamSettings
        // XmlDataStorageStreamSettings

        public DataStorageStreamViewModelGenerator(IChildDataStorageStreamSettings settings)
        {
            _settings = settings;
        }

        public IDataStorageStreamViewModel GetDataStorageStreamViewModel(ILogger logger)
        {
            return null;
        }
    }
}
