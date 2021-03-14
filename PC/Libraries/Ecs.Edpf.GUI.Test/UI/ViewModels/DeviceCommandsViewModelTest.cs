﻿using System;
using Ecs.Edpf.GUI.Test.ComponentModel;
using Ecs.Edpf.GUI.UI.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject.UI.ViewModels
{
    [TestClass]
    public class DeviceCommandsViewModelTest
    {
        private MockDeviceStateMachine _mockDeviceStateMachine;
        private Mock<IDeviceCommandViewModel> _mockDeviceCmdVwMdl;

        [TestInitialize]
        public void InitializeTest()
        {
            _mockDeviceCmdVwMdl = new Mock<IDeviceCommandViewModel>();
            _mockDeviceStateMachine = new MockDeviceStateMachine();
        }

        [TestMethod]
        [DataRow(false, "should have been false")]
        [DataRow(true, "should have been true")]
        public void SelectedCommandExecuteButtonEnabled_InvalidSelectedCommand_Disabled(bool val, string message)
        {
            //-- arrange
            DeviceCommandsViewModel devCmdsViewMdl = new DeviceCommandsViewModel(_mockDeviceStateMachine.Object);
            _mockDeviceCmdVwMdl.SetupGet(devCmdVwMdl => devCmdVwMdl.IsValid).Returns(val);

            //-- act
            devCmdsViewMdl.SelectedDeviceCommandViewModel = _mockDeviceCmdVwMdl.Object;

            //-- assert
            Assert.AreEqual(expected: val, actual: devCmdsViewMdl.SelectedCommandExecuteButtonEnabled, message);
        }



    }
}
