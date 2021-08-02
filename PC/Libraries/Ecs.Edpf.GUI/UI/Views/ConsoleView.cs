using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ecs.Edpf.GUI.UI.ViewModels;


namespace Ecs.Edpf.GUI.UI.Views
{
    public partial class ConsoleView : UserControl
    {
        private ProgressBarWithMarker _progressBarWithMarker;
        private List<string> _previousCommands = new List<string>();

        private float _headerHeight;
        private bool _showConsoleHeader = true;
        public bool ShowConsoleHeader
        {
            get
            {
                return _showConsoleHeader;
            }
            set
            {
                _showConsoleHeader = value;
                if (_showConsoleHeader)
                {
                    _mainTlp.RowStyles[0].Height = _headerHeight;
                }
                else
                {
                    _mainTlp.RowStyles[0].Height = 0;
                }
            }
        }


        private IConsoleViewModel _consoleViewModel;
        public IConsoleViewModel ConsoleViewModel
        {
            get
            {
                return _consoleViewModel;
            }
            set
            {
                _consoleViewModel = value;
                SetBindings();
            }
        }

        public ConsoleView()
        {
            InitializeComponent();
            _deviceHistoryRtb.Clear();
            _headerHeight = _mainTlp.RowStyles[0].Height;
            _progressBarWithMarker = new ProgressBarWithMarker();
            _previousCommandsPnl.Controls.Add(_progressBarWithMarker);
            _progressBarWithMarker.Dock = DockStyle.Fill;
            _progressBarWithMarker.Margin = new Padding(0);

            _inputTxt.KeyDown += InputTxtKeyDown;
            SetMainControlArea();
        }

 

        private void InputTxtKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                _consoleViewModel.SelectUpPreviousCommand(_inputTxt.Text);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                _consoleViewModel.SelectDownPreviousCommand();
                e.Handled = true;
            }
            
        }

 

        private void _deviceHistoryRtb_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            _inputTxt.Focus();
            // TODO: make pressed button go to input text
        }

        private void SetBindings()
        {

            // direct input text is only enabled when
            _inputTxt.DataBindings.Add(new Binding(nameof(TextBox.Enabled), 
                _consoleViewModel, 
                nameof(IConsoleViewModel.InputTextEnabled)));
            _inputLbl.DataBindings.Add(new Binding(nameof(Label.Enabled),
                _consoleViewModel,
                nameof(IConsoleViewModel.InputTextEnabled)));
            _consoleLbl.DataBindings.Add(new Binding(nameof(Label.Enabled),
                _consoleViewModel,
                nameof(IConsoleViewModel.InputTextEnabled)));

            _inputTxt.KeyDown += InputTextKeyDown;

            _consoleViewModel.DeviceOutputBufferChanged += ConsoleControlViewModelDeviceOutputBufferChanged;
            ConsoleControlViewModelDeviceOutputBufferChanged(this, new System.EventArgs());

            _progressBarWithMarker.DataBindings.Add(new Binding(nameof(ProgressBarWithMarker.Maximum),
                _consoleViewModel,
                nameof(IConsoleViewModel.MaxPreviousCommandCount)));
            _progressBarWithMarker.DataBindings.Add(new Binding(nameof(ProgressBarWithMarker.Value),
                _consoleViewModel,
                nameof(IConsoleViewModel.PreviousCommandCount)));

            //_progressBarWithMarker.DataBindings.Add(new Binding(nameof(ProgressBarWithMarker.SelectedValue),
            //    _consoleViewModel,
            //    nameof(IConsoleViewModel.SelectedPreviousCommandIndex)));


            _consoleViewModel.PropertyChanged += ConsoleViewModelPropertyChanged;

        }

        private void ConsoleViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IConsoleViewModel.SelectedPreviousCommand))
            {
                _inputTxt.Text = _consoleViewModel.SelectedPreviousCommand;
                _inputTxt.SelectAll();
            }
            else if (e.PropertyName == nameof(IConsoleViewModel.SelectedPreviousCommandIndex))
            {
                _progressBarWithMarker.SelectedValue = _consoleViewModel.SelectedPreviousCommandIndex;
            }
            else if (e.PropertyName == nameof(IConsoleViewModel.InputTextEnabled))
            {
                SetMainControlArea();
            }
        }

        private void SetMainControlArea()
        {
            if (_consoleViewModel != null && _consoleViewModel.InputTextEnabled)
            {
                _deviceHistoryRtb.Text = "";
                _deviceHistoryRtb.ForeColor = Color.White;
                _deviceHistoryRtb.BackColor = Color.Black;
            }
            else
            {
                _deviceHistoryRtb.Text = "Open device in [Connections] to enable console.";
                _deviceHistoryRtb.ForeColor = Color.Black;
                _deviceHistoryRtb.BackColor = Color.LightGray;
            }
        }


        private void ConsoleControlViewModelDeviceOutputBufferChanged(object sender, System.EventArgs e)
        {
            _consoleViewModel.DeviceOutputBuffer.ListChanged += DeviceOutputBufferListChanged;
        }

        private void DeviceOutputBufferListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (e.ListChangedType == System.ComponentModel.ListChangedType.ItemAdded)
            {
                int initialRtbLength = _deviceHistoryRtb.Text.Length;
                _deviceHistoryRtb.AppendText(_consoleViewModel.DeviceOutputBuffer[e.NewIndex]);
                string nextString = _deviceHistoryRtb.Text.Substring(initialRtbLength, _deviceHistoryRtb.Text.Length - initialRtbLength);

                // look for any places that need highlighting
                foreach (ConsoleTokenHighlight consoleTokenHighlight in _consoleViewModel.ConsoleTokenHighlights)
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
                _consoleViewModel.WriteTextToDevice(_inputTxt.Text);
                _inputTxt.Text = "";
            }
        }
    }
}
