using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.Devices.ComponentModel.Macros
{
    public interface IDeviceTextMacroBgWorker : IDisposable
    {

        event ProgressChangedEventHandler ProgressChanged;

        event RunWorkerCompletedEventHandler RunWorkerCompleted;

        void RunWorkerAsync();

        void CancelAsync();

    }
}
