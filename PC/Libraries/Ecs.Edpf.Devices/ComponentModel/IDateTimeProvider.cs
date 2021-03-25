using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.ComponentModel
{
    public interface IDateTimeProvider
    {
        DateTime GetCurrentDateTime();

    }
}
