using Ecs.Edpf.Devices.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ecs.Edpf.Data.DataStreams
{
    public abstract class DataStream : INotifyPropertyChanged
    {
        private readonly IDataStreamExpressionFilter _filter;
        private readonly ILogger _logger;

        private int _resultsProcessed = 0;
        public int ResultsProcessed
        {
            get
            {
                return _resultsProcessed;
            }
            private set
            {
                _resultsProcessed = value;
                RaiseNotifyPropertyChanged();
            }
        }

        private int _resultsFailed = 0;
        public int ResultsFailed
        {
            get
            {
                return _resultsFailed;
            }
            private set
            {
                _resultsFailed = value;
                RaiseNotifyPropertyChanged();
            }
        }

        public DataStream(IDataStreamExpressionFilter filter, ILogger logger)
        {
            _filter = filter;
            _logger = logger;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected abstract void InternalProcessDeviceTextLine(LineResultsSet resultsSet);

        public void ProcessDeviceTextLine(string deviceTextLine)
        {
            LineResultsSet resultsSet = _filter.GetResults(deviceTextLine);
            
            if (resultsSet != null)
            {
                try
                {
                    InternalProcessDeviceTextLine(resultsSet);
                    ResultsProcessed++;
                }
                catch (Exception ex)
                {
                    ResultsFailed++;
                    _logger.LogException(ex);
                }
            }

        }

        protected void RaiseNotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }



    }
}
