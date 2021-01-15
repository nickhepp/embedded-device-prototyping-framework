using Ecs.Edpf.Devices.IO.Params;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Ecs.Edpf.Devices.IO.Cmds
{
    public abstract class BaseDeviceCommand : IDeviceCommand
    {

        public virtual bool IsValid => Parameters.All(param => param.IsValid);

        public ReadOnlyCollection<IParameter> Parameters { get; }

        public abstract string MethodName { get; }


        public BaseDeviceCommand()
        {
            Parameters = new ReadOnlyCollection<IParameter>(new List<IParameter>());
        }

        public BaseDeviceCommand(ReadOnlyCollection<IParameter> parameters)
        {
            Parameters = parameters;

            foreach (IParameter parameter in parameters)
            {
                parameter.PropertyChanged += ParameterPropertyChanged;
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void ParameterPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if ((e.PropertyName == nameof(IParameter.IsValid)) && (PropertyChanged != null))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(IsValid)));
            }
        }


        public List<string> GetCommandTextLines()
        {
            // the parameters (0 to n-1)
            List<string> textLines = Parameters.Select(param => param.GetParameterText()).ToList();
            textLines.Add($"cmd:{MethodName}()");

            return textLines;
        }

    }
}
