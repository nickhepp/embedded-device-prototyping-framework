using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using HostApp.UI;

namespace HostApp
{
    public partial class MainForm : Form
    {


        public MainForm()
        {
            InitializeComponent();

            this.Load += MainForm_Load;

            this.Text = $"{this.Text} V{System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}";

            AppInfo.InitializeTypesWithBaseKernel();


            IMainViewModel mainVwMdl = ViewModelFactory.GetMainViewModel();
  
            //_vwMdl.DeviceOutputBuffer.ListChanged += DeviceOutputBufferListChanged;


            //if (_vwMdl is IChildViewModelProvider childVwMdlProvider)
            //{
            //    this.IsMdiContainer = true;

            //}
            ////IChildViewModelProvider childVwMdlProvider



            //_settingsPpg.SelectedObject = _vwMdl;

            //_openBtn.DataBindings.Add(new Binding(nameof(Button.Enabled), _vwMdl, nameof(IViewModel.OpenButtonEnabled)));
            //_closeBtn.DataBindings.Add(new Binding(nameof(Button.Enabled), _vwMdl, nameof(IViewModel.CloseButtonEnabled)));
            //_errorsLbl.DataBindings.Add(new Binding(nameof(Label.Text), _vwMdl, nameof(IViewModel.ErrorMessages)));

            //// direct input text is only enabled when
            //_inputTxt.DataBindings.Add(new Binding(nameof(TextBox.Enabled), _vwMdl, nameof(IViewModel.CloseButtonEnabled)));

            //List<Tuple<string, ICommand>> cmdNameTuples = ViewModelCommandExtractor.GetCommands(_vwMdl);

            //// turn the methods in the form of "<Xyz>Command()" into buttons
            //_cmdsTlp.RowStyles.Clear();
            //float percentHeight = (cmdNameTuples.Count > 0) ? 100.0f / cmdNameTuples.Count : 0f;
            //foreach (Tuple<string, ICommand> cmdNameTuple in cmdNameTuples)
            //{
            //    int idx = _cmdsTlp.RowStyles.Add(new RowStyle(SizeType.Percent, percentHeight));

            //    Button btn = new Button();
            //    _cmdsTlp.Controls.Add(btn);

            //    // only enable commands if we have an open connection
            //    btn.DataBindings.Add(new Binding(nameof(Button.Enabled), _vwMdl, nameof(IViewModel.CloseButtonEnabled)));

            //    btn.Dock = DockStyle.Fill;
            //    btn.Tag = cmdNameTuple;

            //    // split the caps into differnt words
            //    btn.Text = cmdNameTuple.Item1;
            //    btn.Click += cmdButtonClick;
            //}

            //_inputTxt.KeyDown += InputTextKeyDown;

            //SetErrorMessageControls();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //_mainSpl.SplitterDistance = (int)(this.Width * 0.75);
            //_leftSpl.SplitterDistance = (int)(this.Height * 0.75);
        }


    }
}
