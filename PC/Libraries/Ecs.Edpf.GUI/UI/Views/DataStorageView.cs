using Ecs.Edpf.GUI.ComponentModel;
using Ecs.Edpf.GUI.UI.ViewModels.DataStorage;
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
    public partial class DataStorageView : UserControl
    {

        private IDataStorageViewModel _dataStorageViewModel;
        public IDataStorageViewModel DataStorageViewModel
        {
            get
            {
                return _dataStorageViewModel;
            }
            set
            {
                _dataStorageViewModel = value;
                UpdateDataStorageViewModel();
            }
        }

        private List<RelayCommandHandler> _relayCmdHandlers = new List<RelayCommandHandler>();

        public DataStorageView()
        {
            InitializeComponent();
        }

        private void UpdateDataStorageViewModel()
        {
            _relayCmdHandlers.Clear();
            
            if (_dataStorageViewModel != null)
            {
                _relayCmdHandlers.Add(
                    new RelayCommandHandler(_oneShotBtn, _deviceTextMacroViewModel.OneShotCommand, relayCommandExHandler: this, getCommandArgHandler: GetInstructionCollectionInitArgs));
            
                _relayCmdHandlers.Add(
                    new RelayCommandHandler(_loopBtn, _deviceTextMacroViewModel.LoopCommand, relayCommandExHandler: this, getCommandArgHandler: GetInstructionCollectionInitArgs));
            
                _relayCmdHandlers.Add(
                    new RelayCommandHandler(_stopBtn, _deviceTextMacroViewModel.StopCommand, relayCommandExHandler: this));
            
                _macroTxt.DataBindings.Add(new Binding(nameof(TextBox.Enabled), _deviceTextMacroViewModel, nameof(IDeviceTextMacroViewModel.MacroTextEnabled)));
            
                SetProgressBar();
                SetTsbAddCommandEnabled();

                _dataStorageViewModel.PropertyChanged += DataStorageViewModel_PropertyChanged;
            
            }
        }

        private void DataStorageViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _addStreamBtn_Click(object sender, EventArgs e)
        {

        }

        private void _recordPauseAllBtn_Click(object sender, EventArgs e)
        {

        }

        private void _removeStreamsBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
