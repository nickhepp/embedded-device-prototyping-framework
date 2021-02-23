using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.IO.File
{
    public interface IFile
    {
        bool Exists(string filePath);
        string ReadAllText(string filePath);
        void WriteAllText(string filePath, string text);
    }
}
