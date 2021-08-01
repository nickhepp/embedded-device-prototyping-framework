using Ecs.Edpf.Devices.Devices;
using Ecs.Edpf.GUI.Test.ComponentModel;
using Ecs.Edpf.GUI.UI.ViewModels.Connections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.Test.UI.ViewModels.Connections
{
    [TestClass]
    public class ConnectionViewModelFactoryViewModelTest
    {

        private ConnectionViewModelFactoryViewModel _viewModel;
        private MockDeviceStateMachine _mockDeviceStateMachine;

        private Mock<ICompositeDeviceProvider> _mockCompositeDeviceProvider;

        private Mock<IConnectionViewModel> _mockConnViewMdl1;
        private Mock<IConnectionViewModel> _mockConnViewMdl2;
        private Mock<IConnectionViewModel> _mockConnViewMdl3;

        [TestInitialize]
        public void InitializeTest()
        {
            _mockDeviceStateMachine = new MockDeviceStateMachine();
            _mockCompositeDeviceProvider = new Mock<ICompositeDeviceProvider>();

            _mockConnViewMdl1 = new Mock<IConnectionViewModel>();
            _mockConnViewMdl2 = new Mock<IConnectionViewModel>();
            _mockConnViewMdl3 = new Mock<IConnectionViewModel>();

            _viewModel = new ConnectionViewModelFactoryViewModel(_mockDeviceStateMachine.Object, 
                _mockCompositeDeviceProvider.Object, 
                new [] { _mockConnViewMdl1.Object, _mockConnViewMdl2.Object, _mockConnViewMdl3.Object } );
        }

        [TestMethod]
        public void OnDeviceStateChanged_DeviceOpened_NonOpenedConnectionViewModelsDisabled()
        {
            //-- arrange
            bool? enabled1 = null;
            bool? enabled2 = null;
            bool? enabled3 = null;

            _mockConnViewMdl2.SetupGet(connViewMdl => connViewMdl.HasDevice).Returns(true);

            _mockConnViewMdl1.SetupSet(connViewMdl => connViewMdl.Enabled = false).Callback<bool>(value => enabled1 = value);
            _mockConnViewMdl2.SetupSet(connViewMdl => connViewMdl.Enabled = true).Callback<bool>(value => enabled2 = value);
            _mockConnViewMdl3.SetupSet(connViewMdl => connViewMdl.Enabled = false).Callback<bool>(value => enabled3 = value);

            //-- act
            _mockDeviceStateMachine.SetupGetDeviceStateRaiseChanged(GUI.ComponentModel.DeviceState.OpenedDevice);

            //-- assert
            Assert.IsTrue(enabled1.HasValue && (enabled1.Value == false), "Enabled should be set to false for 1.");
            Assert.IsTrue(enabled2.HasValue && (enabled2.Value == true), "Enabled should be set to true for 2.");
            Assert.IsTrue(enabled3.HasValue && (enabled3.Value == false), "Enabled should be set to false for 3.");
        }


        [TestMethod]
        public void OnDeviceStateChanged_NoDevice_AllConnectionViewModelsEnabled()
        {
            //-- arrange
            bool? enabled1 = null;
            bool? enabled2 = null;
            bool? enabled3 = null;

            _mockConnViewMdl1.SetupSet(connViewMdl => connViewMdl.Enabled = true).Callback<bool>(value => enabled1 = value);
            _mockConnViewMdl2.SetupSet(connViewMdl => connViewMdl.Enabled = true).Callback<bool>(value => enabled2 = value);
            _mockConnViewMdl3.SetupSet(connViewMdl => connViewMdl.Enabled = true).Callback<bool>(value => enabled3 = value);

            //-- act
            _mockDeviceStateMachine.SetupGetDeviceStateRaiseChanged(GUI.ComponentModel.DeviceState.NoDevice);

            //-- assert
            Assert.IsTrue(enabled1.HasValue && (enabled1.Value == true), "Enabled should be set to true for 1.");
            Assert.IsTrue(enabled2.HasValue && (enabled2.Value == true), "Enabled should be set to true for 2.");
            Assert.IsTrue(enabled3.HasValue && (enabled3.Value == true), "Enabled should be set to true for 3.");
        }




    }
}
