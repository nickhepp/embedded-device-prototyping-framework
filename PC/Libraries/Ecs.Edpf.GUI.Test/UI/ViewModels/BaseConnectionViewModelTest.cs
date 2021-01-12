using System;
using System.ComponentModel;
using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.Test.Devices;
using Ecs.Edpf.GUI.UI.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject.UI.ViewModels
{
    [TestClass]
    public class BaseConnectionViewModelTest
    {

        private MockDevice _mockDevice;
        private TestConnectionViewModel _testConnVwMdl;

        private class TestConnectionViewModel : BaseConnectionViewModel
        {

            private Mock<IDeviceFactory> _mockDeviceFactory = new Mock<IDeviceFactory>();

            public override System.Drawing.Image ViewImage => null;

            public override IDeviceConnectionSettingsViewModel DeviceConnectionSettingsViewModel => throw new NotImplementedException();

            protected override IDeviceFactory GetDeviceFactory()
            {
                return _mockDeviceFactory.Object;
            }

            protected override void InternalDevicePropertyChanged(object sender, PropertyChangedEventArgs e)
            {
            }

     
        }

        [TestInitialize]
        public void InitializeTest()
        {
            _mockDevice = new MockDevice();
            _testConnVwMdl = new TestConnectionViewModel();
        }


        [TestMethod]
        [DataRow(false, true, false)]
        [DataRow(true, false, true)]
        public void SetDevice_Closed_ButtonStatesAreCorrect(bool opening, bool openEnabled, bool closeEnabled)
        {
            //-- arrange
            if (opening)
                _mockDevice.Object.Open();
            else
                _mockDevice.Object.Close();

            //-- act
            _testConnVwMdl.Device = _mockDevice.Object;

            //-- assert
            Assert.AreEqual(expected: openEnabled, actual: _testConnVwMdl.OpenButtonEnabled);
            Assert.AreEqual(expected: openEnabled, actual: _testConnVwMdl.OpenCommand.CanExecute(null));

            Assert.AreEqual(expected: closeEnabled, actual: _testConnVwMdl.CloseButtonEnabled);
            Assert.AreEqual(expected: closeEnabled, actual: _testConnVwMdl.CloseCommand.CanExecute(null));
        }


        [TestMethod]
        public void OpenCommandExecute_Opened_ButtonStatesAreCorrect()
        {
            //-- arrange
            _mockDevice.Object.Close();

            _testConnVwMdl.Device = _mockDevice.Object;

            //-- act
            _testConnVwMdl.OpenCommand.Execute(null);

            //-- assert
            Assert.IsTrue(_testConnVwMdl.CloseButtonEnabled);
            Assert.IsTrue(_testConnVwMdl.CloseCommand.CanExecute(null));

            Assert.IsFalse(_testConnVwMdl.OpenButtonEnabled);
            Assert.IsFalse(_testConnVwMdl.OpenCommand.CanExecute(null));
        }

    }
}
