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

        /// <summary>
        /// The index of the parameter.
        /// </summary>
        int ParameterIndex { get; }

        /// <summary>
        /// The value of the parameter.
        /// </summary>
        T Value { get; set; }

        /// <summary>
        /// Format string to be applied to the input value before its sent to the device.
        /// </summary>
        string FormatString { get; }

        /// <summary>
        /// A status indicator for the parameter.
        /// </summary>
        bool IsValid { get; }


    }
}
