using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ecs.Edpf.Devices.IO.File
{
    public class DirectoryManager : IDirectoryManager
    {

        public void CreateDirectory(string dirPath)
        {
            Directory.CreateDirectory(dirPath);
        }


        public bool DirectoryExists(string dirPath)
        {
            return Directory.Exists(dirPath);
        }


    }
}
