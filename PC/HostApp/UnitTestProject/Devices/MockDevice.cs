using HostApp.Business;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Devices
{
    public class MockDevice : Mock<IDevice>
    {

        public MockDevice()
        {
            SetupIsOpen(false);
        }

        public void SetupIsOpen(bool isOpen)
        {
            this.SetupGet(device => device.IsOpen).Returns(isOpen);
        }


    }
}
