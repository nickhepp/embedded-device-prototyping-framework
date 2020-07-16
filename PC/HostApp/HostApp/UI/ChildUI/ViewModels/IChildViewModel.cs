using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HostApp.Business;

namespace HostApp.UI.ChildUI
{

    public interface IChildViewModel
    {

        /// <summary>
        /// Image to associate with the view.
        /// </summary>
        Image ViewImage { get; }

        /// <summary>
        /// Name of the view.
        /// </summary>
        string Name { get; }

    }

}
