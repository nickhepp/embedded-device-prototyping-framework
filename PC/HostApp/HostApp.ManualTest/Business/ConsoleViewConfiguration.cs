using HostApp.UI;
using HostApp.UI.ViewModels;
using HostApp.UI.ViewModels.Controls;
using HostApp.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostApp.ManualTest.Business
{
    public class ConsoleViewConfiguration : ViewConfiguration
    {
        public override string ViewName => "Console";

        private ConsoleControlView _ccView;

        private IConsoleControlViewModel _ccViewModel;


        public ConsoleViewConfiguration()
        {
            _ccView = new ConsoleControlView();
            _ccViewModel = new ConsoleControlViewModel();

            //ConsoleControlViewModel : BaseDeviceViewModel, IConsoleControlViewModel

            _ccView.ConsoleControlViewModel = _ccViewModel;
        }

        public override Control GetControl()
        {
            return _ccView;
        }

        public override IViewModel GetViewModel()
        {
            return _ccViewModel;
        }
    }
}
