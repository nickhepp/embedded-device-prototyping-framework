namespace Ecs.Edpf.Devices.IO.File
{
    
    public interface IFileManager
    {

        bool FileExists(string path);

        IFile GetFile(string path);

        string ReadAllText(string path);

    }

}