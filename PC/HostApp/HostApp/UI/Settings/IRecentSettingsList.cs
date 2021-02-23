using Ecs.Edpf.GUI.Settings;

namespace HostApp.UI.Settings
{
    public interface IRecentSettingsList
    {

        Settings GetCurrentSettings();


        void Save();
    }
}