using Ecs.Edpf.Devices.ComponentModel;
using Ecs.Edpf.Devices.Logging;

namespace Ecs.Edpf.GUI.Logger
{
    public class DataStreamFileLoggerSettings : FileLoggerSettings
    {

        public DataStreamFileLoggerSettings()
        {
            Path = System.IO.Path.Combine(
                BaseDirectoryProvider.GetEdpfBaseDirectory(),
                GuiLoggerConstants.LogsDirectoryName,
                "data-streams.log");
        }




    }
}
