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

        public int QueuedCharsToRead => _connection.BytesToRead;

        public int MaxReadChunkSize => 1;

        public SerialPortConnection()
        {
        }

        public void Close()
        {
            _connection.Close();
        }

        public void Dispose()
        {
            _connection.Dispose();
            _connection = null;
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



        public void Write(string text)
        {
            _connection.Write(text);
        }

        public string ReadNextChunk(int maxReadSize)
        {
            return ((char)_connection.ReadByte()).ToString();
        }
    }
}
