using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices
{
    public static class Constants
    {

        public const string CommandNamePrefix = "cmd:";
        public const string CommandNameEnding = "()";

        public const string CommandParameterPrefix = "p[";
        public const string CommandParameterSuffix = "]=";

        public const string DeviceOutputBufferErrorPrefix = "ERR:";

        public const char LineEnding = '\n';

        public const string CommandResponseLineEnding = "\n>";

        public const int DefaultTimeOut = 5000;

        public const string ProjectDiscussionsUrl = "https://github.com/nickhepp/embedded-device-prototyping-framework/discussions";

        public const string ProjectBugsUrl = "https://github.com/nickhepp/embedded-device-prototyping-framework/issues";



    }
}
