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

        private List<string> _streamTypes;
        public IEnumerable<string> StreamTypes
        {
            get { return _streamTypes; }
        }

        private string _selectedStreamType;

        public event PropertyChangedEventHandler PropertyChanged;

        public string SelectedStreamType 
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

            _streamTypes = _childStreamVwMdlFactory.GetStreamsTypes().ToList();
            _selectedStreamType = _streamTypes.First();

        }
    }
}
