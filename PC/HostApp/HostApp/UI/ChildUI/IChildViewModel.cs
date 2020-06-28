using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HostApp.Business;

namespace HostApp.UI.ChildUI
{

    public interface IChildViewModel
    {

        IDevice Device { get; set; }

        string Name { get; }

    }

}
