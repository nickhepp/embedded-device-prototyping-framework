using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Data.StreamSettings
{
    public abstract class BaseFileStreamSettings : DataStreamSettings
    {

        public string DirectoryPath { get; set; }

    }
}
