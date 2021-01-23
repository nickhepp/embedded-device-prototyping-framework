using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.Devices
{
    public interface IGlobalDeviceProvider
    {

        IDeviceProvider GlobalDeviceProvider { get; }

    }
}
