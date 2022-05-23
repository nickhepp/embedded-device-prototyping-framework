using System;
using Ecs.Edpf.Devices.Test.Devices;
using Ecs.Edpf.GUI.ComponentModel;
using Ecs.Edpf.Devices.ComponentModel.Macros;
using Ecs.Edpf.GUI.UI.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Ecs.Edpf.Devices.ComponentModel.Macros.Instructions;
using Ecs.Edpf.Devices.Test.ComponentModel;
using Ecs.Edpf.Devices.ComponentModel;

namespace Ecs.Edpf.GUI.Test.UI.ViewModels
{
    [TestClass]
    public class DeviceTextMacroViewModelTest
    {
        private Mock<IDeviceTextMacroStateMachine> _mockDevTxtMacroStateMachine;
        private Mock<IDeviceTextMacroBgWorkerFactory> _mockDevTxtMacroBgWorkerFactory;
        private Mock<IInstructionCollectionFactory> _mockInstructionCollectionFactory;
        private IDateTimeProvider _dateTimeProvider;

        private DeviceTextMacroViewModel _deviceTextMacroVwMdl;

        private MockDevice _mockDevice;

        [TestInitialize]
        public void InitializeTest()
        {
            _mockDevTxtMacroStateMachine = new Mock<IDeviceTextMacroStateMachine>();
            _mockDevTxtMacroStateMachine.SetupGet(devTxtMacroSttMchn => devTxtMacroSttMchn.DeviceTextMacroState).Returns(DeviceTextMacroState.NotOpenDevice);

            _mockDevTxtMacroBgWorkerFactory = new Mock<IDeviceTextMacroBgWorkerFactory>();
            _mockInstructionCollectionFactory = new Mock<IInstructionCollectionFactory>();

            _dateTimeProvider = new StubDateTimeProvider();

            _deviceTextMacroVwMdl = new DeviceTextMacroViewModel(_mockDevTxtMacroStateMachine.Object, _mockDevTxtMacroBgWorkerFactory.Object, _mockInstructionCollectionFactory.Object, _dateTimeProvider);
            _mockDevice = new MockDevice();
        }


        [TestMethod]
        [DataRow(DeviceTextMacroState.LoopingMacro)]
        [DataRow(DeviceTextMacroState.OneShottingMacro)]
        public void StopCommandCanExecute_ActiveTextSending_True(DeviceTextMacroState devTxtMacroState)
        {
            //-- arrange


            //-- act
            SetDeviceTextMacroState(devTxtMacroState);

            //-- assert
            Assert.IsTrue(_deviceTextMacroVwMdl.StopCommand.CanExecute(), $"DeviceTextMacroState of '{devTxtMacroState}' should allow for the stop condition.");
        }

        [TestMethod]
        [DataRow(DeviceTextMacroState.NotOpenDevice)]
        [DataRow(DeviceTextMacroState.OpenedDevice)]
        public void StopCommandCanExecute_NotActiveTextSending_False(DeviceTextMacroState devTxtMacroState)
        {
            //-- arrange

            //-- act
            SetDeviceTextMacroState(devTxtMacroState);

            //-- assert
            Assert.IsFalse(_deviceTextMacroVwMdl.StopCommand.CanExecute(), $"DeviceTextMacroState of '{devTxtMacroState}' should not allow for the stop condition.");
        }


        [TestMethod]
        [DataRow(DeviceTextMacroState.OpenedDevice)]
        public void OneShotCommandCanExecute_OpenedDevice_True(DeviceTextMacroState devTxtMacroState)
        {
            //-- arrange

            //-- act
            SetDeviceTextMacroState(devTxtMacroState);

            //-- assert
            Assert.IsTrue(_deviceTextMacroVwMdl.OneShotCommand.CanExecute(), $"DeviceTextMacroState of '{devTxtMacroState}' should allow for the one shot command.");
        }

        [TestMethod]
        [DataRow(DeviceTextMacroState.NotOpenDevice)]
        [DataRow(DeviceTextMacroState.LoopingMacro)]
        [DataRow(DeviceTextMacroState.OneShottingMacro)]
        public void OneShotCommandCanExecute_NotOpenedDevice_False(DeviceTextMacroState devTxtMacroState)
        {
            //-- arrange

            //-- act
            SetDeviceTextMacroState(devTxtMacroState);

            //-- assert
            Assert.IsFalse(_deviceTextMacroVwMdl.OneShotCommand.CanExecute(), $"DeviceTextMacroState of '{devTxtMacroState}' should not allow for the one shot command.");
        }

        [TestMethod]
        [DataRow(DeviceTextMacroState.OpenedDevice)]
        public void LoopingCommandCanExecute_OpenedDevice_True(DeviceTextMacroState devTxtMacroState)
        {
            //-- arrange

            //-- act
            SetDeviceTextMacroState(devTxtMacroState);

            //-- assert
            Assert.IsTrue(_deviceTextMacroVwMdl.LoopCommand.CanExecute(), $"DeviceTextMacroState of '{devTxtMacroState}' should allow for the loop command.");
        }

        [TestMethod]
        [DataRow(DeviceTextMacroState.NotOpenDevice)]
        [DataRow(DeviceTextMacroState.LoopingMacro)]
        [DataRow(DeviceTextMacroState.OneShottingMacro)]
        public void LoopingCommandCanExecute_NotOpenedDevice_False(DeviceTextMacroState devTxtMacroState)
        {
            //-- arrange

            //-- act
            SetDeviceTextMacroState(devTxtMacroState);

            //-- assert
            Assert.IsFalse(_deviceTextMacroVwMdl.LoopCommand.CanExecute(), $"DeviceTextMacroState of '{devTxtMacroState}' should not allow for the loop command.");
        }

        [DataTestMethod]
        [DataRow(DeviceTextMacroState.NotOpenDevice)]
        [DataRow(DeviceTextMacroState.OpenedDevice)]
        public void MacroTextEnabled_NotActiveSendingData_True(DeviceTextMacroState devTxtMacroState)
        {
            //-- arrange

            //-- act
            SetDeviceTextMacroState(devTxtMacroState);

            //-- assert
            Assert.IsTrue(_deviceTextMacroVwMdl.MacroTextEnabled, "Text editing should be enabled when not sending data.");
        }


        [DataTestMethod]
        [DataRow(DeviceTextMacroState.LoopingMacro)]
        [DataRow(DeviceTextMacroState.OneShottingMacro)]
        public void MacroTextEnabled_ActiveSendingData_False(DeviceTextMacroState devTxtMacroState)
        {
            //-- arrange

            //-- act
            SetDeviceTextMacroState(devTxtMacroState);

            //-- assert
            Assert.IsFalse(_deviceTextMacroVwMdl.MacroTextEnabled, "Text editing should not be enabled when sending data.");
        }


        private void SetDeviceTextMacroState(DeviceTextMacroState state)
        {
            _mockDevTxtMacroStateMachine.SetupGet(stateMachine => stateMachine.DeviceTextMacroState).Returns(state);
            _mockDevTxtMacroStateMachine.Raise(stateMachine => stateMachine.DeviceTextMacroStateChanged += null,
                 new EventArgs());
        }


    }
}
