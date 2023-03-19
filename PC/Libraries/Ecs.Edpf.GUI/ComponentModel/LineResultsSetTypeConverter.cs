using Ecs.Edpf.Data.DataStreams;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.ComponentModel
{
    public class LineResultsSetTypeConverter : TypeConverter
    {

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return (destinationType == typeof(string));
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {

            if (value is LineResultsSet set)
            {
                return "some stuff";
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

    }
}
