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

        event EventHandler DeviceOpened;

    }
}
