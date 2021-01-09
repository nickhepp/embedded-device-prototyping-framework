using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ecs.Edpf.Devices.IO.Params
{
    public interface IParameter : INotifyPropertyChanged
    {

        /// <summary>
        /// A human readable name for the parameter.
        /// </summary>
        string GetName();

        int GetParameterIndex();

        string GetValue();

        string GetFormatString();


        void SetValue(string val);


        /// <summary>
        /// Converts the parameter to text that will be sent to the device.
        /// </summary>
        /// <returns></returns>
        string GetParameterText();

        bool IsValid { get; }



    }
}
