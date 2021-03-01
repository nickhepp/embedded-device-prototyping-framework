using System;
using Ecs.Edpf.Devices.Test.Devices;
using Ecs.Edpf.GUI.UI.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Ecs.Edpf.GUI.Test.UI.ViewModels
{
    [TestClass]
    public class DeviceTextMacroViewModelTest
    {

        private DeviceTextMacroViewModel _deviceTextMacroVwMdl;

        private MockDevice _mockDevice;

        [TestInitialize]
        public void InitializeTest()
        {
            _deviceTextMacroVwMdl = new DeviceTextMacroViewModel();
            _mockDevice = new MockDevice();
        }

        private void SetupEnabledDeviceTextMacro()
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
            _deviceTextMacroVwMdl.Device = _mockDevice.Object;

        }

        [TestMethod]
        public void OneShotCommandCanExecute_MacroTextAndDevice_True()
        {
            //-- arrange
            SetupEnabledDeviceTextMacro();

            //-- act

            //-- assert
            Assert.IsTrue(_deviceTextMacroVwMdl.OneShotCommand.CanExecute(null), "OneShotCommand should be enabled.");
        }

        [TestMethod]
        public void OneShotCommandCanExecute_NoDevice_False()
        {
            //-- arrange
            SetupEnabledDeviceTextMacro();

            //-- act
            _deviceTextMacroVwMdl.Device = null;

            //-- assert
            Assert.IsFalse(_deviceTextMacroVwMdl.OneShotCommand.CanExecute(null), "OneShotCommand should not be enabled.");
        }

        [TestMethod]
        public void OneShotCommandCanExecute_NoMacroText_False()
        {
            //-- arrange
            SetupEnabledDeviceTextMacro();

            //-- act
            _deviceTextMacroVwMdl.DeviceTextMacro = new Devices.IO.Macros.DeviceTextMacro();

            //-- assert
            Assert.IsFalse(_deviceTextMacroVwMdl.OneShotCommand.CanExecute(null), "OneShotCommand should not be enabled.");
        }




    }
}
