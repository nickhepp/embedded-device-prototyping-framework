using Ecs.Edpf.Devices.IO.Cmds;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.Connections.Fake
{
    public class FakeConnection : IConnection
    {
        private Dictionary<string, Action> _commands = new Dictionary<string, Action>();
        private Dictionary<int, string> _parameters = new Dictionary<int, string>();
        private StringBuilder _readBuffer = new StringBuilder();

        private FakeConnectionInfo _fakeConnectionInfo;
        public IConnectionInfo ConnectionInfo => _fakeConnectionInfo;

        public int CommandTimeout { get; set; }

        public int QueuedCharsToRead => _readBuffer.Length;

        public int MaxReadChunkSize => int.MaxValue;


        public FakeConnection()
        {
            _commands[GetCommandParametersCommand.GetCommandParametersCommandMethodName] = ExecuteGetCommandParametersCommand;
            _commands[GetDeviceInfoCommand.GetDeviceInfoCommandMethodName] = ExecuteGetDeviceInfoCommand;
            _commands[GetRegisteredCommandsCommand.GetRegisteredCommandsCommandMethodName] = ExecuteGetRegisteredCommandsCommand;

            for (int pIdx = 0; pIdx < FakeDevice.FakeDeviceParameterCount; pIdx++)
            {
                _parameters[pIdx] = String.Empty;
            }
        }


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
            string valToReturn = _readBuffer.ToString();
            _readBuffer.Clear();
            return valToReturn;
        }

        public void Write(string text)
        {
            if (!text.EndsWith(Constants.LineEnding.ToString()))
            {
                throw new Exception("Line does not end with expected line ending.");
            }
  
            int lineEndingIndex = text.IndexOf(Constants.LineEnding);
            string textToProcess = text.Substring(0, lineEndingIndex);

            // queue the value to be sent back
            _readBuffer.Append(textToProcess);
            _readBuffer.Append(Constants.LineEnding);

            if (SetParameterValue(textToProcess))
            {
                // successfully read the parameter
                _readBuffer.Append(Constants.CommandResponseLineEnding);
            }
            else if (ExecuteCommand(textToProcess))
            {
                // successfully executed the command
                _readBuffer.Append(Constants.CommandResponseLineEnding);
            }
            else
            {
                // unidentified response
                _readBuffer.Append(Constants.CommandResponseLineEnding);
            }
        }


        private bool ExecuteCommand(string potentionalCommandLine)
        {
            bool retval = false;
            if (potentionalCommandLine.StartsWith(Constants.CommandNamePrefix) && potentionalCommandLine.EndsWith(Constants.CommandNameEnding))
            {
                string potentialCmdName = potentionalCommandLine.Substring(Constants.CommandNamePrefix.Length,
                    potentionalCommandLine.Length - (Constants.CommandNamePrefix.Length + Constants.CommandNameEnding.Length));
                Action action = null;
                if (_commands.TryGetValue(potentialCmdName, out action))
                {
                    action.Invoke();
                    retval = true;
                }

            }
            return retval;
        }

        private bool SetParameterValue(string potentionalParamLine)
        {
            bool retval = false;
            if (potentionalParamLine.StartsWith(Constants.CommandParameterPrefix))
            {
                int endIndex = potentionalParamLine.IndexOf(Constants.CommandParameterSuffix);
                if (endIndex != -1)
                {
                    string potentionalParam = potentionalParamLine.Substring(Constants.CommandParameterPrefix.Length, endIndex - Constants.CommandParameterPrefix.Length);
                    int paramIndexToAssign;
                    if (int.TryParse(potentionalParam, out paramIndexToAssign))
                    {
                        string paramVal = potentionalParamLine.Substring(endIndex + Constants.CommandParameterSuffix.Length);
                        _parameters[paramIndexToAssign] = paramVal;
                        retval = true;
                    }
                }
            }

            return retval;
        }

        private void ExecuteGetCommandParametersCommand()
        {
            for (int pIdx = 0; pIdx < FakeDevice.FakeDeviceParameterCount; pIdx++)
            {
                _readBuffer.AppendLine($"p[{pIdx}]={_parameters[pIdx]}");
            }
        }

        private void ExecuteGetDeviceInfoCommand()
        {
            _readBuffer.AppendLine("Test Device");
            string version = "V" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            _readBuffer.AppendLine(version);
            _readBuffer.AppendLine("cmd params count:999");
        }

        private void ExecuteGetRegisteredCommandsCommand()
        {
            foreach (string commandName in _commands.Keys)
            {
                _readBuffer.AppendLine(commandName);
            }
        }

        public string ReadNextChunk(int maxReadSize)
        {
            int amtToRead = maxReadSize;
            if (maxReadSize > _readBuffer.Length)
            {
                amtToRead = _readBuffer.Length;
            }

            string readAmt = _readBuffer.ToString().Substring(0, amtToRead);
            _readBuffer = _readBuffer.Remove(0, amtToRead);
            return readAmt;
        }

    }
}
