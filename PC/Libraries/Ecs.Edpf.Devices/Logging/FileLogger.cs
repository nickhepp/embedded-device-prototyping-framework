using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.Logging
{
    public class FileLogger : ILogger
    {

        private Serilog.ILogger _serilogLogger;

        public FileLogger(Serilog.ILogger serilogLogger)
        {
            _serilogLogger = serilogLogger;
        }

        public void LogInformation(string messageTemplate)
        {
            _serilogLogger.Information(messageTemplate);
        }

    }
}
