using Ecs.Edpf.Data;
using Ecs.Edpf.Devices.Test.ComponentModel;
using Ecs.Edpf.Devices.Test.Logging;
using Ecs.Edpf.GUI.UI.ViewModels.DataStorage;
using Ecs.Edpf.GUI.UI.ViewModels.DataStorage.StreamViewModelGenerators;
using Ecs.Edpf.GUI.UI.ViewModels.DataStorage.StreamViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.Test.UI.ViewModels.DataStorage
{
    [TestClass]
    public class DataStorageViewModelTest
    {

        private FakeLogger _fakeLogger;
        private DataStorageViewModel _dataStorageViewMdl;
        private MockDeviceStateMachine _mockDeviceStateMachine;

        internal class FakeDataStorageStreamViewModel : Mock<IDataStorageStreamViewModel>
        {

            internal FakeDataStorageStreamViewModel(string dataStreamName)
            {
                this.SetupGet(dsStrmVwMdl => dsStrmVwMdl.DataStreamName).Returns(dataStreamName);
            }


        }

        internal class FakeDataStorageStreamViewModelGenerator : BaseDataStorageStreamViewModelGenerator
        {
            private readonly string _dataStreamName;

            internal FakeDataStorageStreamViewModelGenerator(string dataStreamName)
            {
                _dataStreamName = dataStreamName;
            }
            protected override IDataStorageStreamViewModel InternalGetDataStorageStreamViewModel()
            {
                FakeDataStorageStreamViewModel fakeDataStorageVwMdl = new FakeDataStorageStreamViewModel(_dataStreamName);
                return fakeDataStorageVwMdl.Object;
            }
        }


        [TestInitialize]
        public void InitializeTest()
        {
            _fakeLogger = new FakeLogger();
            _mockDeviceStateMachine = new MockDeviceStateMachine();

            _dataStorageViewMdl = new DataStorageViewModel(
                _fakeLogger.Object,
                _mockDeviceStateMachine.Object);
        }

        private void AddDataStream(string dataStreamName)
        {
            FakeDataStorageStreamViewModelGenerator fakeVwMdlGenerator = new FakeDataStorageStreamViewModelGenerator(dataStreamName);
            _dataStorageViewMdl.AddDataStreamCommand.Execute(fakeVwMdlGenerator);
        }


        [TestMethod]
        public void RemoveDataStreamsCommandCanExecute_DataStreamsExist_True()
        {
            // arrange

            // act
            AddDataStream("stream1");

            // assert
            Assert.IsTrue(_dataStorageViewMdl.RemoveDataStreamsCommand.CanExecute(null),
                "When data streams exist we should be able to remove them.");
        }

        [TestMethod]
        public void RemoveDataStreamsCommandCanExecute_DataStreamsDontExist_False()
        {
            // arrange

            // act

            // assert
            Assert.IsFalse(_dataStorageViewMdl.RemoveDataStreamsCommand.CanExecute(null),
                "When data streams dont exist we should not be able to remove them.");
        }

        [TestMethod]
        public void RemoveDataStreamsCommandExecute_StreamsRemoved_StreamCountsUpdated()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void RecordAllStreamsCommandExecute_StreamsSetToRecord_StreamCountsUpdated()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void PauseAllStreamsCommandExecute_StreamsSetToPause_StreamCountsUpdated()
        {
            throw new NotImplementedException();
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void AddDataStreamCommandExecute_StreamWithSameNameAdded_ExceptionThrown()
        {

        }

    }
}
