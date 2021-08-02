using Ecs.Edpf.Devices.ComponentModel;
using Ecs.Edpf.Devices.IO.Macros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.ComponentModel.Macros
{
    public class DeviceTextMacroBgWorker : BackgroundWorker, IDeviceTextMacroBgWorker
    {


        private DeviceTextMacroIterationMachine _iterationMachine;


        // DeviceTextMacroProgressChanged

        protected override bool CanRaiseEvents => true;

        

        public DeviceTextMacroBgWorker(DeviceTextMacro deviceTextMacro)
        {
            _iterationMachine = new DeviceTextMacroIterationMachine(deviceTextMacro, new DateTimeProvider());
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            while (!e.Cancel && !_iterationMachine.Completed)
            {
                DeviceTextLine devTextLine = _iterationMachine.GetNextDeviceTextLine();
                if (devTextLine != null)
                {
                    ReportProgress(0, new DeviceTextMacroProgressChanged { DeviceText = devTextLine.DeviceText, RatioComplete = _iterationMachine.RatioComplete });
                }
            }
        }





    }
}
