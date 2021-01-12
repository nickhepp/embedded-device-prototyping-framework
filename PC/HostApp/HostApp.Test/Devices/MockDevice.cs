using Ecs.Edpf.Devices;
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
            Setup(device => device.Open()).Returns(() => true).Callback(() =>
                {
                    SetupGet(device => device.IsOpen).Returns(true);
                }
            );
            Setup(device => device.Close()).Callback(() => 
                {
                    SetupGet(device => device.IsOpen).Returns(false);
                }
            );
        }

    }
}
