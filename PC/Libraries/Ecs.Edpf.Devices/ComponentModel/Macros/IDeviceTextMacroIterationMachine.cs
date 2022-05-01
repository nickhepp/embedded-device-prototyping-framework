using Ecs.Edpf.Devices.ComponentModel.Macros.Instructions;
using System.Collections.Generic;

namespace Ecs.Edpf.Devices.ComponentModel.Macros
{
    public interface IDeviceTextMacroIterationMachine
    {
        bool Completed { get; }
        MacroExecutionType ExecutionType { get; }
        int IterationCount { get; }
        double RatioComplete { get; }

        List<TimeGrouping> GetNextTimeGroupings();
    }
}