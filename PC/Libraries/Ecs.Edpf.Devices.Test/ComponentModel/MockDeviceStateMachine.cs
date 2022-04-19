using Ecs.Edpf.Devices.ComponentModel;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.Devices.Test.ComponentModel
{
    public class MockDeviceStateMachine : Mock<IDeviceStateMachine>
    {

        public MockDeviceStateMachine()
        {
            this.SetupGet(devStateMachine => devStateMachine.DeviceState).Returns(DeviceState.NoDevice);
        }

        public void SetupGetDeviceState(DeviceState state)
        {
            this.SetupGet(devStateMachine => devStateMachine.DeviceState).Returns(state);
        }


        public void RaiseDeviceStateChanged()
        {
            this.Raise(devStateMachine => devStateMachine.DeviceStateChanged += null, new EventArgs());
        }

        public void SetupGetDeviceStateRaiseChanged(DeviceState state)
        {
            SetupGetDeviceState(state);
            RaiseDeviceStateChanged();
        }

    }
}
