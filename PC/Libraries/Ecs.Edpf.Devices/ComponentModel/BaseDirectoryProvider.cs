using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.ComponentModel
{
    public static class BaseDirectoryProvider
    {

        public static string GetEdpfBaseDirectory()
        {
            return System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "EDPF");
        }


    }
}
