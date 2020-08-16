using Ecs.Edpf.Devices.Connections;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices
{

    public interface IDeviceFactory
    {

        IConnectionInfo ConnectionInfo { get; }

        IDevice Device { get; }

        void CreateDevice();


        event EventHandler DeviceCreated;

    }

}
