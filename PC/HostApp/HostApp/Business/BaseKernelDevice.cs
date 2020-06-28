using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.Business
{
    public class BaseKernelDevice : BaseDevice, IDeviceWithConnectionInfo, IDeviceWithTimeouts, IBaseKernelDevice
    {
        private const string CommandParameterPrefix = "p[";
        private const string CommandParameterSuffix = "]=";

        public const string DeviceOutputBufferErrorPrefix = "ERR:";

        private const char LineEnding = '\n';

        private const string CommandResponseLineEnding = "\n>";

        SerialPort _connection;

        public DeviceConnectionInfo ConnectionInfo { get; set; }

        private int _commandTimeout = 5 * 1000;
        public int CommandTimeout
        {
            get => _commandTimeout;
            set => _commandTimeout = value;
        }

        protected override bool InternalOpen()
        {
            if (ConnectionInfo == null)
            {
                throw new Exception($"{nameof(ConnectionInfo)} is not set.");
            }
            _connection = new System.IO.Ports.SerialPort(ConnectionInfo.DevicePort, (int)ConnectionInfo.DeviceBaudRate);
            _connection.Open();
            int bytesToRead = _connection.BytesToRead;
            string returnLine = "";
            for (int k = 0; k < bytesToRead; k++)
            {
                int byteVal = _connection.ReadByte();
                returnLine = returnLine + ((char)byteVal).ToString();
            }
            if (!string.IsNullOrEmpty(returnLine))
            {
                DeviceOutputBuffer.Add(returnLine);
            }
            return base.InternalOpen();
        }

        protected override string InternalWriteLine(string cmdText)
        {
            if (_connection == null)
            {
                throw new Exception($"The connection is not open.");
            }
            _connection.Write(cmdText + LineEnding);

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
                    gotCmdRespLineEnding = returnLine.EndsWith(CommandResponseLineEnding);
                }
            }

            if (!gotCmdRespLineEnding)
            {
                returnLine = $"{DeviceOutputBufferErrorPrefix}Command timeout.{CommandResponseLineEnding}";
            }

            return returnLine;
        }

        protected override bool InternalClose()
        {
            if (_connection == null)
            {
                throw new Exception($"The connection is not open.");
            }
            _connection.Close();
            _connection.Dispose();
            _connection = null;

            return base.InternalClose();
        }

        protected virtual string InternalExecuteCommand(string cmdName)
        {
            return Write($"cmd:{cmdName}()");
        }

        public string ExecuteCommand(string cmdName)
        {
            return InternalExecuteCommand(cmdName);
        }


        protected virtual void InternalSetCommandParameter(int idx, string paramValue)
        {
            if (_connection == null)
            {
                throw new Exception($"The connection is not open.");
            }
            string cmdParamStr = $"{CommandParameterPrefix}{idx}{CommandParameterSuffix}{paramValue}";
            Write(cmdParamStr);
        }

        public void SetCommandParameter(int idx, string paramValue)
        {
            InternalSetCommandParameter(idx, paramValue);
        }

        public int GetCommandParameterCount()
        {
            const string cmdParamsCountPrefix = "cmd params count:";
            string deviceResponse = InternalExecuteCommand("printDeviceInfo");
            string[] deviceResponseLines = deviceResponse.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string cmdParamCntLine = deviceResponseLines.Where(line => line.StartsWith(cmdParamsCountPrefix)).SingleOrDefault();
            if (string.IsNullOrEmpty(cmdParamCntLine))
            {
                DeviceOutputBuffer.Add($"{DeviceOutputBufferErrorPrefix}Did not find command parameter count prefix.{CommandResponseLineEnding}");
                return -1;
            }

            int cmdParamCnt;
            if (!int.TryParse(cmdParamCntLine.Substring(cmdParamsCountPrefix.Length), out cmdParamCnt))
            {
                DeviceOutputBuffer.Add($"{DeviceOutputBufferErrorPrefix}Error parsing command paramter count.{CommandResponseLineEnding}");
                return -1;
            }

            return cmdParamCnt;
        }

        public Dictionary<int, string> GetCommandParams()
        {
            Dictionary<int, string> cmdParams = new Dictionary<int, string>();
            string deviceResponse = ExecuteCommand("printCommandParams");
            List<string> devRespLines = deviceResponse.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).
                        Where(devRespLine =>
                        {
                            int suffixIdx = devRespLine.IndexOf(CommandParameterSuffix);
                            return (devRespLine.StartsWith(CommandParameterPrefix) && (suffixIdx >= CommandParameterPrefix.Length + 1));
                        }).ToList();
        
            foreach (string devRespLine in devRespLines)
            {
                string[] devRespLineSplits = devRespLine.Split(new string[] { CommandParameterPrefix, CommandParameterSuffix },
                                        StringSplitOptions.RemoveEmptyEntries);
                if (devRespLineSplits.Length == 2)
                {
                    int cmdParamIdx;
                    if (int.TryParse(devRespLineSplits[0], out cmdParamIdx))
                    {
                        devRespLineSplits[1] = devRespLineSplits[1].Trim(new char[] { '\'', '\r' });
                        cmdParams.Add(cmdParamIdx, devRespLineSplits[1]);
                    }
                }
            }

            return cmdParams;
        }

        public string GetDeviceInfo()
        {
            string devInfo = ExecuteCommand("printDeviceInfo");
            return devInfo;
        }

    }
}
