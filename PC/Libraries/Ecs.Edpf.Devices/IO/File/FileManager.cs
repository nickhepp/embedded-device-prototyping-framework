using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.IO.File
{
    public class FileManager : IFileManager
    {

        public bool FileExists(string path)
        {
            return System.IO.File.Exists(path);
        }


        public IFile GetFile(string path)
        {
            return new EdpfFile();
        }

        public string ReadAllText(string path)
        {
            return System.IO.File.ReadAllText(path);
        }

    }
}
