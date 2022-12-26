using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.Data.StreamSettings
{
    public abstract class StreamSettings
    {

        public string Name { get; set; }

        public abstract string TypeName { get; }

    }
}
