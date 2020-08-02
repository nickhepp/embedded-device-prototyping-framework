using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.Business
{
    public interface IDevice : INotifyPropertyChanged
    {

        BindingList<string> DeviceOutputBuffer { get; }

        bool IsOpen { get; }

        bool Open();

        void Close();

        string Write(string cmdText);

        /// <summary>
        /// Event that is raised when the device is opened.
        /// </summary>
        event EventHandler DeviceOpened;

        /// <summary>
        /// Event that is raised when the device is closed.
        /// </summary>
        event EventHandler DeviceClosed;

    }
}
