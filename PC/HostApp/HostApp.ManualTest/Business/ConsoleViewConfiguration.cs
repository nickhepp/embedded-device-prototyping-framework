using Ecs.Edpf.GUI.UI.ViewModels;
using Ecs.Edpf.GUI.UI.Views;
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
