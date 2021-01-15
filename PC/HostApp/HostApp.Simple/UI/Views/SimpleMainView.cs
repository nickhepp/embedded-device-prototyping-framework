using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Ecs.Edpf.GUI.UI.ViewModels;
using Ecs.Edpf.GUI.UI.ViewModels.Connections;
using Ecs.Edpf.GUI.UI.Views;
using HostApp.Simple.UI.ViewModels;

namespace HostApp.Simple.UI.Views
{
    public partial class SimpleMainView : UserControl, IMainView
    {

        private ISimpleMainViewModel _vwMdl;
        private IConnectionViewModel _connVwMdl;

        public SimpleMainView()
        {
            InitializeComponent();

            this.Load += MainFormLoad;

 

            ////AppInfo.InitializeTypesWithBaseKernel();


            //_vwMdl = new SimpleMainViewModel();
            //_vwMdl.PropertyChanged += _vwMdl_PropertyChanged;
            ////_vwMdl.DeviceOutputBuffer.ListChanged += DeviceOutputBufferListChanged;


            //_settingsPpg.SelectedObject = _vwMdl;

            //_openBtn.DataBindings.Add(new Binding(nameof(Button.Enabled), _vwMdl, nameof(ISimpleMainViewModel.OpenButtonEnabled)));
            //_closeBtn.DataBindings.Add(new Binding(nameof(Button.Enabled), _vwMdl, nameof(ISimpleMainViewModel.CloseButtonEnabled)));
            //_errorsLbl.DataBindings.Add(new Binding(nameof(Label.Text), _vwMdl, nameof(ISimpleMainViewModel.ErrorMessages)));

            //// direct input text is only enabled when
            //_inputTxt.DataBindings.Add(new Binding(nameof(TextBox.Enabled), _vwMdl, nameof(ISimpleMainViewModel.CloseButtonEnabled)));

            ////List<Tuple<string, ICommand>> cmdNameTuples = ViewModelCommandExtractor.GetCommands(_vwMdl);

            //// turn the methods in the form of "<Xyz>Command()" into buttons
            //_cmdsTlp.RowStyles.Clear();
            //float percentHeight = (cmdNameTuples.Count > 0) ? 100.0f / cmdNameTuples.Count : 0f;
            //foreach (Tuple<string, ICommand> cmdNameTuple in cmdNameTuples)
            //{
            //    int idx = _cmdsTlp.RowStyles.Add(new RowStyle(SizeType.Percent, percentHeight));

            //    Button btn = new Button();
            //    _cmdsTlp.Controls.Add(btn);

            //    // only enable commands if we have an open connection
            //    btn.DataBindings.Add(new Binding(nameof(Button.Enabled), _vwMdl, nameof(ISimpleMainViewModel.CloseButtonEnabled)));

            //    btn.Dock = DockStyle.Fill;
            //    btn.Tag = cmdNameTuple;

            //    // split the caps into differnt words
            //    btn.Text = cmdNameTuple.Item1;
            //    btn.Click += cmdButtonClick;
            //}

            //_inputTxt.KeyDown += InputTextKeyDown;

            SetErrorMessageControls();
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            _mainSpl.SplitterDistance = (int)(this.Width * 0.75);
            _leftSpl.SplitterDistance = (int)(this.Height * 0.75);
        }


        private void DeviceOutputBufferListChanged(object sender, ListChangedEventArgs e)
        {
            //if (e.ListChangedType == ListChangedType.ItemAdded)
            //{

            //    int initialRtbLength = _deviceHistoryRtb.Text.Length;
            //    _deviceHistoryRtb.AppendText(_vwMdl.DeviceOutputBuffer[e.NewIndex]);
            //    string nextString = _deviceHistoryRtb.Text.Substring(initialRtbLength, _deviceHistoryRtb.Text.Length - initialRtbLength);

            //    // look for any places that need highlighting
            //    foreach (ConsoleTokenHighlight consoleTokenHighlight in _vwMdl.ConsoleTokenHighlights)
            //    {

            //        List<int> idxs = HostApp.Extensions.StringExtensions.AllIndexesOf(nextString, consoleTokenHighlight.Token);
            //        foreach (int idx in idxs)
            //        {
            //            // we found something to highlight
            //            _deviceHistoryRtb.SelectionStart = idx + initialRtbLength;
            //            _deviceHistoryRtb.SelectionLength = consoleTokenHighlight.Token.Length;
            //            _deviceHistoryRtb.SelectionBackColor = consoleTokenHighlight.BackgroundColor;
            //            _deviceHistoryRtb.SelectionColor = consoleTokenHighlight.ForegroundColor;
            //        }
            //    }


            //    // set the current caret position to the end, scroll it automatically
            //    _deviceHistoryRtb.SelectionStart = _deviceHistoryRtb.Text.Length;
            //    _deviceHistoryRtb.ScrollToCaret();
            //}
        }

        private void SetErrorMessageControls()
        {
            //_errorsPbx.Visible = !string.IsNullOrEmpty(_vwMdl.ErrorMessages);
        }

        private void _vwMdl_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //_settingsPpg.Refresh();
            //if (e.PropertyName == nameof(IViewModel.ErrorMessages))
            //{
            //    SetErrorMessageControls();
            //}
        }

        private void _openBtn_Click(object sender, EventArgs e)
        {
            _connVwMdl.OpenCommand.Execute(null);
        }

        private void _closeBtn_Click(object sender, EventArgs e)
        {
            _connVwMdl.CloseCommand.Execute(null);
        }

        private void cmdButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Tuple<string, ICommand> cmdNameTuple = (Tuple<string, ICommand>)btn.Tag;
            if (cmdNameTuple.Item2.CanExecute(null))
            {
                cmdNameTuple.Item2.Execute(null);
            }
            _settingsPpg.Refresh();
        }

        public void SetMainViewModel(IMainViewModel mainViewModel)
        {

            _vwMdl = mainViewModel as ISimpleMainViewModel;
            if (_vwMdl == null)
                throw new Exception($"View model is not a {nameof(ISimpleMainViewModel)}.");

            _connVwMdl = _vwMdl.GetConnectionViewModel();

            ConsoleControlView consoleControlView = new ConsoleControlView();



        }
    }
}
