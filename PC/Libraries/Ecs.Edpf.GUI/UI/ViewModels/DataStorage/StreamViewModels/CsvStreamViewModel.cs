using Ecs.Edpf.Data.StreamSettings;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.StreamViewModels
{
    public class CsvStreamViewModel : BaseDataStorageStreamViewModel<CsvStreamSettings>
    {
        public CsvStreamViewModel(CsvStreamSettings streamSettings) : base(streamSettings)
        {
        }
    }
}
