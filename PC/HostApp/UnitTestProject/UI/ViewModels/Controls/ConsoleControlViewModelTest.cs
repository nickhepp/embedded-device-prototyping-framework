﻿using System;
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
        public void InputTextEnabled_DeviceNotOpen_CheckEnables()
        {
            //-- arrange
            _mockDevice.SetupIsOpen(false);
            ConsoleControlViewModel ccViewMdl = new ConsoleControlViewModel();

            //-- act
            ccViewMdl.Device = _mockDevice.Object;

            //-- assert
            Assert.IsFalse(ccViewMdl.InputTextEnabled);

        }
    }
}
