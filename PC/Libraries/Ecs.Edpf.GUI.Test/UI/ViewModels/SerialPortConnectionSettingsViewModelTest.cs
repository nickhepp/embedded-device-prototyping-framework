using Ecs.Edpf.Connections.Serial;
using Ecs.Edpf.Devices.Connections.Serial;
using Ecs.Edpf.GUI.UI.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.Test.UI.ViewModels
{


    [TestClass]
    public class SerialPortConnectionSettingsViewModelTest
    {

        private const string DefaultConnName = "DefaultConn";
        private const string Conn1Name = "Conn1";
        private const string Conn2Name = "Conn2";

        private SerialPortConnectionSettingsViewModel _serialPortConnSttngsVwMdl;

        private SerialPortConnectionInfo _serialPortConnectionInfo;

        private Mock<ISerialPortFactory> _mockSerialPortFactory;


        [TestInitialize]
        public void InitializeTest()
        {

        }


        private void SetupDefaultInfo()
        {
            _serialPortConnectionInfo = new SerialPortConnectionInfo()
            {
                DevicePort = DefaultConnName,
            };
            _mockSerialPortFactory = new Mock<ISerialPortFactory>();
            _mockSerialPortFactory.Setup(serialPortFactory => serialPortFactory.GetSerialPortNames()).Returns(
                () => new List<string> { DefaultConnName, Conn1Name, Conn2Name });

            _serialPortConnSttngsVwMdl = new SerialPortConnectionSettingsViewModel(
                _serialPortConnectionInfo, _mockSerialPortFactory.Object);
        }


        [TestMethod]
        public void ExcludedComPorts_ExcludeDefaultConnName_ComPortNull()
        {
            // arrange
            SetupDefaultInfo();

            // act
            // exclude the default
            _serialPortConnSttngsVwMdl.ExcludedComPorts = new List<string> { DefaultConnName };

            // assert
            // should be null
            Assert.IsNull(_serialPortConnSttngsVwMdl.ComPort, "The excluded default setting should not be allowed.");
        }

        [TestMethod]
        public void ExcludedComPorts_SetToEmptyList_ComPortIsDefault()
        {
            // arrange
            SetupDefaultInfo();

            // act
            // exclude the default
            _serialPortConnSttngsVwMdl.ExcludedComPorts = new List<string>();

            // assert
            // should be null
            Assert.AreEqual(expected: DefaultConnName, _serialPortConnSttngsVwMdl.ComPort, 
                "The default setting should be the setting ComPort.");
        }

        [TestMethod]
        public void ComPort_SetToExcludedListValue_ComPortIsNull()
        {
            // arrange
            SetupDefaultInfo();
            _serialPortConnSttngsVwMdl.ExcludedComPorts = new List<string> { Conn1Name, Conn2Name };

            // act
            // exclude the default
            _serialPortConnSttngsVwMdl.ComPort = Conn2Name;

            // assert
            // should be null
            Assert.IsNull(_serialPortConnSttngsVwMdl.ComPort,
                "When ComPort is set to an excluded value the result should be null.");
        }


        [TestMethod]
        public void ComPort_SetToNonExcludedListValue_ComPortAsSet()
        {
            // arrange
            SetupDefaultInfo();
            _serialPortConnSttngsVwMdl.ExcludedComPorts = new List<string> { Conn1Name };

            // act
            // exclude the default
            _serialPortConnSttngsVwMdl.ComPort = Conn2Name;

            // assert
            // should be null
            Assert.AreEqual(expected: Conn2Name, actual: _serialPortConnSttngsVwMdl.ComPort,
                "When ComPort is set to a non-excluded value the result should be the same that it was set to.");
        }



    }
}
