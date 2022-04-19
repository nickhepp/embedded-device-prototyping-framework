using Ecs.Edpf.Devices.ComponentModel.Macros.Instructions;

namespace Ecs.Edpf.Devices.ComponentModel.Macros
{
    public interface IDeviceTextMacroBgWorkerFactory
    {

        IDeviceTextMacroBgWorker GetDeviceTextMacroBgWorker(InstructionCollection instructions, MacroExecutionType exeType);

    }
}
