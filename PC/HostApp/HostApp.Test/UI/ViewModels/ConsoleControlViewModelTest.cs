using System;
using HostApp.UI.ViewModels.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTestProject.Devices;

namespace UnitTestProject.UI.ViewModels.Controls
{
    [TestClass]
    public class ConsoleControlViewModelTest
    {

        private MockDevice _mockDevice;


        [TestInitialize]
        public void InitializeTest()
        {
            _mockDevice = new MockDevice();
        }

        [TestMethod]
        public void InputTextEnabled_DeviceNotOpen_NotEnabled()
        {
            //-- arrange
            _mockDevice.Object.Close();
            ConsoleControlViewModel ccViewMdl = new ConsoleControlViewModel();

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
            ConsoleControlViewModel ccViewMdl = new ConsoleControlViewModel();

            //-- act
            ccViewMdl.Device = _mockDevice.Object;

            //-- assert
            Assert.IsTrue(ccViewMdl.InputTextEnabled);
        }




    }
}
