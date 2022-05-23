using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.Logging
{
    public interface ILogger : IDisposable
    {

        void LogInformation(string messageTemplate);

        void LogWarning(string messageTemplate);

        void LogException(Exception ex);

        void LogException(string messageTemplate, Exception ex);
    }
}
