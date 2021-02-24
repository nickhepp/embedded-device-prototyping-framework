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



        [TestMethod]
        public void OneShotCommandCanExecute_MacroTextAndDevice_True()
        {
            //-- arrange


            _deviceTextMacroVwMdl.Device = _mockDevice.Object;


            //-- act


            //-- assert
            Assert.IsTrue()

}


        public void OneShotCommandCanExecute_NoMacroTextAndNoDevice_False()
        {


        }
    }
}
