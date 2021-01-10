using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.IO.Cmds;
using Ecs.Edpf.Devices.IO.Params;
using HostApp.UI.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject.UI.ViewModels
{
    [TestClass]
    public class DeviceCommandViewModelTest
    {

        private Mock<IDevice> _mockDevice;

        private class FakeDeviceCommand : IDeviceCommand
        {
            public ReadOnlyCollection<IParameter> Parameters => new ReadOnlyCollection<IParameter>(new IParameter[] { });

            public string MethodName => nameof(MethodName);

            private bool _isValid;
            public bool IsValid => _isValid;

            public event PropertyChangedEventHandler PropertyChanged;

            public void SetIsValid(bool isValid)
            {
                _isValid = isValid;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(IsValid)));
                }
            }


            public List<string> GetCommandTextLines()
            {
                return new List<string> { };
            }
        }

        private int _devCmdViewMdlPropChanged = 0;
        private void DevCmdViewMdlPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _devCmdViewMdlPropChanged++;
        }

        [TestInitialize]
        public void InitializeTest()
        {
            _mockDevice = new Mock<IDevice>();
        }


        [TestMethod]
        public void IsValid_InvalidDeviceCommand_Invalid()
        {
            //-- arrange
            FakeDeviceCommand fakeDeviceCommand = new FakeDeviceCommand();
            DeviceCommandViewModel devCmdViewMdl = new DeviceCommandViewModel(_mockDevice.Object, fakeDeviceCommand);

            //-- act
            fakeDeviceCommand.SetIsValid(false);

            //-- assert
            Assert.AreEqual(expected: false, actual: devCmdViewMdl.IsValid);
        }


        [TestMethod]
        public void IsValid_DeviceCommandInvalidated_PropChangedTriggered()
        {
            //-- arrange
            _devCmdViewMdlPropChanged = 0;
            FakeDeviceCommand fakeDeviceCommand = new FakeDeviceCommand();
            fakeDeviceCommand.SetIsValid(true);

            DeviceCommandViewModel devCmdViewMdl = new DeviceCommandViewModel(_mockDevice.Object, fakeDeviceCommand);
            devCmdViewMdl.PropertyChanged += DevCmdViewMdlPropertyChanged;

            //-- act
            fakeDeviceCommand.SetIsValid(false);

            //-- assert
            Assert.AreEqual(expected: 1, actual: _devCmdViewMdlPropChanged);
        }


    }
}
