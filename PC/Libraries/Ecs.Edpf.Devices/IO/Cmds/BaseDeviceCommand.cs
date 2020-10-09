using Ecs.Edpf.Devices.IO.Params;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Ecs.Edpf.Devices.IO.Cmds
{
    public abstract class BaseDeviceCommand : IDeviceCommand
    {

        public abstract ReadOnlyCollection<IParameter> Parameters { get; }

        public abstract string MethodName { get; }

        public List<string> GetCommandTextLines()
        {
            // the parameters (0 to n-1)
            List<string> textLines = Parameters.Select(param => param.GetParameterText()).ToList();
            textLines.Add($"cmd:{MethodName}()");

            return textLines;
        }

    }
}
