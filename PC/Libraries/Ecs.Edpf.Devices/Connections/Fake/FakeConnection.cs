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

        public (string text, bool endOfResponse) ReadToEndOfResponse()
        {
            return ("", true);
        }

        public void Write(string text)
        {
            
        }
    }
}
