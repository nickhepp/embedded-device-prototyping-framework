using Ecs.Edpf.Data.StreamSettings;
using Ecs.Edpf.GUI.UI.ViewModels.DataStorage.StreamViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.StreamViewModelGenerators
{
    public class SqlServerStreamViewModelGenerator : BaseDataStorageStreamViewModelGenerator
    {

        private SqlServerStreamSettings _sqlServerStreamSettings;

        public SqlServerStreamViewModelGenerator(SqlServerStreamSettings sqlServerStreamSettings)
        {
            _sqlServerStreamSettings = sqlServerStreamSettings;
        }


        protected override IDataStorageStreamViewModel InternalGetDataStorageStreamViewModel()
        {
            return new SqlServerStorageStreamViewModel(_sqlServerStreamSettings);
        }
    }
}
