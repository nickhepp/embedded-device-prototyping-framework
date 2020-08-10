using HostApp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostApp.ManualTest.Business
{




    /// <summary>
    /// A configuration that sets up a view for testing.
    /// </summary>
    public abstract class ViewConfiguration
    {

        public abstract string ViewName { get; }

        public abstract Control GetControl();


        public abstract IViewModel GetViewModel();

    }
}
