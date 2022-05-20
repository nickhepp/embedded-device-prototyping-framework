namespace Ecs.Edpf.Devices.Logging
{
    public interface ILogLifeCycleManager
    {

        IDeviceProvider DeviceProvider { get; set; }

        void ChangeLoggerSettings();
    }
}