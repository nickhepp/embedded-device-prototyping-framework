using Ecs.Edpf.Devices.IO.Params;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Ecs.Edpf.Devices.IO.Cmds
{
    public interface IDeviceCommand
    {

        ReadOnlyCollection<IParameter> Parameters { get; }

        string MethodName { get; }

        List<string> GetCommandTextLines();

    }
}
