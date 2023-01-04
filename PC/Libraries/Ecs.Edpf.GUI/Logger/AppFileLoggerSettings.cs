using Ecs.Edpf.Devices.ComponentModel;
using Ecs.Edpf.Devices.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.Logger
{
    public class AppFileLoggerSettings : FileLoggerSettings
    {

        public AppFileLoggerSettings()
        {
            Path = System.IO.Path.Combine(
                BaseDirectoryProvider.GetEdpfBaseDirectory(), 
                GuiLoggerConstants.LogsDirectoryName, 
                "apps.log");
        }

    }
}
