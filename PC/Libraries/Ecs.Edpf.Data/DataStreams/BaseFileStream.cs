using Ecs.Edpf.Data.StreamSettings;
using Ecs.Edpf.Devices.IO.File;
using Ecs.Edpf.Devices.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Data.DataStreams
{
    public abstract class BaseFileStream : DataStream
    {

        private BaseFileStreamSettings _fileStreamSettings;
        private IDirectoryManager _directoryManager;

        protected BaseFileStream(BaseFileStreamSettings fileStreamSettings,
            IDirectoryManager directoryManager,
            IDataStreamExpressionFilter filter, 
            ILogger logger) : base(filter, logger)
        {
            _fileStreamSettings = fileStreamSettings;
            _directoryManager = directoryManager;
        }

        protected abstract void InitializeFileStream();

        protected override void InitializeDataStream()
        {
            if (!_directoryManager.DirectoryExists(_fileStreamSettings.DirectoryPath))
            {
                _directoryManager.CreateDirectory(_fileStreamSettings.DirectoryPath);
            }
            InitializeFileStream();
        }

    }
}
