using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ecs.Edpf.Devices.Logging
{
    public class FileLoggerSettings
    {

        [Description("Path to the file.")]
        public string Path { get; set; }

        [Description("A message template describing the format used to write to the sink. \r\n" +
            "The default is \"{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}\".")]
        public string OutputTemplate { get; set; } = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}";

        [Description("The approximate maximum size, in bytes, to which a log file will be allowed to " +
            "grow. For unrestricted growth, pass null. The default is 1 GB. To avoid writing " +
            "partial events, the last event within the limit will be written in full even " +
            "if it exceeds the limit.")]
        public long? FileSizeLimitBytes { get; set; } = 1073741824L;


        [Description("Indicates if flushing to the output file can be buffered or not.")]
        public bool Buffered { get; set; } = false;

        [Description("If provided, a full disk flush will be performed periodically at the specified interval.")]
        public TimeSpan? FlushToDiskInterval { get; set; } = null;

        [Description("The interval at which logging will roll over to a new file.")]
        public RollingInterval RollingInterval { get; set; } = RollingInterval.Hour;

        [Description("If true , a new file will be created when the file size limit is reached. Filenames will " +
            "have a number appended in the format _NNN , with the first filename given no number.")]
        public bool RollOnFileSizeLimit { get; set; } = false;

        [Description("The maximum number of log files that will be retained, including the current " +
            "log file. For unlimited retention, pass null. The default is 31.")]
        public int? RetainedFileCountLimit { get; set; } = 31;


        [Description("The maximum time after the end of an interval that a rolling log file will be " +
            "retained. Must be greater than or equal to System.TimeSpan.Zero. Ignored if rollingInterval " +
            "is Serilog.RollingInterval.Infinite. The default is to retain files indefinitely.")]
        public TimeSpan? retainedFileTimeLimit { get; set; } = null;



    }
}
