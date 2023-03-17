using Ecs.Edpf.Data.StreamSettings;
using Ecs.Edpf.Devices.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Data.DataStreams
{
    public class SqlServerStream : DataStream
    {

        private SqlServerStreamSettings _sqlServerStreamSettings;

        public SqlServerStream(SqlServerStreamSettings sqlServerStreamSettings,
            IDataStreamExpressionFilter filter,
            ILogger logger) : base(filter, logger)
        {
            _sqlServerStreamSettings = sqlServerStreamSettings;
        }

        protected override void DisposeDataStream()
        {
            throw new NotImplementedException();
        }

        protected override void InitializeDataStream()
        {
            throw new NotImplementedException();
        }

        protected override void InternalProcessDeviceTextLine(LineResultsSet resultsSet)
        {
            throw new NotImplementedException();
        }
    }
}
