namespace Ecs.Edpf.Devices.IO.File
{
    public interface IDirectoryManager
    {
        void CreateDirectory(string dirPath);
        bool DirectoryExists(string dirPath);
    }
}