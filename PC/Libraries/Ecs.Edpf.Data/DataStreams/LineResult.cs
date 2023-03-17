using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Data.DataStreams
{
    public class LineResult
    {

        public string ValueName { get; set; }

        public double Value { get; set; }

        public DataStreamValueType ValueType { get; set; }

    }
}
