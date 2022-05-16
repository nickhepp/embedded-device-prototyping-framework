using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.Logging
{
    public class FileLogger : ILogger
    {

        private Serilog.ILogger _serilogLogger;
        private IDisposable _disposableLogger;

        public FileLogger(Serilog.ILogger serilogLogger)
        {
            _serilogLogger = serilogLogger;
            _disposableLogger = serilogLogger as IDisposable;
        }

        public void LogInformation(string messageTemplate)
        {
            _serilogLogger.Information(messageTemplate);
        }

        public void Dispose()
        {
            if (_disposableLogger != null)
            {
                _disposableLogger.Dispose();
            }
        }

    }
}
