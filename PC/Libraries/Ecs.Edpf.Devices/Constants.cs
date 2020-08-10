using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices
{
    public static class Constants
    {

        public const string CommandParameterPrefix = "p[";
        public const string CommandParameterSuffix = "]=";

        public const string DeviceOutputBufferErrorPrefix = "ERR:";

        public const char LineEnding = '\n';

        public const string CommandResponseLineEnding = "\n>";

        public const int DefaultTimeOut = 5000;
    }
}
