using System;
using System.ComponentModel;
using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.Test.Devices;
using Ecs.Edpf.GUI.ComponentModel;
using Ecs.Edpf.GUI.Test.ComponentModel;
using Ecs.Edpf.GUI.UI.ViewModels;
using Ecs.Edpf.GUI.UI.ViewModels.Connections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Ecs.Edpf.GUI.UI.ViewModels.Connections
{
    [TestClass]
    public class BaseConnectionViewModelTest
    {
        private MockDeviceStateMachine _mockDeviceStateMachine = new MockDeviceStateMachine();
        
        private TestConnectionViewModel _testConnVwMdl;

        private FakeDeviceProvider _fakeDeviceProvider;

        private class TestConnectionViewModel : BaseConnectionViewModel
        {

            private IDeviceFactory _deviceFactory;

            public override System.Drawing.Image ViewImage => null;

            public override IDeviceConnectionSettingsViewModel DeviceConnectionSettingsViewModel => throw new NotImplementedException();

            public TestConnectionViewModel(IDeviceStateMachine deviceStateMachine, IDeviceFactory deviceFactory) : base(deviceStateMachine)
            {
                _deviceFactory = deviceFactory;
            }

            public override IDeviceFactory GetDeviceFactory()
            {
                return _deviceFactory;
            }

        }

        [TestInitialize]
        public void InitializeTest()
        {
            _fakeDeviceProvider = new FakeDeviceProvider();
            _testConnVwMdl = new TestConnectionViewModel(_mockDeviceStateMachine.Object, _fakeDeviceProvider)
            {
                DeviceProvider = _fakeDeviceProvider
            };
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




    }
}
