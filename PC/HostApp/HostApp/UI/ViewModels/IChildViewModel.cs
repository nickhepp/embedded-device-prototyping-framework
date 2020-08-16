using HostApp.UI.ViewModels;
using System.Drawing;


namespace HostApp.UI.ChildUI
{

    public interface IChildViewModel : IDeviceViewModel
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
