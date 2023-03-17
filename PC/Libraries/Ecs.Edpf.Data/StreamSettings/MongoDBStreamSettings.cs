using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Data.StreamSettings
{
    public class MongoDBStreamSettings : DataStreamSettings
    {
        public override string TypeName => StreamSettingsConstants.MongoDBSettingsTypeName;

    }
}
