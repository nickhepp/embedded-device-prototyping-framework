using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.Logging
{
    public interface ILogger : IDisposable
    {

        void LogInformation(string messageTemplate);


    }
}
