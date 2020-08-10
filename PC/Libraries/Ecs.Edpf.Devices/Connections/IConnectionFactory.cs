using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.Connections
{
    public interface IConnectionFactory
    {

        IConnection GetConnection();


    }
}
