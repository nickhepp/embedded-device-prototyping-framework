using Ecs.Edpf.Data.DataStreams;
using Ecs.Edpf.Data.StreamSettings;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.AddStorageViewModels
{
    public abstract class BaseChildDataStorageStreamSettings<TDataStreamSettings> : 
        IChildDataStorageStreamSettings, 
        INotifyPropertyChanged
        where TDataStreamSettings : DataStreamSettings, new()
    {

        public const string TypeCategory = "\t\t\t\t\tType";
        public const string NameCategory = "\t\t\t\tName";
        public const string ValueTypesCategory = "\t\t\tValue Types";

        private TDataStreamSettings _streamSettings = new TDataStreamSettings();

        [Category(TypeCategory)]
        [DisplayName("Type")]
        public abstract string TypeName { get; }

        [Category(NameCategory)]
        [DisplayName("Stream Name")]
        public string StreamName
        {
            get
            {
                if (_streamSettings.Name == null)
                {
                    _streamSettings.Name =  $"{TypeName} Stream";
                }
                return _streamSettings.Name;
            }
            set
            {
                _streamSettings.Name = value;
                RaiseNotifyPropertyChanged();
            }
        } 

        [Category(ValueTypesCategory)]
        [DisplayName("Value Types")]
        public LineResultsSet Values
        {
            get
            {
                return _streamSettings.Values;
            }
            set
            {
                _streamSettings.Values = value;
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
