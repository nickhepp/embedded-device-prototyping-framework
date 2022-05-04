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

        private const long CancellationNotAcked = 0;
        private const long CancellationAcked = 1;

        private long _cancellationAcknowledge = CancellationNotAcked;
        public bool CancellationAcknowledge
        {
            get
            {
                bool acked = (System.Threading.Interlocked.Read(ref _cancellationAcknowledge) == CancellationAcked);
                return acked;
            }
        }

        public DeviceTextMacroBgWorker(InstructionCollection instructions, MacroExecutionType exeType)
        {
            _iterationMachine = new DeviceTextMacroIterationMachine(instructions, exeType, new DateTimeProvider());
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            while (!CancellationPending && !_iterationMachine.Completed)
            {
                List<TimeGrouping> timeGroupings = _iterationMachine.GetNextTimeGroupings();
                if (timeGroupings.Count > 0)
                {
                    ReportProgress(0, new DeviceTextMacroProgressChanged { RatioComplete = _iterationMachine.RatioComplete, TimeGroupings = timeGroupings });
                }
                // add some throttling so we dont overrun the application
                System.Threading.Thread.Sleep(200);
            }

            System.Threading.Interlocked.Exchange(ref _cancellationAcknowledge, CancellationAcked);
            if (CancellationPending)
            {
                e.Cancel = true;
            }
            
        }





    }
}
