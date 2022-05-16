using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.Logging
{
    public class LoggerFactory : ILoggerFactory
    {

        private FileLoggerSettings _fileLoggerSettings;

        public LoggerFactory(FileLoggerSettings fileLoggerSettings)
        {
            _fileLoggerSettings = fileLoggerSettings;
        }

        public ILogger GetLogger()
        {
            Serilog.ILogger logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File(
                        path: _fileLoggerSettings.Path,
                        outputTemplate: _fileLoggerSettings.OutputTemplate,
                        fileSizeLimitBytes: _fileLoggerSettings.FileSizeLimitBytes,
                        buffered: _fileLoggerSettings.Buffered,
                        flushToDiskInterval: _fileLoggerSettings.FlushToDiskInterval,
                        rollingInterval: _fileLoggerSettings.RollingInterval,
                        rollOnFileSizeLimit: _fileLoggerSettings.RollOnFileSizeLimit,
                        retainedFileCountLimit: _fileLoggerSettings.RetainedFileCountLimit,
                        retainedFileTimeLimit: _fileLoggerSettings.RetainedFileTimeLimit)
                .CreateLogger();

            return new FileLogger(logger);
        }


    }
}
