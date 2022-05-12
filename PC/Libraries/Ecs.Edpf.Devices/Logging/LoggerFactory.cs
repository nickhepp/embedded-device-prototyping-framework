using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.Logging
{
    public class LoggerFactory
    {


        public ILogger GetFileLogger(FileLoggerSettings fileLoggerSettings)
        {
            Serilog.ILogger logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File("logfile.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            return new FileLogger(logger);
        }


    }
}
