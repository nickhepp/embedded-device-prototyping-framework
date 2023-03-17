using Ecs.Edpf.Data.StreamSettings;
using Ecs.Edpf.Devices.IO.File;
using Ecs.Edpf.Devices.Logging;
using System;

namespace Ecs.Edpf.Data.DataStreams
{
    public class JsonStream : BaseFileStream
    {

        private JsonStreamSettings _jsonStreamSettings;

        public JsonStream(JsonStreamSettings jsonStreamSettings,
            IDirectoryManager directoryManager,
            IDataStreamExpressionFilter filter,
            ILogger logger) : base(jsonStreamSettings, directoryManager, filter, logger)
        {
            _jsonStreamSettings = jsonStreamSettings;
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
