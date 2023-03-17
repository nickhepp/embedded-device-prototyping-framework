using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.Data.StreamSettings
{
    public class SqlServerStreamSettings : DataStreamSettings
    {
        public override string TypeName => StreamSettingsConstants.SqlServerStreamSettingsTypeName;

        public string SchemaName { get; set; }

        public string TableName { get; set; }

    }
}
