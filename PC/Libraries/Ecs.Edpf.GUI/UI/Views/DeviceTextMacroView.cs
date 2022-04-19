using Ecs.Edpf.GUI.ComponentModel;
using Ecs.Edpf.GUI.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecs.Edpf.GUI.UI.Views
{
    public partial class DeviceTextMacroView : UserControl
    {

        private IDeviceTextMacroViewModel _deviceTextMacroViewModel;
        public IDeviceTextMacroViewModel DeviceTextMacroViewModel 
        {
            get
            {
                return _deviceTextMacroViewModel;
            }
            set
            {
                _deviceTextMacroViewModel = value;
                UpdateDeviceTextMacroViewModel();
            }
        }

        private List<RelayCommandHandler> _relayCmdHandlers = new List<RelayCommandHandler>();

        public DeviceTextMacroView()
        {
            InitializeComponent();

            // _recordPlayBtn
            _stopBtn.ImageList = new ImageList();
            _stopBtn.ImageList.Images.Add(Ecs.Edpf.GUI.Properties.Resources.record);
            _stopBtn.ImageList.ColorDepth = ColorDepth.Depth32Bit;
            _stopBtn.ImageList.ImageSize = new Size(50, 50);
            _stopBtn.Image = _stopBtn.ImageList.Images[0];

            // _oneShotBtn
            _oneShotBtn.ImageList = new ImageList();
            _oneShotBtn.ImageList.Images.Add(Ecs.Edpf.GUI.Properties.Resources.repeat_one1);
            _oneShotBtn.ImageList.ColorDepth = ColorDepth.Depth32Bit;
            _oneShotBtn.ImageList.ImageSize = new Size(50, 50);
            _oneShotBtn.Image = _oneShotBtn.ImageList.Images[0];

            // _loopBtn
            _loopBtn.ImageList = new ImageList();
            _loopBtn.ImageList.Images.Add(Ecs.Edpf.GUI.Properties.Resources.repeat);
            _loopBtn.ImageList.ColorDepth = ColorDepth.Depth32Bit;
            _loopBtn.ImageList.ImageSize = new Size(50, 50);
            _loopBtn.Image = _loopBtn.ImageList.Images[0];



        }

        private void UpdateDeviceTextMacroViewModel()
        {
            if (_deviceTextMacroViewModel == null)
            {
                _relayCmdHandlers.Clear();
            }
            else
            {
                _relayCmdHandlers.Add(
                    new RelayCommandHandler(_oneShotBtn, _deviceTextMacroViewModel.OneShotCommand));

                _relayCmdHandlers.Add(
                    new RelayCommandHandler(_loopBtn, _deviceTextMacroViewModel.LoopCommand));

                _relayCmdHandlers.Add(
                    new RelayCommandHandler(_stopBtn, _deviceTextMacroViewModel.StopCommand));

                _scriptRtb.DataBindings.Add(new Binding(nameof(RichTextBox.Enabled), _deviceTextMacroViewModel, nameof(IDeviceTextMacroViewModel.MacroTextEnabled)));

                _deviceTextMacroViewModel.PropertyChanged += DeviceTextMacroViewModel_PropertyChanged;

            }
        }

        private void DeviceTextMacroViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //if (e.PropertyName == nameof(IDeviceTextMacroViewModel.MacroTextEnabled))
            //{
            //    // not sure why this is needed
            //    _scriptRtb.Enabled = _deviceTextMacroViewModel.MacroTextEnabled;
            //}
        }

        private void LoadDemoScriptTsb_Click(object sender, EventArgs e)
        {

        }
    }
}
