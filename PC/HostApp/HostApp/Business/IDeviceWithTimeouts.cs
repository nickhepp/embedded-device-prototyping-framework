using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.Business
{
    public interface IDeviceWithTimeouts
    {
        int CommandTimeout { get; set; }
    }
}
