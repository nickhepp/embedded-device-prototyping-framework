using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.Test.Devices;
using Ecs.Edpf.GUI.ComponentModel;
using Ecs.Edpf.GUI.Test.ComponentModel;
using Ecs.Edpf.GUI.UI.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.Test.UI.ViewModels
{

    [TestClass]
    public class BaseDeviceViewModelTest
    {


        public class TestBaseDeviceViewModel : BaseDeviceViewModel
        {


            public TestBaseDeviceViewModel(IDeviceStateMachine deviceStateMachine): base(deviceStateMachine)
            {

            }
        }


        private TestBaseDeviceViewModel _testBaseDeviceViewModel;
        private MockDeviceStateMachine _mockDeviceStateMachine;
        private FakeDeviceProvider _fakeDeviceProvider;



        [TestInitialize]
        public void InitializeTest()
        {
            _fakeDeviceProvider = new FakeDeviceProvider();

            _mockDeviceStateMachine = new MockDeviceStateMachine();
            _testBaseDeviceViewModel = new TestBaseDeviceViewModel(_mockDeviceStateMachine.Object)
            {
                DeviceProvider = _fakeDeviceProvider
            };
        }


        [TestMethod]
        public void DeviceClose_DeviceClosed_DeviceReferenceIsNull()
        {

            _fakeDeviceProvider.CreateDevice();
            Assert.IsNotNull(_fakeDeviceProvider.Device, "When the device is created it should be assigned to this viewmodel.");

            _fakeDeviceProvider.Device.Close();
            Assert.IsNull(_testBaseDeviceViewModel.Device, $"When the device is closed {nameof(BaseDeviceViewModel.Device)} should be null."); 
        }




    }
}
