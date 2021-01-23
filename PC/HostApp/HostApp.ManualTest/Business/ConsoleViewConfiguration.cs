using Ecs.Edpf.GUI.UI.ViewModels;
using Ecs.Edpf.GUI.UI.Views;
using System.Windows.Forms;

namespace HostApp.ManualTest.Business
{
    public class ConsoleViewConfiguration : ViewConfiguration
    {
        public override string ViewName => "Console";

        private ConsoleView _ccView;

        private IConsoleViewModel _ccViewModel;


        public ConsoleViewConfiguration()
        {
            _ccView = new ConsoleView();
            _ccViewModel = new ConsoleViewModel();
            _ccView.ConsoleViewModel = _ccViewModel;
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
