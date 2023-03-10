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
            _comboBoxPnl.Controls.Add(_dataBindingComboBox);
            _dataBindingComboBox.Dock = DockStyle.Fill;
        }

        private void InitializeView()
        {
            if (_addDataStorageStreamViewModel != null)
            {
                //_addDataStorageStreamViewModel.StreamTypes

                // public void BindToList<T>(DataBoundBindingList<T> bindingList)
                DataBoundBindingList<IChildAddDataStorageStreamViewModel> bindingList = new DataBoundBindingList<IChildAddDataStorageStreamViewModel>(_addDataStorageStreamViewModel.StreamTypes,
                    nameof(IChildAddDataStorageStreamViewModel.TypeName), "");
                //_dataBindingComboBox.

                //_addDataStorageStreamViewModel.StreamTypes
            }
            else
            {

            }
        }

    }
}
