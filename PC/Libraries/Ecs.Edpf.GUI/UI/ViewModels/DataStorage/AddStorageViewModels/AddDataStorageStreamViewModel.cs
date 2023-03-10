using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.AddStorageViewModels
{
    public class AddDataStorageStreamViewModel : IAddDataStorageStreamViewModel
    {
        private readonly IChildAddDataStorageStreamViewModelFactory _childStreamVwMdlFactory;

        private IEnumerable<IChildAddDataStorageStreamViewModel> _streamTypes;
        public IEnumerable<IChildAddDataStorageStreamViewModel> StreamTypes
        {
            get { return _streamTypes; }
        }

        private IChildAddDataStorageStreamViewModel _selectedStreamType;

        public event PropertyChangedEventHandler PropertyChanged;

        public IChildAddDataStorageStreamViewModel SelectedStreamType 
        { 
            get
            {
                return _selectedStreamType;
            }
            set
            {
                _selectedStreamType = value;
            } 
        }
    
    
        public AddDataStorageStreamViewModel(
            IChildAddDataStorageStreamViewModelFactory childStreamVwMdlFactory)
        {
            _childStreamVwMdlFactory = childStreamVwMdlFactory;

            _streamTypes = _childStreamVwMdlFactory.GetChildAddDataStorageStreamTypes();

            //_streamTypes = _childStreamVwMdlFactory.GetChildAddDataStorageStreamTypes().ToList();
            _selectedStreamType = _streamTypes.First();

        }
    }
}
