using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ecs.Edpf.Devices.Logging
{
    public class FileLoggerSettings : INotifyPropertyChanged
    {
        private string _path = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "EDPF", "Logs", "device.log");
        [Description("Path to the file.")]
        public string Path
        {
            get => _path;
            set
            {
                _path = value;
                RaiseNotifyPropertyChanged();
            }
        }

        private string _outputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}";
        [Description("A message template describing the format used to write to the sink. \r\n" +
            "The default is \"{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}\".")]
        public string OutputTemplate
        {
            get => _outputTemplate;
            set
            {
                _outputTemplate = value;
                RaiseNotifyPropertyChanged();
            }
        }

        private long? _fileSizeLimitBytes = 1073741824L;
        [Description("The approximate maximum size, in bytes, to which a log file will be allowed to " +
            "grow. For unrestricted growth, pass null. The default is 1 GB. To avoid writing " +
            "partial events, the last event within the limit will be written in full even " +
            "if it exceeds the limit.")]
        public long? FileSizeLimitBytes
        {
            get => _fileSizeLimitBytes;
            set
            {
                _fileSizeLimitBytes = value;
                RaiseNotifyPropertyChanged();
            }
        }

        private bool _buffered = false;
        [Description("Indicates if flushing to the output file can be buffered or not.")]
        public bool Buffered
        {
            get => _buffered;
            set
            {
                _buffered = value;
                RaiseNotifyPropertyChanged();
            }
        }

        private TimeSpan? _flushToDiskInterval = null;
        [Description("If provided, a full disk flush will be performed periodically at the specified interval.")]
        public TimeSpan? FlushToDiskInterval
        {
            get => _flushToDiskInterval;
            set
            {
                _flushToDiskInterval = value;
                RaiseNotifyPropertyChanged();
            }
        }

        private RollingInterval _rollingInterval = RollingInterval.Hour;
        [Description("The interval at which logging will roll over to a new file.")]
        public RollingInterval RollingInterval
        {
            get => _rollingInterval;
            set
            {
                _rollingInterval = value;
                RaiseNotifyPropertyChanged();
            }
        }

        private bool _rollOnFileSizeLimit = false;
        [Description("If true , a new file will be created when the file size limit is reached. Filenames will " +
            "have a number appended in the format _NNN , with the first filename given no number.")]
        public bool RollOnFileSizeLimit
        {
            get => _rollOnFileSizeLimit;
            set
            {
                _rollOnFileSizeLimit = value;
                RaiseNotifyPropertyChanged();
            }
        }

        private int? _retainedFileCountLimit = 31;
        [Description("The maximum number of log files that will be retained, including the current " +
            "log file. For unlimited retention, pass null. The default is 31.")]
        public int? RetainedFileCountLimit
        {
            get => _retainedFileCountLimit;
            set
            {
                _retainedFileCountLimit = value;
                RaiseNotifyPropertyChanged();
            }
        }

        private TimeSpan? _retainedFileLimit = null;
        [Description("The maximum time after the end of an interval that a rolling log file will be " +
            "retained. Must be greater than or equal to System.TimeSpan.Zero. Ignored if rollingInterval " +
            "is Serilog.RollingInterval.Infinite. The default is to retain files indefinitely.")]
        public TimeSpan? RetainedFileTimeLimit
        {
            get => _retainedFileLimit;
            set
            {
                _retainedFileLimit = value;
                RaiseNotifyPropertyChanged();
            }
        }

        public FileLoggerSettings()
        {

        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void RaiseNotifyPropertyChanged([CallerMemberName] string propName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

    }
}
