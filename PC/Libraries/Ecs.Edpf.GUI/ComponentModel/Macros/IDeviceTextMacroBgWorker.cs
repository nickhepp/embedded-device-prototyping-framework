using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.ComponentModel.Macros
{
    public interface IDeviceTextMacroBgWorker : IDisposable
    {

        event ProgressChangedEventHandler ProgressChanged;

        event RunWorkerCompletedEventHandler RunWorkerCompleted;

        void CancelAsync();

    }
}
