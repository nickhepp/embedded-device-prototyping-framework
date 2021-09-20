using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.Extensions
{
    public static class StringExtensions
    {

        public const string Tab10 = "\t\t\t\t\t\t\t\t\t\t";
        public const string Tab9 = "\t\t\t\t\t\t\t\t\t";
        public const string Tab8 = "\t\t\t\t\t\t\t\t";
        public const string Tab7 = "\t\t\t\t\t\t\t";
        public const string Tab6 = "\t\t\t\t\t\t";
        public const string Tab5 = "\t\t\t\t\t";
        public const string Tab4 = "\t\t\t\t";
        public const string Tab3 = "\t\t\t";
        public const string Tab2 = "\t\t";
        public const string Tab1 = "\t";

        public static List<int> AllIndexesOf(string str, string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("the string to find may not be empty", "value");
            List<int> indexes = new List<int>();
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }

    }
}
