using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.Connections
{
    public class StringCollectionTypeConverter : TypeConverter
    {
        public const string StringItemSeparator = ",";


        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string str && !string.IsNullOrEmpty(str))
            {
                List<string> items = str.Split(new string[] { StringItemSeparator }, StringSplitOptions.RemoveEmptyEntries).Select(item => item.Trim()).ToList();
                return items;
            }
            else
            {
                return new List<string>();
            }
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            object retObj;
            if (value is IEnumerable<string> strColl)
            {
                if (strColl.Any())
                {
                    retObj = string.Join(", ", strColl);
                }
                else
                {
                    retObj = "[None]";
                }
            }
            else
            {
                retObj = base.ConvertTo(context, culture, value, destinationType);
            }

            return retObj;
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return base.CanConvertTo(context, destinationType);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

    }
}
