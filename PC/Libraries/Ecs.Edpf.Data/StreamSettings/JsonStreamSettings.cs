﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.Data.StreamSettings
{
    public class JsonStreamSettings : BaseFileStreamSettings
    {
        public override string TypeName => StreamSettingsConstants.JsonStreamSettingsTypeName;
    }
}
