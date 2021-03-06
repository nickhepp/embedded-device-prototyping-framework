using Ecs.Edpf.GUI.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Ecs.Edpf.GUI.Test.ComponentModel
{
    [TestClass]
    public class DeviceStateMachineTest
    {

        private int _devStateChangedCount;
        private DeviceStateMachine _devStateMachine;

        [TestInitialize]
        public void InitializeTest()
        {
            _devStateMachine = new DeviceStateMachine();

            _devStateMachine.DeviceStateChanged += DevStateMachineDeviceStateChanged;
            _devStateChangedCount = 0;
        }

        private void DevStateMachineDeviceStateChanged(object sender, EventArgs e)
        {
            _devStateChangedCount++;
        }

        [TestMethod]
        public void SendSignal_NoDeviceAndDeviceAssigned_AssignedDevice()
        {
            // arrange

            // act
            _devStateMachine.SendSignal(DeviceSignal.DeviceAssigned);

            // assert
            Assert.AreEqual(DeviceState.AssignedDevice, _devStateMachine.DeviceState);
            Assert.AreEqual(1, _devStateChangedCount);
        }

        [TestMethod]
        public void SendSignal_AssignedDeviceAndDeviceCleared_NoDevice()
        {
            // arrange
            _devStateMachine.SendSignal(DeviceSignal.DeviceAssigned);
            _devStateChangedCount = 0;

            // act
            _devStateMachine.SendSignal(DeviceSignal.DeviceCleared);

            // assert
            Assert.AreEqual(DeviceState.NoDevice, _devStateMachine.DeviceState);
            Assert.AreEqual(1, _devStateChangedCount);
        }

        [TestMethod]
        public void SendSignal_AssignedDeviceAndDeviceOpened_OpenedDevice()
        {
            // arrange
            _devStateMachine.SendSignal(DeviceSignal.DeviceAssigned);
            _devStateChangedCount = 0;

            // act
            _devStateMachine.SendSignal(DeviceSignal.DeviceOpened);

            // assert
            Assert.AreEqual(DeviceState.OpenedDevice, _devStateMachine.DeviceState);
            Assert.AreEqual(1, _devStateChangedCount);
        }

        [TestMethod]
        public void SendSignal_OpenedDeviceAndDeviceClosed_AssignedDevice()
        {
            // arrange
            _devStateMachine.SendSignal(DeviceSignal.DeviceAssigned);
            _devStateMachine.SendSignal(DeviceSignal.DeviceOpened);
            _devStateChangedCount = 0;

            // act
            _devStateMachine.SendSignal(DeviceSignal.DeviceClosed);

            // assert
            Assert.AreEqual(DeviceState.AssignedDevice, _devStateMachine.DeviceState);
            Assert.AreEqual(1, _devStateChangedCount);
        }

        [TestMethod]
        public void SendSignal_OpenedDeviceAndDeviceCleared_NoDevice()
        {
            // arrange
            _devStateMachine.SendSignal(DeviceSignal.DeviceAssigned);
            _devStateMachine.SendSignal(DeviceSignal.DeviceOpened);
            _devStateChangedCount = 0;

            // act
            _devStateMachine.SendSignal(DeviceSignal.DeviceCleared);

            // assert
            Assert.AreEqual(DeviceState.NoDevice, _devStateMachine.DeviceState);
            Assert.AreEqual(1, _devStateChangedCount);
        }

 

    }
}
