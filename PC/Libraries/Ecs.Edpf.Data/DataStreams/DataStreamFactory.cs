using Ecs.Edpf.Data.StreamSettings;
using Ecs.Edpf.Devices.IO.File;
using Ecs.Edpf.Devices.Logging;
using System;

namespace Ecs.Edpf.Data.DataStreams
{
    public class DataStreamFactory : IDataStreamFactory
    {
        // CsvStreamSettings
        // JsonStreamSettings
        // SqlServerStreamSettings
        // XmlStreamSettings

        public IDataStream CreateStream(DataStreamSettings streamSettings, ILogger logger)
        {
            IDataStream dStream = null;
            IDataStreamExpressionFilter filter = new DataStreamExpressionFilter(streamSettings.Expression);
            if (streamSettings is CsvStreamSettings csvStreamSettings)
            {
                dStream = new CsvStream(csvStreamSettings, new DirectoryManager(), filter, logger);
            }
            else if (streamSettings is JsonStreamSettings jsonStreamSettings)
            {
                dStream = new JsonStream(jsonStreamSettings, new DirectoryManager(), filter, logger);
            }
            else if (streamSettings is SqlServerStreamSettings sqlServerStreamSettings)
            {
                dStream = new SqlServerStream(sqlServerStreamSettings, filter, logger);
            }
            else if (streamSettings is XmlStreamSettings xmlStreamSettings)
            {
                dStream = new XmlStream(xmlStreamSettings, new DirectoryManager(), filter, logger);
            }
            else
            {
                throw new ArgumentException($"Did not find stream type for {streamSettings.TypeName} settings.");
            }

            return dStream;
        }
    }
}
