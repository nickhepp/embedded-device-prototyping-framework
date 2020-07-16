using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HostApp.Business;

namespace HostApp.UI.ViewModels
{
    public interface IConnectionViewModel : IViewModel
    {

        List<ConsoleTokenHighlight> ConsoleTokenHighlights { get; set; }

        string ErrorMessages { get; set; }

        BindingList<string> DeviceOutputBuffer { get; }

        bool OpenButtonEnabled { get; }

        bool CloseButtonEnabled { get; }

        ICommand OpenCommand { get; }

        ICommand CloseCommand { get; }

        void WriteTextToDevice(string cmdText);


    }
}
