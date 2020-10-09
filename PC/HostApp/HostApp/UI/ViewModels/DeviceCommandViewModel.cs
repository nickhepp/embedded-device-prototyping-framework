﻿using Ecs.Edpf.Devices.IO.Cmds;
using Ecs.Edpf.Devices.IO.Params;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.UI.ViewModels
{

    /// <summary>
    /// This view model represents one device command (command name with optional arguments) that can be sent to the device.
    /// </summary>
    public class DeviceCommandViewModel : BaseViewModel, IDeviceCommandViewModel
    {

        private IDeviceCommand _deviceCommand;

        private PropertyDescriptorCollection _pdColl;

        public string MethodName { get; }

        public DeviceCommandViewModel(IDeviceCommand deviceCommand)
        {
            _deviceCommand = deviceCommand;

            MethodName = deviceCommand.MethodName;

            List<PropertyDescriptor> pdDescs = new List<PropertyDescriptor>();

            // add the method name
            pdDescs.Add(new CommandMethodNamePropertyDescriptor(_deviceCommand.MethodName));

            // add the parameters
            List<IParameter> parameters = _deviceCommand.Parameters.ToList();
            parameters.Sort((paramX, paramY) => paramX.GetParameterIndex().CompareTo(paramY.GetParameterIndex()));

            foreach (IParameter parameter in parameters)
            {
                pdDescs.Add(new CommandParameterPropertyDescriptor(parameter));
            }

            _pdColl = new PropertyDescriptorCollection(pdDescs.ToArray());
        }

        public override PropertyDescriptorCollection GetProperties()
        {
            return _pdColl;
        }



        internal class CommandMethodNamePropertyDescriptor : PropertyDescriptor
        {
            public override Type ComponentType => typeof(string);

            public override bool IsReadOnly => true;

            public override Type PropertyType => typeof(string);

            private static Attribute[] GetAttributes()
            {
                Attribute[] atts = new Attribute[] { new CategoryAttribute("Command"),
                    new DescriptionAttribute("The name of the command that the host app passes to the device."),
                    new DisplayNameAttribute("Method Name")};
                return atts;
            }

            private string _methodName;

            public CommandMethodNamePropertyDescriptor(string methodName) : base(name:"MethodName", GetAttributes())
            {
                _methodName = methodName;
            }


            public override bool CanResetValue(object component)
            {
                return false;
            }

            public override object GetValue(object component)
            {
                return _methodName;
            }

            public override void ResetValue(object component)
            {
            }

            public override void SetValue(object component, object value)
            {
            }

            public override bool ShouldSerializeValue(object component)
            {
                return false;
            }
        }


        internal class CommandParameterPropertyDescriptor : PropertyDescriptor
        {

            private IParameter _parameter;

            public override Type ComponentType => _parameter.GetType();

            public override bool IsReadOnly => false;

            public override Type PropertyType => typeof(string);


            private static Attribute[] GetAttributes(IParameter parameter)
            {
                Attribute[] atts = new Attribute[] { new CategoryAttribute("Parameters"),
                    new DescriptionAttribute("The name of the command that the host app passes to the device."),
                    new DisplayNameAttribute($"{parameter.GetName()}[{parameter.GetParameterIndex()}]")};

                return atts;
            }

            public CommandParameterPropertyDescriptor(IParameter parameter) : base(name: parameter.GetName(), GetAttributes(parameter))
            {
                _parameter = parameter;
            }


            public override bool CanResetValue(object component)
            {
                return false;
            }

            public override object GetValue(object component)
            {
                return _parameter.GetValue();
            }

            public override void ResetValue(object component)
            {
            }

            public override void SetValue(object component, object value)
            {
                string val = value as string;
                _parameter.SetValue(val);
            }

            public override bool ShouldSerializeValue(object component)
            {
                return false;
            }


        }



    }
}
