using Ecs.Edpf.GUI.ComponentModel;
using Ecs.Edpf.Data.StreamSettings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.StreamViewModels
{
    public abstract class BaseDataStorageStreamViewModel<TStreamSettings> : IDataStorageStreamViewModel
        where TStreamSettings : DataStreamSettings
    {

        public TStreamSettings StreamSettings { get; private set; }

        public string SuccessCountMessage => throw new NotImplementedException();

        public string FailCountMessage => throw new NotImplementedException();

        public IRelayCommand RecordPauseCommand => throw new NotImplementedException();

        public BindingList<DataStorageStreamLineResult> Results => throw new NotImplementedException();

        public event PropertyChangedEventHandler PropertyChanged;

        public BaseDataStorageStreamViewModel(TStreamSettings streamSettings)
        {
            StreamSettings = streamSettings;
        }


    }
}
