using Ecs.Edpf.Devices.ComponentModel;
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

        private static string InternalGetExceptionDescrption(Exception ex)
        {
            const string Divider = "==========";
            string exDesc = $"{Divider}{Environment.NewLine}{ExceptionUtility.GetExceptionMessages(ex)}{Environment.NewLine}{Divider}{Environment.NewLine}{ex.StackTrace}{Divider}";
            return exDesc;
        }

        public void LogException(Exception ex)
        {
            _serilogLogger.Error(InternalGetExceptionDescrption(ex));
        }

        public void LogException(string messageTemplate, Exception ex)
        {
            string desc = $"{messageTemplate}{Environment.NewLine}{InternalGetExceptionDescrption(ex)}";
            _serilogLogger.Error(desc);
        }

        public void Dispose()
        {
            if (_disposableLogger != null)
            {
                _disposableLogger.Dispose();
            }
        }

        public void LogWarning(string messageTemplate)
        {
            _serilogLogger.Warning(messageTemplate);
        }

    }
}
