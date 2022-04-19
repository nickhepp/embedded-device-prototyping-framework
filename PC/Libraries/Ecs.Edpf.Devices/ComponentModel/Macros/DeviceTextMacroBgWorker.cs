using Ecs.Edpf.Devices.ComponentModel;
using Ecs.Edpf.Devices.ComponentModel.Macros.Instructions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.Devices.ComponentModel.Macros
{
    public class DeviceTextMacroBgWorker : BackgroundWorker, IDeviceTextMacroBgWorker
    {

        private DeviceTextMacroIterationMachine _iterationMachine;

        protected override bool CanRaiseEvents => true;

        public DeviceTextMacroBgWorker(InstructionCollection instructions, MacroExecutionType exeType)
        {
            _iterationMachine = new DeviceTextMacroIterationMachine(instructions, exeType, new DateTimeProvider());
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            while (!e.Cancel && !_iterationMachine.Completed)
            {
                Instruction instruction = _iterationMachine.GetNextDeviceTextLine();
                if (instruction != null)
                {
                    string devText = instruction.GetDeviceText();
                    ReportProgress(0, new DeviceTextMacroProgressChanged { DeviceText = devText, RatioComplete = _iterationMachine.RatioComplete });
                }
            }
        }





    }
}
