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
            _mockDevTxtMacroStateMachine.SetupGet(devTxtMacroSttMchn => devTxtMacroSttMchn.DeviceTextMacroState).Returns(DeviceTextMacroState.NotOpenDevice);

            _mockDevTxtMacroBgWorkerFactory = new Mock<IDeviceTextMacroBgWorkerFactory>();
            _deviceTextMacroVwMdl = new DeviceTextMacroViewModel(_mockDevTxtMacroStateMachine.Object, _mockDevTxtMacroBgWorkerFactory.Object);
            _mockDevice = new MockDevice();
        }

        private const string _oneShotCmdName = "OneShot";
        private const string _stopCmdName = "Stop";
        private const string _loopCmdName = "Loop";

        private IRelayCommand GetRelayCommand(string commandName)
        {
            IRelayCommand cmd = null;
            if (commandName == _oneShotCmdName)
            {
                cmd = _deviceTextMacroVwMdl.OneShotCommand;
            }
            else if (commandName == _stopCmdName)
            {
                cmd = _deviceTextMacroVwMdl.StopCommand;
            }
            else if (commandName == _loopCmdName)
            {
                cmd = _deviceTextMacroVwMdl.LoopCommand;
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


        [DataTestMethod]
        [DataRow(DeviceTextMacroState.NotOpenDevice)]
        [DataRow(DeviceTextMacroState.LoopingMacro)]
        [DataRow(DeviceTextMacroState.OneShottingMacro)]
        public void MacroTextEnabled_OtherStateToOpenedDeviceState_True(DeviceTextMacroState startState)
        {
            //-- arrange
            // go to NOT open
            _mockDevTxtMacroStateMachine.SetupGet(devTxtMacroSttMchn => devTxtMacroSttMchn.DeviceTextMacroState).Returns(startState);
            _mockDevTxtMacroStateMachine.Raise(devTxtMacroSttMchn => devTxtMacroSttMchn.DeviceTextMacroStateChanged += null, new EventArgs());

            //-- act
            // go to open
            _mockDevTxtMacroStateMachine.SetupGet(devTxtMacroSttMchn => devTxtMacroSttMchn.DeviceTextMacroState).Returns(DeviceTextMacroState.OpenedDevice);
            _mockDevTxtMacroStateMachine.Raise(devTxtMacroSttMchn => devTxtMacroSttMchn.DeviceTextMacroStateChanged += null, new EventArgs());

            //-- assert
            Assert.IsTrue(_deviceTextMacroVwMdl.MacroTextEnabled);
        }




        [DataTestMethod]
        [DataRow(DeviceTextMacroState.NotOpenDevice)]
        [DataRow(DeviceTextMacroState.LoopingMacro)]
        [DataRow(DeviceTextMacroState.OneShottingMacro)]
        public void MacroTextEnabled_OpenedDeviceStateToOtherState_False(DeviceTextMacroState nextState)
        {
            //-- arrange
            // go to open
            _mockDevTxtMacroStateMachine.SetupGet(devTxtMacroSttMchn => devTxtMacroSttMchn.DeviceTextMacroState).Returns(DeviceTextMacroState.OpenedDevice);
            _mockDevTxtMacroStateMachine.Raise(devTxtMacroSttMchn => devTxtMacroSttMchn.DeviceTextMacroStateChanged += null, new EventArgs());

            //-- act
            // go to NOT open
            _mockDevTxtMacroStateMachine.SetupGet(devTxtMacroSttMchn => devTxtMacroSttMchn.DeviceTextMacroState).Returns(nextState);
            _mockDevTxtMacroStateMachine.Raise(devTxtMacroSttMchn => devTxtMacroSttMchn.DeviceTextMacroStateChanged += null, new EventArgs());

            //-- assert
            Assert.IsFalse(_deviceTextMacroVwMdl.MacroTextEnabled);
        }


        [TestMethod]
        [DataRow(_oneShotCmdName)]
        [DataRow(_loopCmdName)]
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



    }
}
