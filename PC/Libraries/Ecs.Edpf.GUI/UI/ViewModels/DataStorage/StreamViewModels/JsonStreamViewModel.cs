using Ecs.Edpf.Data.StreamSettings;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.StreamViewModels
{
    public class JsonStreamViewModel : BaseDataStorageStreamViewModel<JsonStreamSettings>
    {

        public JsonStreamViewModel(JsonStreamSettings streamSettings) : base(streamSettings)
        {
        }
    }
}
