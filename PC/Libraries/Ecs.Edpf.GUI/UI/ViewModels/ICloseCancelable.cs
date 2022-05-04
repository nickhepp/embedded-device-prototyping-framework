using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels
{
    public interface ICloseCancelable
    {

        /// <summary>
        /// Returns whether or not the closing of the application should be canceled.
        /// </summary>
        /// <returns>Returns a message to display to the user in the event the application cannot be closed, or null.</returns>
        string GetCancelCloseReason();

    }
}
