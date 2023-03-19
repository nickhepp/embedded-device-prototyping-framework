using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Ecs.Edpf.Data.DataStreams
{

    /// <summary>
    /// Describes a value that will be part of a line returned from an EDPF device.
    /// </summary>
    public class LineValueDescription
    {

        public string ValueName { get; set; }

        public DataStreamValueType ValueType { get; set; }

        public override string ToString()
        {
            return $"{ValueName}:{ValueType}";
        }

        private static Regex _validName = new Regex(@"[A-Za-z]+");

        public bool GetIsValid()
        {
            bool isMatch = !string.IsNullOrEmpty(ValueName);
            if (isMatch)
            {
                Match match = _validName.Match(ValueName);
                isMatch = (match.Success && (match.Length == ValueName.Length));
            }
            return isMatch;
        }
    }
}
