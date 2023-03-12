using Ecs.Edpf.GUI.ComponentModel;
using Ecs.Edpf.GUI.Controls;
using Ecs.Edpf.GUI.UI.ViewModels.DataStorage.AddStorageViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecs.Edpf.GUI.UI.Views.DataStorage
{
    public partial class AddDataStorageStreamView : Form
    {

        private DataBindingComboBox _dataBindingComboBox;

        private IAddDataStorageStreamViewModel _addDataStorageStreamViewModel;
        public IAddDataStorageStreamViewModel AddDataStorageStreamViewModel
        {
            get
            {
                return _addDataStorageStreamViewModel;
            }
            set
            {
                _addDataStorageStreamViewModel = value;
                InitializeView();
            }
        }

        public AddDataStorageStreamView()
        {
            InitializeComponent();

            _dataBindingComboBox = new DataBindingComboBox();
            _dataBindingComboBox.SelectedValueChanged += DataBindingComboBox_SelectedValueChanged;
            _comboBoxPnl.Controls.Add(_dataBindingComboBox);
            _dataBindingComboBox.Dock = DockStyle.Fill;
        }

        private void DataBindingComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_addDataStorageStreamViewModel != null)
            {
                _addDataStorageStreamViewModel.SelectedStreamType = (IChildAddDataStorageStreamViewModel)_dataBindingComboBox.SelectedValue;
            }
        }

        private void InitializeView()
        {
            if (_addDataStorageStreamViewModel != null)
            {
                DataBoundBindingList<IChildAddDataStorageStreamViewModel> bindingList = new DataBoundBindingList<IChildAddDataStorageStreamViewModel>(
                    _addDataStorageStreamViewModel.StreamTypes, 
                    nameof(IChildAddDataStorageStreamViewModel.TypeName),
                    nameof(IChildAddDataStorageStreamViewModel.ThisValue));
                _dataBindingComboBox.BindToList(bindingList);
                _dataBindingComboBox.DataBindings.Add(new Binding(nameof(ComboBox.SelectedValue),
                    _addDataStorageStreamViewModel,
                    nameof(_addDataStorageStreamViewModel.SelectedStreamType)));

                _addDataStorageStreamViewModel.PropertyChanged += AddDataStorageStreamViewModel_PropertyChanged;

                SetSettingsPropertyGrid();
            }
        }

        private void SetSettingsPropertyGrid()
        {
            _settingsPpg.SelectedObject = _addDataStorageStreamViewModel.SelectedStreamType.ChildDataStorageStreamSettings;
        }

        private void AddDataStorageStreamViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_addDataStorageStreamViewModel.SelectedStreamType))
            {
                SetSettingsPropertyGrid();
            }
        }
    }
}
