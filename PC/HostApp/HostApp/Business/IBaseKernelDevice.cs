using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.Business
{
    interface IBaseKernelDevice
    {

        string ExecuteCommand(string cmdName);

        void SetCommandParameter(int idx, string paramValue);

    }
}
