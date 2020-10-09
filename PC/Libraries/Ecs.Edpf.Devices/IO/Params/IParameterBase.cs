using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.IO.Params
{
    public interface IParameterBase<T>
    {

        /// <summary>
        /// A human readable name for the parameter.
        /// </summary>
        string Name { get; }

        int ParameterIndex { get; }

        T Value { get; set; }

        string FormatString { get; }

    }
}
