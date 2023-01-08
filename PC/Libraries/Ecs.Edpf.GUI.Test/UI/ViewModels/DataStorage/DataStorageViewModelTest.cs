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
using System.ComponentModel;
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

            internal FakeDataStorageStreamViewModel(string dataStreamName, StreamState state)
            {
                SetupGet(dsStrmVwMdl => dsStrmVwMdl.DataStreamName).Returns(dataStreamName);
                SetupGet(dsStrmVwMdl => dsStrmVwMdl.State).Returns(state);
            }

            internal void ChangeStreamState_RaisePropertyChanged(StreamState streamState)
            {
                SetupGet(dsStrmVwMdl => dsStrmVwMdl.State).Returns(streamState);
                Raise(dsStrmVwMdl => dsStrmVwMdl.PropertyChanged += null,
                    new PropertyChangedEventArgs(nameof(IDataStorageStreamViewModel.State)));
            }

        }

        internal class FakeDataStorageStreamViewModelGenerator : BaseDataStorageStreamViewModelGenerator
        {

            private IDataStorageStreamViewModel _dataStrmVwMdl;
            public IDataStorageStreamViewModel DataStorageStreamViewModel => _dataStrmVwMdl;

            private FakeDataStorageStreamViewModel _fakeDataStorageVwMdl;
            public FakeDataStorageStreamViewModel FakeDataStorageStreamViewModel => _fakeDataStorageVwMdl;

            internal FakeDataStorageStreamViewModelGenerator(string dataStreamName,StreamState state)
            {
                _fakeDataStorageVwMdl = new FakeDataStorageStreamViewModel(dataStreamName, state);
                _dataStrmVwMdl = _fakeDataStorageVwMdl.Object;
            }
            protected override IDataStorageStreamViewModel InternalGetDataStorageStreamViewModel()
            {
                return _dataStrmVwMdl;
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

        private FakeDataStorageStreamViewModelGenerator AddDataStream(string dataStreamName, StreamState state)
        {
            FakeDataStorageStreamViewModelGenerator fakeVwMdlGenerator = 
                new FakeDataStorageStreamViewModelGenerator(dataStreamName, state);
            _dataStorageViewMdl.AddDataStreamCommand.Execute(fakeVwMdlGenerator);
            return fakeVwMdlGenerator;
        }


        [TestMethod]
        public void RemoveDataStreamsCommandCanExecute_DataStreamsExist_True()
        {
            // arrange

            // act
            AddDataStream("stream1", StreamState.Paused);

            // assert
            Assert.IsTrue(_dataStorageViewMdl.RemoveDataStreamsCommand.CanExecute(null),
                "When data streams exist we should be able to remove them.");
        }

        [TestMethod]
        public void XxxDataStreamsCommandCanExecute_DataStreamsDontExist_False()
        {
            // arrange

            // act

            // assert
            Assert.IsFalse(_dataStorageViewMdl.RemoveDataStreamsCommand.CanExecute(null),
                "When data streams dont exist we should not be able to remove them.");

            Assert.IsFalse(_dataStorageViewMdl.PauseAllStreamsCommand.CanExecute(null),
                "When data streams dont exist we should not be able to pause them.");

            Assert.IsFalse(_dataStorageViewMdl.RecordAllStreamsCommand.CanExecute(null),
                "When data streams dont exist we should not be able to record them.");
        }

        [TestMethod]
        public void RemoveDataStreamsCommandExecute_StreamsAdded_StreamCountsUpdated()
        {
            // arrange

            // act
            IDataStorageStreamViewModel strmVwMdl1 = AddDataStream("stream1", StreamState.Paused).DataStorageStreamViewModel;
            IDataStorageStreamViewModel strmVwMdl2 = AddDataStream("stream2", StreamState.Paused).DataStorageStreamViewModel;
            IDataStorageStreamViewModel strmVwMdl3 = AddDataStream("stream3", StreamState.Running).DataStorageStreamViewModel;

            // assert
            Assert.AreEqual(expected: 2, _dataStorageViewMdl.StreamsPausedCount);
            Assert.AreEqual(expected: 1, _dataStorageViewMdl.StreamsRunningCount);
        }


        [TestMethod]
        public void RemoveDataStreamsCommandExecute_StreamsRemoved_StreamCountsUpdated()
        {
            // arrange
            IDataStorageStreamViewModel strmVwMdl1 = AddDataStream("stream1", StreamState.Paused).DataStorageStreamViewModel;
            IDataStorageStreamViewModel strmVwMdl2 = AddDataStream("stream2", StreamState.Paused).DataStorageStreamViewModel;
            IDataStorageStreamViewModel strmVwMdl3 = AddDataStream("stream3", StreamState.Running).DataStorageStreamViewModel;

            // act
            _dataStorageViewMdl.RemoveDataStreamsCommand.Execute(new List<IDataStorageStreamViewModel> { strmVwMdl1 });

            // assert
            Assert.AreEqual(expected: 1, _dataStorageViewMdl.StreamsPausedCount);
            Assert.AreEqual(expected: 1, _dataStorageViewMdl.StreamsRunningCount);
        }

        [DataTestMethod]
        [DataRow(StreamState.Paused, StreamState.Running, 0, 1)]
        [DataRow(StreamState.Running, StreamState.Paused, 1, 0)]
        public void RecordAllStreamsCommandExecute_StreamStartsInOneState_StateChangesAndCountsUpdated(
            StreamState initialState, StreamState nextState, int expectedPausedCount, int expectedRunningCount)
        {
            // arrange
            FakeDataStorageStreamViewModel dataStreamVwMdl = AddDataStream("stream1", initialState).FakeDataStorageStreamViewModel;

            // act
            dataStreamVwMdl.ChangeStreamState_RaisePropertyChanged(nextState);

            // assert
            Assert.AreEqual(expected: expectedPausedCount, 
                actual: _dataStorageViewMdl.StreamsPausedCount,
                $"Expected {expectedPausedCount} stream paused.");

            Assert.AreEqual(expected: expectedRunningCount,
                actual: _dataStorageViewMdl.StreamsRunningCount,
                $"Expected {expectedRunningCount} stream running.");
        }

        [TestMethod]
        public void AddDataStreamCommandExecute_StreamWithSameNameAdded_ExceptionThrown()
        {
            // arrange
            string commonStreamName = "stream1";
            AddDataStream(commonStreamName, StreamState.Running);

            // act, assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                AddDataStream(commonStreamName, StreamState.Running);
            },
            "Adding stream of same name should throw an exception.");
        }

    }
}
