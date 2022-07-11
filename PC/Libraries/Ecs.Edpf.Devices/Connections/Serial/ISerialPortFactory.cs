using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.Connections.Serial
{
    public interface ISerialPortFactory
    {

        List<string> GetSerialPortNames();

    }
}
