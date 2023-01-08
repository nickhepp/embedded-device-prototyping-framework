using Ecs.Edpf.GUI.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.StreamViewModels
{
    public interface IDataStorageStreamViewModel : INotifyPropertyChanged
    {

        string DataStreamName { get; }

        string SuccessCountMessage { get; }

        string FailCountMessage { get; }

        StreamState State { get; }

        IRelayCommand RecordPauseCommand { get; }

        BindingList<DataStorageStreamLineResult> Results { get; }


    }
}
