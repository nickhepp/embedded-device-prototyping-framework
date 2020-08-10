using System.Windows.Forms;
using HostApp.UI.ViewModels;


namespace HostApp.UI.Views
{
    public partial class ConsoleControlView : UserControl
    {

        private IConsoleControlViewModel _consoleControlViewModel;
        public IConsoleControlViewModel ConsoleControlViewModel
        {
            get
            {
                return _consoleControlViewModel;
            }
            set
            {
                _consoleControlViewModel = value;
                SetBindings();
            }
        }

        public ConsoleControlView()
        {
            InitializeComponent();
        }


        private void SetBindings()
        {

            // direct input text is only enabled when
            _inputTxt.DataBindings.Add(new Binding(nameof(TextBox.Enabled), 
                _consoleControlViewModel, 
                nameof(IConsoleControlViewModel.InputTextEnabled)));

            _inputTxt.KeyDown += InputTextKeyDown;

        }

        private void InputTextKeyDown(object sender, KeyEventArgs ke)
        {
            if (ke.KeyCode == Keys.Enter)
            {
                _consoleControlViewModel.WriteTextToDevice(_inputTxt.Text);
                _inputTxt.Text = "";
            }
        }
    }
}
