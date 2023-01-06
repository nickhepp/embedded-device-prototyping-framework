using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.ComponentModel;
using Ecs.Edpf.Devices.Logging;
using Ecs.Edpf.GUI.ComponentModel;
using Ecs.Edpf.GUI.UI.ViewModels.DataStorage.StreamViewModelGenerators;
using Ecs.Edpf.GUI.UI.ViewModels.DataStorage.StreamViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage
{
    public class DataStorageViewModel : BaseDeviceViewModel, IDataStorageViewModel
    {

        public const string AddDataStreamCommandExecute_NotCorrectTypeMessage = "Incorrect type supplied to the AddDataStreamCommandExecute method.";
        private readonly ILogger _logger;

        public BindingList<IDataStorageStreamViewModel> StreamViewModels { get; } = new BindingList<IDataStorageStreamViewModel>();

        private int _streamsPausedCount;
        public int StreamsPausedCount
        {
            get
            {
                return _streamsPausedCount;
            }
            set
            {
                _streamsPausedCount = value;
                RaiseNotifyPropertyChanged();
            }
        }

        private int _streamsRunningCount;
        public int StreamsRunningCount
        {
            get
            {
                return _streamsRunningCount;
            }
            set
            {
                _streamsRunningCount = value;
                RaiseNotifyPropertyChanged();
            }
        }

        private RelayCommand _addDataStreamCommand;
        public ICommand AddDataStreamCommand => _addDataStreamCommand;

        private RelayCommand _removeDataStreamsCommand;
        public ICommand RemoveDataStreamsCommand => _removeDataStreamsCommand;
        
        private RelayCommand _recordAllStreamsCommand;
        public ICommand RecordAllStreamsCommand => _recordAllStreamsCommand;

        private RelayCommand _pauseAllStreamsCommand;
        public ICommand PauseAllStreamsCommand => _pauseAllStreamsCommand;

        public DataStorageViewModel(ILogger logger, IDeviceStateMachine deviceStateMachine) : base(deviceStateMachine)
        {

            _addDataStreamCommand = new RelayCommand(
                canExecute: AddDataStreamCommandCanExecute,
                execute: AddDataStreamCommandExecute);

            _removeDataStreamsCommand = new RelayCommand(
                canExecute: RemoveDataStreamsCommandCanExecute,
                execute: RemoveDataStreamsCommandExecute);

            _recordAllStreamsCommand = new RelayCommand(
                canExecute: RecordAllStreamsCommandCanExecute,
                execute: RecordAllStreamsCommandExecute
                );

            _pauseAllStreamsCommand = new RelayCommand(
                canExecute: PauseAllStreamsCommandCanExecute,
                execute: PauseAllStreamsCommandExecute);

            _logger = logger;
        }

        // ---------- AddDataStreamCommand

        private bool AddDataStreamCommandCanExecute(object args)
        {
            return true;
        }

        private void AddDataStreamCommandExecute(object args)
        {
            if (args.GetType() is IDataStorageStreamViewModelGenerator viewModelGenerator)
            {
                IDataStorageStreamViewModel streamViewModel = viewModelGenerator.GetDataStorageStreamViewModel(_logger);
                StreamViewModels.Add(streamViewModel);
            }
            else
            {
                throw new ArgumentException(AddDataStreamCommandExecute_NotCorrectTypeMessage);
            }
        }

        // ---------- RemoveDataStreamsCommand
        private bool RemoveDataStreamsCommandCanExecute(object args)
        {
            return true;
            // TODO: test this is only TRUE when streams exist

        }
        private void RemoveDataStreamsCommandExecute(object args)
        {
            // TODO: unit test removes streams

        }

        // ---------- RecordAllStreamsCommand
        private bool RecordAllStreamsCommandCanExecute(object args)
        {
            return true;
        }

        private void RecordAllStreamsCommandExecute(object args)
        {
            // TODO: unit test record all streams

        }

        // ---------- PauseAllStreamsCommand
        private bool PauseAllStreamsCommandCanExecute(object args)
        {
            return true;
        }

        private void PauseAllStreamsCommandExecute(object args)
        {

            // TODO: unit test pauses all streams
        }
            
        // TODO: unit test cant add stream with the same name -- throws exception instead




        }
    }
