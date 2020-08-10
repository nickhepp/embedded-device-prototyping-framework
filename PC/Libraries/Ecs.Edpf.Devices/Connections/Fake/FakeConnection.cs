using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.Connections.Fake
{
    public class FakeConnection : IConnection
    {
        public IConnectionInfo ConnectionInfo => throw new NotImplementedException();

        public int CommandTimeout { get; set; }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        public void Open(IConnectionInfo connectionInfo)
        {
        }

        public string ReadToEndOfBuffer()
        {
            throw new NotImplementedException();
        }

        public (string text, bool endOfResponse) ReadToEndOfResponse()
        {
            throw new NotImplementedException();
        }

        public void Write(string text)
        {
            throw new NotImplementedException();
        }
    }
}
