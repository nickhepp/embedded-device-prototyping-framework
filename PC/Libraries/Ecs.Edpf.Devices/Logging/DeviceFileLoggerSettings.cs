using Ecs.Edpf.Devices.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.Logging
{
    public class DeviceFileLoggerSettings : FileLoggerSettings
    {

        public DeviceFileLoggerSettings()
        {
            Path = System.IO.Path.Combine(BaseDirectoryProvider.GetEdpfBaseDirectory(), "Logs", "device.log");
        }

    }
}
