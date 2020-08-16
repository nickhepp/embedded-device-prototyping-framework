using Ecs.Edpf.Connections;
using Ecs.Edpf.Connections.Serial;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace Ecs.Edpf.Devices.Connections.Serial
{
    public class SerialPortConnection : IConnection
    {

        private SerialPort _connection;

        private SerialPortConnectionInfo _connectionInfo;

        public IConnectionInfo ConnectionInfo 
        { 
            get
            {
                return _connectionInfo;
            }
        }

        public int CommandTimeout { get; set; } = Constants.DefaultTimeOut;

        public SerialPortConnection()
        {
        }



        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Open(IConnectionInfo connectionInfo)
        {
            _connectionInfo = connectionInfo as SerialPortConnectionInfo;
            _connection = new System.IO.Ports.SerialPort(_connectionInfo.DevicePort, (int)_connectionInfo.DeviceBaudRate);
        }

        public string ReadToEndOfBuffer()
        {
            int bytesToRead = _connection.BytesToRead;
            string returnLine = "";
            for (int k = 0; k < bytesToRead; k++)
            {
                int byteVal = _connection.ReadByte();
                returnLine = returnLine + ((char)byteVal).ToString();
            }
            return returnLine;
        }

        public (string text, bool endOfResponse) ReadToEndOfResponse()
        {
            string returnLine = "";
            bool gotCmdRespLineEnding = false;
            DateTime startRead = DateTime.Now;
            while (!gotCmdRespLineEnding && DateTime.Now.Subtract(startRead).TotalMilliseconds < CommandTimeout)
            {
                int bytesToRead = _connection.BytesToRead;
                if (bytesToRead > 0)
                {
                    int byteVal = _connection.ReadByte();
                    returnLine = returnLine + ((char)byteVal).ToString();
                    gotCmdRespLineEnding = returnLine.EndsWith(Constants.CommandResponseLineEnding);
                }
            }

            return (returnLine, gotCmdRespLineEnding);
        }

        public void Write(string text)
        {
            _connection.WriteLine(text);
        }

    }
}
