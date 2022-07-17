using Ecs.Edpf.Devices;
using Moq;
using Moq.Language.Flow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.Devices.Test.Devices
{
    public class MockDevice : Mock<IDevice>
    {

        public MockDevice(bool useDefaultSetupOpen = true)
        {
            if (useDefaultSetupOpen)
            {
                Setup(device => device.Open()).Returns(() => true).Callback(() =>
                {
                    SetupGet(device => device.IsOpen).Returns(true);
                    Raise(device => device.DeviceOpened += null, new EventArgs());
                }
                );
            }
            Setup(device => device.Close()).Callback(() => 
                {
                    SetupGet(device => device.IsOpen).Returns(false);
                    Raise(device => device.DeviceClosed += null, new EventArgs());
                }
            );
            SetupGet(device => device.DeviceInputBuffer).Returns(new System.ComponentModel.BindingList<string>());

        }

    }
}
