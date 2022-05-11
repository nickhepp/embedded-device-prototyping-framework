using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.IO.Cmds;

namespace Ecs.Edpf.GUI.UI.ViewModels
{

    public class DeviceCommandViewModel : BaseDeviceCommandViewModel, IDeviceCommandViewModel
    {
        private IDevice _device;

        public DeviceCommandViewModel(IDevice device, IDeviceCommand deviceCommand) : base(deviceCommand)
        {
            _device = device;
        }

        public void Execute()
        {
            _device.ExecuteCommand(DeviceCommand);
        }

    }

}
