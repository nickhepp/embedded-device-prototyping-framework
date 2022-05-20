using Ecs.Edpf.Devices.IO.Cmds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels
{
    public class GetDeviceCommandLinesViewModel : BaseDeviceCommandViewModel, IGetDeviceCommandLinesViewModel
    {





        public GetDeviceCommandLinesViewModel(IDeviceCommand deviceCommand) : base(deviceCommand)
        {

        }


        public List<string> GetCommandTextLines()
        {
            return DeviceCommand.GetCommandTextLines();
        }




    }
}
