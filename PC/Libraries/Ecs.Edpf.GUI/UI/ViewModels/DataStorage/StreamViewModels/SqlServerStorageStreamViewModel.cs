using Ecs.Edpf.Data.StreamSettings;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.StreamViewModels
{
    public class SqlServerStorageStreamViewModel : BaseDataStorageStreamViewModel<SqlServerStreamSettings>
    {

        public SqlServerStorageStreamViewModel(SqlServerStreamSettings streamSettings) : base(streamSettings)
        {
        }
    }
}
