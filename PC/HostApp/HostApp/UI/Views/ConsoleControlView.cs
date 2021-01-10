using System.Collections.Generic;
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
            _deviceHistoryRtb.Clear();
        }


        private void SetBindings()
        {

            // direct input text is only enabled when
            _inputTxt.DataBindings.Add(new Binding(nameof(TextBox.Enabled), 
                _consoleControlViewModel, 
                nameof(IConsoleControlViewModel.InputTextEnabled)));
            _inputLbl.DataBindings.Add(new Binding(nameof(Label.Enabled),
                _consoleControlViewModel,
                nameof(IConsoleControlViewModel.InputTextEnabled)));
            _consoleLbl.DataBindings.Add(new Binding(nameof(Label.Enabled),
                _consoleControlViewModel,
                nameof(IConsoleControlViewModel.InputTextEnabled)));

            _inputTxt.KeyDown += InputTextKeyDown;

            _consoleControlViewModel.DeviceOutputBufferChanged += ConsoleControlViewModelDeviceOutputBufferChanged;
            ConsoleControlViewModelDeviceOutputBufferChanged(this, new System.EventArgs());
        }

        private void ConsoleControlViewModelDeviceOutputBufferChanged(object sender, System.EventArgs e)
        {
            _consoleControlViewModel.DeviceOutputBuffer.ListChanged += DeviceOutputBufferListChanged;
        }

        private void DeviceOutputBufferListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (e.ListChangedType == System.ComponentModel.ListChangedType.ItemAdded)
            {
                int initialRtbLength = _deviceHistoryRtb.Text.Length;
                _deviceHistoryRtb.AppendText(_consoleControlViewModel.DeviceOutputBuffer[e.NewIndex]);
                string nextString = _deviceHistoryRtb.Text.Substring(initialRtbLength, _deviceHistoryRtb.Text.Length - initialRtbLength);

                // look for any places that need highlighting
                foreach (ConsoleTokenHighlight consoleTokenHighlight in _consoleControlViewModel.ConsoleTokenHighlights)
                {
                    List<int> idxs = Extensions.StringExtensions.AllIndexesOf(nextString, consoleTokenHighlight.Token);
                    foreach (int idx in idxs)
                    {
                        // we found something to highlight
                        _deviceHistoryRtb.SelectionStart = idx + initialRtbLength;
                        _deviceHistoryRtb.SelectionLength = consoleTokenHighlight.Token.Length;
                        _deviceHistoryRtb.SelectionBackColor = consoleTokenHighlight.BackgroundColor;
                        _deviceHistoryRtb.SelectionColor = consoleTokenHighlight.ForegroundColor;
                    }
                }

                // set the current caret position to the end, scroll it automatically
                _deviceHistoryRtb.SelectionStart = _deviceHistoryRtb.Text.Length;
                _deviceHistoryRtb.ScrollToCaret();
            }
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
