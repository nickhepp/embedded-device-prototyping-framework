﻿using Ecs.Edpf.Devices.Connections;
using Ecs.Edpf.Devices.IO.Cmds;
using Ecs.Edpf.Devices.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.Devices
{
    public abstract class BaseKernelDevice : IDevice, IDisposable, IBaseKernelDevice
    {


        public virtual bool SupportsEmbeddedCodeGeneration { get; } = false;


        public abstract int ParameterCount { get; }


        private bool _isOpen = false;
        public bool IsOpen
        {
            get
            {
                return _isOpen;
            }
            private set
            {
                _isOpen = value;
                RaiseNotifyPropertyChanged();
            }
        }


        private readonly BindingList<string> _deviceOutputBuffer = new BindingList<string>();
        public BindingList<string> DeviceOutputBuffer => _deviceOutputBuffer;

        private readonly BindingList<string> _deviceInputBuffer = new BindingList<string>();
        public BindingList<string> DeviceInputBuffer => _deviceInputBuffer;


        private int _commandTimeout = 5 * 1000;
        public int CommandTimeout
        {
            get => _commandTimeout;
            set => _commandTimeout = value;
        }


        private IConnection _connection;

        public IConnectionInfo ConnectionInfo { get; set; }

        private ReadOnlyCollection<IDeviceCommand> _deviceCommands;
        public ReadOnlyCollection<IDeviceCommand> DeviceCommands 
        {
            get
            {
                if (_deviceCommands == null)
                {
                    _deviceCommands = new ReadOnlyCollection<IDeviceCommand>(GetDeviceCommands());
                }
                return _deviceCommands;
            }
        }

        public ILogger DeviceLogger { get; set; }

        private IConnectionFactory _deviceConnectionFactory;


        public BaseKernelDevice(IConnectionFactory deviceConnectionFactory, IConnectionInfo connectionInfo)
        {
            _deviceConnectionFactory = deviceConnectionFactory;
            ConnectionInfo = connectionInfo;
        }

        protected abstract List<IDeviceCommand> GetDeviceCommands();

        protected bool InternalOpen()
        {
            if (ConnectionInfo == null)
            {
                throw new Exception($"{nameof(ConnectionInfo)} is not set.");
            }

            _connection = _deviceConnectionFactory.GetConnection();
            _connection.Open(ConnectionInfo);

            // do an initial flush of the device
            string returnLine = _connection.ReadToEndOfBuffer();
            if (!string.IsNullOrEmpty(returnLine))
            {
                DeviceOutputBuffer.Add(returnLine);
            }
            return true;
        }

        protected string InternalWriteLine(string cmdText)
        {
            if (_connection == null)
            {
                throw new Exception($"The connection is not open.");
            }
            _connection.Write(cmdText + Constants.LineEnding);

            (string text, bool endOfResponse) response = ReadToEndOfResponse();
            string returnLine;
            if (!response.endOfResponse)
            {
                returnLine = $"{Constants.DeviceOutputBufferErrorPrefix}Command timeout.{Constants.CommandResponseLineEnding}";
            }
            else
            {
                returnLine = response.text;
            }

            return returnLine;
        }

        private (string text, bool endOfResponse) ReadToEndOfResponse()
        {
            StringBuilder returnLineBldr = new StringBuilder();
            bool gotCmdRespLineEnding = false;
            DateTime startRead = DateTime.Now;
            string returnLine = "";
            while (!gotCmdRespLineEnding && DateTime.Now.Subtract(startRead).TotalMilliseconds < CommandTimeout)
            {
                int queuedCharsToRead = _connection.QueuedCharsToRead;
                if (queuedCharsToRead > 0)
                {
                    string chunk = _connection.ReadNextChunk(_connection.MaxReadChunkSize);
                    returnLineBldr.Append(chunk);
                    returnLine = returnLineBldr.ToString();
                    gotCmdRespLineEnding = returnLine.EndsWith(Constants.CommandResponseLineEnding);
                }
            }

            return (returnLine, gotCmdRespLineEnding);
        }

        protected virtual string InternalExecuteCommand(string cmdName)
        {
            return Write($"{Constants.CommandNamePrefix}{cmdName}{Constants.CommandNameEnding}");
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
            string cmdParamStr = $"{Constants.CommandParameterPrefix}{idx}{Constants.CommandParameterSuffix}{paramValue}";
            Write(cmdParamStr);
        }

        public void SetCommandParameter(int idx, string paramValue)
        {
            // TODO: test setting the parameter count
            if (idx < 0 || ParameterCount <= idx)
            {
                throw new ArgumentException($"Parameter index {idx} is invalid.  The valid range is [{0}, {ParameterCount - 1}]");
            }

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
                DeviceOutputBuffer.Add($"{Constants.DeviceOutputBufferErrorPrefix}Did not find command parameter count prefix.{Constants.CommandResponseLineEnding}");
                return -1;
            }

            int cmdParamCnt;
            if (!int.TryParse(cmdParamCntLine.Substring(cmdParamsCountPrefix.Length), out cmdParamCnt))
            {
                DeviceOutputBuffer.Add($"{Constants.DeviceOutputBufferErrorPrefix}Error parsing command paramter count.{Constants.CommandResponseLineEnding}");
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
                            int suffixIdx = devRespLine.IndexOf(Constants.CommandParameterSuffix);
                            return (devRespLine.StartsWith(Constants.CommandParameterPrefix) && (suffixIdx >= Constants.CommandParameterPrefix.Length + 1));
                        }).ToList();
        
            foreach (string devRespLine in devRespLines)
            {
                string[] devRespLineSplits = devRespLine.Split(new string[] { Constants.CommandParameterPrefix, Constants.CommandParameterSuffix },
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
            string devInfo = ExecuteCommand(GetDeviceInfoCommand.GetDeviceInfoCommandMethodName);
            return devInfo;
        }

        public string GetRegisteredCommands()
        {
            string commands = ExecuteCommand(GetRegisteredCommandsCommand.GetRegisteredCommandsCommandMethodName);
            return commands;
        }

         public bool Open()
        {
            if (IsOpen)
            {
                throw new Exception("Error opening device more than once.");
            }
            IsOpen = InternalOpen();
            if (DeviceOpened != null)
            {
                DeviceOpened(this, new EventArgs());
            }
            return IsOpen;
        }

        public void Close()
        {
            if (!IsOpen)
            {
                throw new Exception("Device is not open.");
            }
            _connection.Close();
            _connection.Dispose();
            _connection = null;

            IsOpen = false;
            if (DeviceClosed != null)
            {
                DeviceClosed(this, new EventArgs());
            }
        }

        public void SafeClose()
        {
            _connection.SafeClose();
            _connection.Dispose();
            _connection = null;

            IsOpen = false;
            if (DeviceSafeClosed != null)
            {
                if (DeviceSafeClosed != null)
                {
                    DeviceSafeClosed(this, new EventArgs());
                }
            }
        }


        protected void RaiseNotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private const string DeviceInteractionStartToken = "-->";
        private const string DeviceInteractionEndToken = "<--";

        private string GetDeviceDescription()
        {
            return $"{ConnectionInfo.ConnectionType}-[{ConnectionInfo.ConnectionName}]";
        }

        private void LogDeviceCommandText(string cmdText)
        {
            if (DeviceLogger != null)
            {
                string devLogStr = $"{GetDeviceDescription()}: device request{Environment.NewLine}{DeviceInteractionStartToken}{Environment.NewLine}{cmdText}{Environment.NewLine}{DeviceInteractionEndToken}";
                DeviceLogger.LogInformation(devLogStr);
            }
        }

        private void LogDeviceResponse(string response)
        {
            if (DeviceLogger != null)
            {
                string devLogStr = $"{GetDeviceDescription()}: device response{Environment.NewLine}{DeviceInteractionStartToken}{Environment.NewLine}{response}{Environment.NewLine}{DeviceInteractionEndToken}";
                DeviceLogger.LogInformation(devLogStr);
            }
        }
 
        public void Flush()
        {
            Write("");
        }

        public string Write(string cmdText)
        {
            if (!IsOpen)
            {
                throw new Exception("Cannot write to an opened device.");
            }
            _deviceInputBuffer.Add(cmdText);
            LogDeviceCommandText(cmdText);
            string response = InternalWriteLine(cmdText);
            LogDeviceResponse(response);
            if (!string.IsNullOrEmpty(response))
            {
                DeviceOutputBuffer.Add(response);
            }
            return response;
        }

        public void Dispose()
        {
            if (IsOpen)
            {
                Close();
            }
        }

        public void ExecuteCommand(IDeviceCommand cmd)
        {
            List<string> lines = cmd.GetCommandTextLines();
            foreach (string line in lines)
            {
                Write(line);
            }
        }

        public void AddDeviceCommands(List<IDeviceCommand> builtCommands)
        {
            _deviceCommands = new ReadOnlyCollection<IDeviceCommand>(builtCommands);
            RaiseNotifyPropertyChanged(nameof(DeviceCommands));
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        public event EventHandler DeviceOpened;

        public event EventHandler DeviceClosed;

        public event EventHandler DeviceSafeClosed;

    }
}
