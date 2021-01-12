
namespace HostApp
{
    /// <summary>
    /// Class acts as a poor man's implementation of dependency injection.
    /// </summary>
    public static class AppInfo
    {

        public const string DeviceConnectionCategory = "Device Connection";

        public const string ViewModelCommandSuffix = "ViewModelCommand";

        public static string ViewModelTypeName { get; set; }

        public static string DeviceTypeName { get; set; }



    }
}
