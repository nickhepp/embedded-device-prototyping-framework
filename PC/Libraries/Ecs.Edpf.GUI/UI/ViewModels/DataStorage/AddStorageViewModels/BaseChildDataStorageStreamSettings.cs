using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.AddStorageViewModels
{
    public abstract class BaseChildDataStorageStreamSettings : IChildDataStorageStreamSettings, INotifyPropertyChanged
    {

        public const string TypeCategory = "\t\t\t\t\tType";
        public const string NameCategory = "\t\t\t\tName";

        [Category(TypeCategory)]
        [DisplayName("Type")]
        public abstract string TypeName { get; }

        private string _streamName = null;
        [Category(NameCategory)]
        [DisplayName("Stream Name")]
        public string StreamName
        {
            get
            {
                if (_streamName == null)
                {
                    _streamName =  $"{TypeName} Stream";
                }
                return _streamName;
            }
            set
            {
                _streamName = value;
                RaiseNotifyPropertyChanged();
            }
        } 


        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaiseNotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));  
            }
        }

    }
}
