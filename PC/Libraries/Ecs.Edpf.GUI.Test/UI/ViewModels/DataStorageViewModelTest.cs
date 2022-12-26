using Ecs.Edpf.Devices.Test.ComponentModel;
using Ecs.Edpf.GUI.ComponentModel;
using Ecs.Edpf.GUI.UI.ViewModels.DataStorage;
using Ecs.Edpf.GUI.UI.ViewModels.DataStorage.StreamViewModelGenerators;
using Ecs.Edpf.GUI.UI.ViewModels.DataStorage.StreamViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.Test.UI.ViewModels
{

    [TestClass]
    public class DataStorageViewModelTest
    {

        private MockDeviceStateMachine _mockDeviceStateMachine;
        private DataStorageViewModel _dataStorageViewModel;


        internal class FakeDataStorageStreamViewModel : IDataStorageStreamViewModel
        {
            public string SuccessCountMessage => throw new NotImplementedException();

            public string FailCountMessage => throw new NotImplementedException();

            public IRelayCommand RecordPauseCommand => throw new NotImplementedException();

            public BindingList<DataStorageStreamLineResult> Results => throw new NotImplementedException();

            public event PropertyChangedEventHandler PropertyChanged;
        }

        internal class FakeDataStorageStreamViewModelGenerator : IDataStorageStreamViewModelGenerator
        {
            public IDataStorageStreamViewModel GetDataStorageStreamViewModel()
            {
                throw new NotImplementedException();
            }
        }


        [TestInitialize]
        public void InitializeTest()
        {
            _mockDeviceStateMachine = new MockDeviceStateMachine();
            _dataStorageViewModel = new DataStorageViewModel(_mockDeviceStateMachine.Object);


            //_dataStorageViewModel.AddDataStreamCommand.

        }




    }
}
