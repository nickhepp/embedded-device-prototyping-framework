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




        bool OpenButtonEnabled { get; }

        bool CloseButtonEnabled { get; }

        ICommand OpenCommand { get; }

        ICommand CloseCommand { get; }



    }
}
