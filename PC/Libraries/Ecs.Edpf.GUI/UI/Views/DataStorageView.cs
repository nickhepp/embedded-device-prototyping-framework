using Ecs.Edpf.GUI.ComponentModel;
using Ecs.Edpf.GUI.UI.ViewModels.DataStorage;
using Ecs.Edpf.GUI.UI.ViewModels.DataStorage.AddStorageViewModels;
using Ecs.Edpf.GUI.UI.ViewModels.DataStorage.StreamViewModelGenerators;
using Ecs.Edpf.GUI.UI.Views.DataStorage;
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
    public partial class DataStorageView : UserControl, IRelayCommandExceptionHandler
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
                    new RelayCommandHandler(_addStreamBtn, 
                    _dataStorageViewModel.AddDataStreamCommand, 
                    relayCommandExHandler: this, 
                    getCommandArgHandler: GetAddDataStreamCommandArgs));
            
                _relayCmdHandlers.Add(
                    new RelayCommandHandler(_removeStreamsBtn, 
                    _dataStorageViewModel.RemoveDataStreamsCommand, 
                    relayCommandExHandler: this, 
                    getCommandArgHandler: GetRemoveDataStreamsCommandArgs));
            
                _relayCmdHandlers.Add(
                    new RelayCommandHandler(_recordAllBtn, 
                    _dataStorageViewModel.RecordAllStreamsCommand, 
                    relayCommandExHandler: this));

                _relayCmdHandlers.Add(
                    new RelayCommandHandler(_pauseAllBtn,
                    _dataStorageViewModel.PauseAllStreamsCommand,
                    relayCommandExHandler: this));


                //_macroTxt.DataBindings.Add(new Binding(nameof(TextBox.Enabled), _deviceTextMacroViewModel, nameof(IDeviceTextMacroViewModel.MacroTextEnabled)));

                //SetProgressBar();
                //SetTsbAddCommandEnabled();

                _dataStorageViewModel.PropertyChanged += DataStorageViewModel_PropertyChanged;
            
            }
        }

        private object GetAddDataStreamCommandArgs()
        {
            AddDataStorageStreamView addStreamView = new AddDataStorageStreamView();
            addStreamView.AddDataStorageStreamViewModel = new AddDataStorageStreamViewModel(new ChildAddDataStorageStreamViewModelFactory());
            IDataStorageStreamViewModelGenerator streamViewModelGenerator = null;
            if (addStreamView.ShowDialog() == DialogResult.OK)
            {
                IChildDataStorageStreamSettings settings = addStreamView.AddDataStorageStreamViewModel.SelectedStreamType.ChildDataStorageStreamSettings;

                streamViewModelGenerator = new DataStorageStreamViewModelGenerator(settings);
            }

            return streamViewModelGenerator;
        }

        private object GetRemoveDataStreamsCommandArgs()
        {
            return new object();
        }

        private void DataStorageViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _addStreamBtn_Click(object sender, EventArgs e)
        {

        }

        private void _recordAllBtn_Click(object sender, EventArgs e)
        {

        }

        private void _removeStreamsBtn_Click(object sender, EventArgs e)
        {

        }

        public void HandleException(Exception ex)
        {
            RelayCommandExceptionHandlerUtility.HandleException(ex);
        }

        private void _pauseAllBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
