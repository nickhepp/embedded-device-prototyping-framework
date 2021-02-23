using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.IO.File
{
    public class FileFactory
    {

        public IFile GetFile()
        {
            return new EdpfFile();
        }


    }
}
