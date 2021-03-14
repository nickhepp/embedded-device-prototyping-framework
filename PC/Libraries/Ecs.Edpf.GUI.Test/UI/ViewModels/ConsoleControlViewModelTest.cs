using System;
using Ecs.Edpf.Devices.Test.Devices;
using Ecs.Edpf.GUI.Test.ComponentModel;
using Ecs.Edpf.GUI.UI.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject.UI.ViewModels.Controls
{
    [TestClass]
    public class ConsoleControlViewModelTest
    {
        private MockDeviceStateMachine _mockDeviceStateMachine;
        private MockDevice _mockDevice;


        [TestInitialize]
        public void InitializeTest()
        {
            _mockDevice = new MockDevice();
            _mockDeviceStateMachine = new MockDeviceStateMachine();
        }

        [TestMethod]
        public void InputTextEnabled_DeviceNotOpen_NotEnabled()
        {
            //-- arrange
            
            _mockDevice.Object.Close();
            ConsoleViewModel ccViewMdl = new ConsoleViewModel(_mockDeviceStateMachine.Object);

            //-- act
            ccViewMdl.Device = _mockDevice.Object;

            //-- assert
            Assert.IsFalse(ccViewMdl.InputTextEnabled);
        }

        [TestMethod]
        public void InputTextEnabled_DeviceOpen_Enabled()
        {
            //-- arrange
            _mockDevice.Object.Open();
            ConsoleViewModel ccViewMdl = new ConsoleViewModel(_mockDeviceStateMachine.Object);

            //-- act
            ccViewMdl.Device = _mockDevice.Object;

            //-- assert
            Assert.IsTrue(ccViewMdl.InputTextEnabled);
        }




    }
}
