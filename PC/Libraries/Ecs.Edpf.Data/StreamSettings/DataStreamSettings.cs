using Ecs.Edpf.Data.DataStreams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.Data.StreamSettings
{
    public abstract class DataStreamSettings
    {
        /// <summary>
        /// The name of the stream.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type of the string.  This is used for serialization.
        /// </summary>
        public abstract string TypeName { get; }

        /// <summary>
        /// The expression of the stream's filter.
        /// </summary>
        public string Expression { get; set; }

        /// <summary>
        /// The values that come across in one line.
        /// </summary>
        public LineResultsSet Values { get; set; } = new LineResultsSet();


    }
}
