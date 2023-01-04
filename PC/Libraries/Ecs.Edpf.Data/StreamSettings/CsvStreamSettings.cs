using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.Data.StreamSettings
{
    public class CsvStreamSettings :DataStreamSettings
    {
        public override string TypeName => StreamSettingsConstants.CsvStreamSettingsTypeName;
    }
}
