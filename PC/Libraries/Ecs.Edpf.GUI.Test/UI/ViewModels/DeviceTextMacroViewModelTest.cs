using System;
using Ecs.Edpf.Devices.Test.Devices;
using Ecs.Edpf.GUI.ComponentModel;
using Ecs.Edpf.GUI.ComponentModel.Macros;
using Ecs.Edpf.GUI.UI.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Ecs.Edpf.GUI.Test.UI.ViewModels
{
    [TestClass]
    public class DeviceTextMacroViewModelTest
    {
        private Mock<IDeviceTextMacroStateMachine> _mockDevTxtMacroStateMachine;
        private Mock<IDeviceTextMacroBgWorkerFactory> _mockDevTxtMacroBgWorkerFactory;

        private DeviceTextMacroViewModel _deviceTextMacroVwMdl;

        private MockDevice _mockDevice;

        [TestInitialize]
        public void InitializeTest()
        {
            _mockDevTxtMacroStateMachine = new Mock<IDeviceTextMacroStateMachine>();
            _mockDevTxtMacroBgWorkerFactory = new Mock<IDeviceTextMacroBgWorkerFactory>();
            _deviceTextMacroVwMdl = new DeviceTextMacroViewModel(_mockDevTxtMacroStateMachine.Object, _mockDevTxtMacroBgWorkerFactory.Object);
            _mockDevice = new MockDevice();
        }

        private const string _oneShotCmdName = "OneShot";
        private const string _recordCmdName = "Record";
        private const string _loopCmdName = "Loop";

        private IRelayCommand GetRelayCommand(string commandName)
        {
            IRelayCommand cmd = null;
            if (commandName == _oneShotCmdName)
            {
                cmd = _deviceTextMacroVwMdl.OneShotCommand;
            }
            else if (commandName == _recordCmdName)
            {
                cmd = _deviceTextMacroVwMdl.RecordPauseCommand;
            }
            else if (commandName == _loopCmdName)
            {
                cmd = _deviceTextMacroVwMdl.ToggleLoopCommand;
            }
            return cmd;
        }

        private void SetDeviceTextMacroState(DeviceTextMacroState state)
        {
            _mockDevTxtMacroStateMachine.SetupGet(stateMachine => stateMachine.DeviceTextMacroState).Returns(state);
            _mockDevTxtMacroStateMachine.Raise(stateMachine => stateMachine.DeviceTextMacroStateChanged += null,
                 new EventArgs());
        }

        private void SetupEnabledDeviceTextMacro(DeviceTextMacroState state = DeviceTextMacroState.OpenedDevice)
        {
            _deviceTextMacroVwMdl.DeviceTextMacro = new Devices.IO.Macros.DeviceTextMacro
            {
                DeviceTextLines = new System.Collections.Generic.List<Devices.IO.Macros.DeviceTextLine>
                {
                    new Devices.IO.Macros.DeviceTextLine
                    {
                        Delay = 100, DeviceText = "CMD 1"
                    }
                },
                Loop = false
            };

            SetDeviceTextMacroState(state);
        }

        [TestMethod]
        [DataRow(_oneShotCmdName)]
        [DataRow(_loopCmdName)]
        [DataRow(_recordCmdName)]
        public void CommandCanExecute_MacroTextAndDevice_True(string cmdName)
        {
            //-- arrange
            SetupEnabledDeviceTextMacro();

            //-- act

            //-- assert
            Assert.IsTrue(GetRelayCommand(cmdName).CanExecute(null), $"'{cmdName}' command should be enabled.");
        }

        [TestMethod]
        [DataRow(_oneShotCmdName)]
        [DataRow(_loopCmdName)]
        [DataRow(_recordCmdName)]
        public void CommandCanExecute_NotOpenDevice_False(string cmdName)
        {
            //-- arrange
            SetupEnabledDeviceTextMacro();

            //-- act
            SetDeviceTextMacroState(DeviceTextMacroState.NotOpenDevice);

            //-- assert
            Assert.IsFalse(GetRelayCommand(cmdName).CanExecute(null), $"'{cmdName}' command should not be enabled.");
        }

        [TestMethod]
        [DataRow(_oneShotCmdName)]
        [DataRow(_loopCmdName)]
        public void CommandCanExecute_NoMacroText_False(string cmdName)
        {
            //-- arrange
            SetupEnabledDeviceTextMacro();

            //-- act
            _deviceTextMacroVwMdl.DeviceTextMacro = new Devices.IO.Macros.DeviceTextMacro();

            //-- assert
            Assert.IsFalse(GetRelayCommand(cmdName).CanExecute(null), $"'{cmdName}' command should not be enabled.");
        }

        [TestMethod]
        public void RecordPauseCommandExecute_IsRecording_True()
        {
            //-- arrange
            SetupEnabledDeviceTextMacro(DeviceTextMacroState.OpenedDevice);
            _mockDevTxtMacroStateMachine.Setup(devTxtMacroStateMachine => devTxtMacroStateMachine.SendDeviceTextMacroSignal(DeviceTextMacroSignal.MacroRecording)).
                Callback(() => {
                    _mockDevTxtMacroStateMachine.SetupGet(devTxtMacroStateMachine => devTxtMacroStateMachine.DeviceTextMacroState).Returns(DeviceTextMacroState.RecordingMacro);
                    _mockDevTxtMacroStateMachine.Raise(devTxtMacroStateMachine => devTxtMacroStateMachine.DeviceTextMacroStateChanged += null, new EventArgs());
                });

            //-- act
            _deviceTextMacroVwMdl.RecordPauseCommand.Execute(null);

            //-- assert
            Assert.IsTrue(_deviceTextMacroVwMdl.IsRecording);
            Assert.AreEqual(expected: DeviceTextMacroViewModel.PauseText, actual: _deviceTextMacroVwMdl.RecordPauseButtonText);
        }


    }
}
