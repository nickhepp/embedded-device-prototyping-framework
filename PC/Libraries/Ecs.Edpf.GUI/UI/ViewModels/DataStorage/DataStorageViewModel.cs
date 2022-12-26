using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.ComponentModel;
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

        private RelayCommand _addDataStreamCommand;
        public ICommand AddDataStreamCommand => _addDataStreamCommand;

        public BindingList<IDataStorageStreamViewModel> StreamViewModels { get; } = new BindingList<IDataStorageStreamViewModel>();

        public DataStorageViewModel(IDeviceStateMachine deviceStateMachine) : base(deviceStateMachine)
        {

            _addDataStreamCommand = new RelayCommand(
                canExecute: AddDataStreamCommandCanExecute,
                execute: AddDataStreamCommandExecute);


        }

        private bool AddDataStreamCommandCanExecute(object args)
        {
            return true;
        }

        private void AddDataStreamCommandExecute(object args)
        {
            if (args.GetType() is IDataStorageStreamViewModelGenerator viewModelGenerator)
            {
                IDataStorageStreamViewModel streamViewModel = viewModelGenerator.GetDataStorageStreamViewModel();

            }
            else
            {
                throw new ArgumentException(AddDataStreamCommandExecute_NotCorrectTypeMessage);
            }
        }

        // TODO: unit test cant add stream with the same name -- throws exception instead




    }
}
