using Ecs.Edpf.Devices.ComponentModel.Macros.Instructions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.Devices.ComponentModel.Macros
{
    public class DeviceTextMacroBgWorkerFactory : IDeviceTextMacroBgWorkerFactory
    {

        public IDeviceTextMacroBgWorker GetDeviceTextMacroBgWorker(InstructionCollection instructions, MacroExecutionType exeType)
        {
            return new DeviceTextMacroBgWorker(instructions, exeType);
        }

    }
}
