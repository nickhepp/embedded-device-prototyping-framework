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
        private FakeDeviceProvider _fakeDeviceProvider;
        private ConsoleViewModel _ccViewMdl;

        [TestInitialize]
        public void InitializeTest()
        {
            _fakeDeviceProvider = new FakeDeviceProvider();
            _mockDeviceStateMachine = new MockDeviceStateMachine();
            _ccViewMdl = new ConsoleViewModel(_mockDeviceStateMachine.Object)
            {
                DeviceProvider = _fakeDeviceProvider
            };
            _fakeDeviceProvider.InitDevice();
        }

        [TestMethod]
        public void InputTextEnabled_DeviceNotOpen_NotEnabled()
        {
            //-- arrange
            _mockDeviceStateMachine.SetupGetDeviceStateRaiseChanged(Ecs.Edpf.GUI.ComponentModel.DeviceState.OpenedDevice);

            //-- act
            _mockDeviceStateMachine.SetupGetDeviceStateRaiseChanged(Ecs.Edpf.GUI.ComponentModel.DeviceState.AssignedDevice);

            //-- assert
            Assert.IsFalse(_ccViewMdl.InputTextEnabled);
        }

        [TestMethod]
        public void InputTextEnabled_DeviceOpen_Enabled()
        {
            //-- arrange

            //-- act
            _mockDeviceStateMachine.SetupGetDeviceStateRaiseChanged(Ecs.Edpf.GUI.ComponentModel.DeviceState.OpenedDevice);

            //-- assert
            Assert.IsTrue(_ccViewMdl.InputTextEnabled);
        }

    }
}
