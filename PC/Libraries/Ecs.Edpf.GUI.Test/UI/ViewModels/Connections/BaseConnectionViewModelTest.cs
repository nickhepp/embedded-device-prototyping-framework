using System;
using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.ComponentModel;
using Ecs.Edpf.Devices.Test.ComponentModel;
using Ecs.Edpf.Devices.Test.Devices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ecs.Edpf.GUI.UI.ViewModels.Connections
{
    [TestClass]
    public class BaseConnectionViewModelTest
    {
        private MockDeviceStateMachine _mockDeviceStateMachine = new MockDeviceStateMachine();
        
        private TestConnectionViewModel _testConnVwMdl;

        private class TestConnectionViewModel : BaseConnectionViewModel
        {

            private FakeDeviceProvider _fakeDeviceProvider;
            public FakeDeviceProvider FakeDeviceProvider => _fakeDeviceProvider;   

            public override System.Drawing.Image ViewImage => null;

            public override IDeviceConnectionSettingsViewModel DeviceConnectionSettingsViewModel => throw new NotImplementedException();

            public TestConnectionViewModel(IDeviceStateMachine deviceStateMachine) : base(deviceStateMachine)
            {
            }

            public override IDeviceFactory GetDeviceFactory()
            {
                _fakeDeviceProvider = new FakeDeviceProvider();
                return _fakeDeviceProvider;
            }

        }

        [TestInitialize]
        public void InitializeTest()
        {
            _testConnVwMdl = new TestConnectionViewModel(_mockDeviceStateMachine.Object);
            //_testConnVwMdl.DeviceProvider = _testConnVwMdl.FakeDeviceProvider;
        }
   

        [TestMethod]
        public void OnDeviceStateChanged_Opened_ButtonStatesAreCorrect()
        {
            //-- arrange

            //-- act
            _mockDeviceStateMachine.SetupGetDeviceStateRaiseChanged(DeviceState.OpenedDevice);

            //-- assert
            Assert.IsTrue(_testConnVwMdl.CloseButtonEnabled);
            Assert.IsTrue(_testConnVwMdl.CloseCommand.CanExecute(null));

            Assert.IsFalse(_testConnVwMdl.OpenButtonEnabled);
            Assert.IsFalse(_testConnVwMdl.OpenCommand.CanExecute(null));
        }

        [TestMethod]
        public void OnDeviceStateChanged_Closed_ButtonStatesAreCorrect()
        {
            //-- arrange

            //-- act
            _mockDeviceStateMachine.SetupGetDeviceStateRaiseChanged(DeviceState.AssignedDevice);

            //-- assert
            Assert.IsFalse(_testConnVwMdl.CloseButtonEnabled);
            Assert.IsFalse(_testConnVwMdl.CloseCommand.CanExecute(null));

            Assert.IsTrue(_testConnVwMdl.OpenButtonEnabled);
            Assert.IsTrue(_testConnVwMdl.OpenCommand.CanExecute(null));
        }


        [TestMethod]
        public void OpenCommandExecuted_DeviceOpenFails_ErrorMessageReflected()
        {
            // arrange
            string openExceptionMessage = "This exception was thrown during device opening.";

            _mockDeviceStateMachine.SetupGetDeviceStateRaiseChanged(DeviceState.AssignedDevice);

            MockDevice mockDevice = new MockDevice(useDefaultSetupOpen: false);
            mockDevice.Setup(device => device.Open()).Throws(new Exception(openExceptionMessage));
            _testConnVwMdl.FakeDeviceProvider.InitDevice(mockDevice);

            // act
            _testConnVwMdl.OpenCommand.Execute(null);

            // assert
            Assert.AreEqual(expected: openExceptionMessage, actual: _testConnVwMdl.OpenFailedErrorMessage);
        }

    }
}
