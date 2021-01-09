using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.Connections.Fake
{
    public class FakeConnection : IConnection
    {

        private FakeConnectionInfo _fakeConnectionInfo;
        public IConnectionInfo ConnectionInfo => _fakeConnectionInfo;

        public int CommandTimeout { get; set; }

        public int QueuedCharsToRead => throw new NotImplementedException();

        public int MaxReadChunkSize => throw new NotImplementedException();

        public void Close()
        {
        }

        public void Dispose()
        {
        }

        public void Open(IConnectionInfo connectionInfo)
        {
            _fakeConnectionInfo = connectionInfo as FakeConnectionInfo;
        }

        public string ReadToEndOfBuffer()
        {
            return "";
        }



        private string _writtenText;

        public void Write(string text)
        {
            _writtenText = text;
        }

        public string ReadNextChunk(int maxReadSize)
        {
            throw new NotImplementedException();
        }
    }
}
