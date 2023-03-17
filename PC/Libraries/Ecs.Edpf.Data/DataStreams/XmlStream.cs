using Ecs.Edpf.Data.StreamSettings;
using Ecs.Edpf.Devices.IO.File;
using Ecs.Edpf.Devices.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Data.DataStreams
{
    public class XmlStream : BaseFileStream
    {


        private XmlStreamSettings _xmlStreamSettings;
        
        public XmlStream(XmlStreamSettings xmlStreamSettings,
            IDirectoryManager directoryManager,
            IDataStreamExpressionFilter filter,
            ILogger logger) : base(xmlStreamSettings, directoryManager, filter, logger)
        {
            _xmlStreamSettings = xmlStreamSettings;
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
