using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.IO.File
{
    public class EdpfFile : IFile
    {

        public EdpfFile()
        {

        }

        public bool Exists(string filePath)
        {
            return System.IO.File.Exists(filePath);
        }

        public string ReadAllText(string settingsPath)
        {
            return System.IO.File.ReadAllText(settingsPath);
        }

        public void WriteAllText(string filePath, string text)
        {
            System.IO.File.WriteAllText(filePath, text);
        }

    }
}
