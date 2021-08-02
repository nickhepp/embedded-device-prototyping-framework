using Ecs.Edpf.Devices.IO.Macros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.ComponentModel.Macros
{
    public interface IDeviceTextMacroBgWorkerFactory
    {

        IDeviceTextMacroBgWorker GetDeviceTextMacroBgWorker(DeviceTextMacro deviceTextMacro);

    }
}
