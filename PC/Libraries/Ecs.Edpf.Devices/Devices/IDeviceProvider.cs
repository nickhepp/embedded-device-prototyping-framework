using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices
{
    public interface IDeviceProvider
    {

        IDevice Device { get; }

        event EventHandler DeviceCreated;



    }
}
