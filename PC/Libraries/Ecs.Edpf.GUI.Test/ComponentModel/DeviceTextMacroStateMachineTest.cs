using Ecs.Edpf.GUI.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Ecs.Edpf.GUI.Test.ComponentModel
{
    [TestClass]
    public class DeviceTextMacroStateMachineTest
    {

        private DeviceTextMacroStateMachine _deviceTextMacroStateMachine;

        private int _stateChangedCnt = 0;

        private void DeviceTextMacroStateMachineDeviceTextMacroStateChanged(object sender, EventArgs e)
        {
            _stateChangedCnt++;
        }

        [TestInitialize]
        public void InitializeTest()
        {
            _deviceTextMacroStateMachine = new DeviceTextMacroStateMachine();
            _deviceTextMacroStateMachine.DeviceTextMacroStateChanged += DeviceTextMacroStateMachineDeviceTextMacroStateChanged;
            _stateChangedCnt = 0;
        }

        [TestMethod]
        public void SendSignal_NotOpenDeviceAndDeviceOpened_OpenedDevice()
        {
            // arrange

            // act
            _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(DeviceTextMacroSignal.DeviceOpened);

            // assert
            Assert.AreEqual(DeviceTextMacroState.OpenedDevice, _deviceTextMacroStateMachine.DeviceTextMacroState);
            Assert.AreEqual(1, _stateChangedCnt);
        }

        [TestMethod]
        public void SendSignal_OpenedDeviceAndMacroLooping_LoopingMacro()
        {
            // arrange
            _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(DeviceTextMacroSignal.DeviceOpened);
            _stateChangedCnt = 0;

            // act
            _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(DeviceTextMacroSignal.MacroLooping);


            // assert
            Assert.AreEqual(DeviceTextMacroState.LoopingMacro, _deviceTextMacroStateMachine.DeviceTextMacroState);
            Assert.AreEqual(1, _stateChangedCnt);
        }

        [TestMethod]
        public void SendSignal_OpenedDeviceAndDeviceNotOpened_NotOpenDevice()
        {
            // arrange
            _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(DeviceTextMacroSignal.DeviceOpened);
            _stateChangedCnt = 0;

            // act
            _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(DeviceTextMacroSignal.DeviceNotOpened);


            // assert
            Assert.AreEqual(DeviceTextMacroState.NotOpenDevice, _deviceTextMacroStateMachine.DeviceTextMacroState);
            Assert.AreEqual(1, _stateChangedCnt);
        }


        [TestMethod]
        public void SendSignal_LoopingMacroAndDeviceNotOpened_NotOpenDevice()
        {
            // arrange
            _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(DeviceTextMacroSignal.DeviceOpened);
            _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(DeviceTextMacroSignal.MacroLooping);
            _stateChangedCnt = 0;

            // act
            _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(DeviceTextMacroSignal.DeviceNotOpened);

            // assert
            Assert.AreEqual(DeviceTextMacroState.NotOpenDevice, _deviceTextMacroStateMachine.DeviceTextMacroState);
            Assert.AreEqual(1, _stateChangedCnt);
        }

        [TestMethod]
        public void SendSignal_LoopingMacroAndMacroStopLooping_OpenedDevice()
        {
            // arrange
            _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(DeviceTextMacroSignal.DeviceOpened);
            _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(DeviceTextMacroSignal.MacroLooping);
            _stateChangedCnt = 0;

            // act
            _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(DeviceTextMacroSignal.MacroStopLooping);


            // assert
            Assert.AreEqual(DeviceTextMacroState.OpenedDevice, _deviceTextMacroStateMachine.DeviceTextMacroState);
            Assert.AreEqual(1, _stateChangedCnt);
        }

        [TestMethod]
        public void SendSignal_RecordingMacroAndDeviceNotOpened_NotOpenDevice()
        {
            // arrange
            _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(DeviceTextMacroSignal.DeviceOpened);
            _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(DeviceTextMacroSignal.MacroRecording);
            _stateChangedCnt = 0;

            // act
            _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(DeviceTextMacroSignal.DeviceNotOpened);


            // assert
            Assert.AreEqual(DeviceTextMacroState.NotOpenDevice, _deviceTextMacroStateMachine.DeviceTextMacroState);
            Assert.AreEqual(1, _stateChangedCnt);
        }


        [TestMethod]
        public void SendSignal_OpenedDeviceAndMacroRecording_RecordingMacro()
        {
            // arrange
            _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(DeviceTextMacroSignal.DeviceOpened);
            _stateChangedCnt = 0;

            // act
            _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(DeviceTextMacroSignal.MacroRecording);


            // assert
            Assert.AreEqual(DeviceTextMacroState.RecordingMacro, _deviceTextMacroStateMachine.DeviceTextMacroState);
            Assert.AreEqual(1, _stateChangedCnt);
        }

        [TestMethod]
        public void SendSignal_RecordingMacroAndMacroStopRecording_OpenedDevice()
        {
            // arrange
            _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(DeviceTextMacroSignal.DeviceOpened);
            _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(DeviceTextMacroSignal.MacroRecording);
            _stateChangedCnt = 0;

            // act
            _deviceTextMacroStateMachine.SendDeviceTextMacroSignal(DeviceTextMacroSignal.MacroStopRecording);


            // assert
            Assert.AreEqual(DeviceTextMacroState.OpenedDevice, _deviceTextMacroStateMachine.DeviceTextMacroState);
            Assert.AreEqual(1, _stateChangedCnt);
        }

    }
}
