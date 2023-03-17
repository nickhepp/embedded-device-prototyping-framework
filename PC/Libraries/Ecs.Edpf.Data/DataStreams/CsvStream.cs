using Ecs.Edpf.Data.StreamSettings;
using Ecs.Edpf.Devices.IO.File;
using Ecs.Edpf.Devices.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Data.DataStreams
{
    public class CsvStream : BaseFileStream
    {

        private CsvStreamSettings _csvStreamSettings;

        public CsvStream(CsvStreamSettings csvStreamSettings,
            IDirectoryManager directoryManager,
            IDataStreamExpressionFilter filter, 
            ILogger logger) : base(csvStreamSettings, directoryManager, filter, logger)
        {
            _csvStreamSettings = csvStreamSettings;
        }

        protected override void DisposeDataStream()
        {
            throw new NotImplementedException();
        }

        protected override void InitializeFileStream()
        {
            throw new NotImplementedException();
        }

        protected override void InternalProcessDeviceTextLine(LineResultsSet resultsSet)
        {
            throw new NotImplementedException();
        }
    }
}
