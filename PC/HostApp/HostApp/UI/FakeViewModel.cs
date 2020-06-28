using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using HostApp.ComponentModel;

namespace HostApp.UI
{
    public class FakeViewModel : BaseViewModel
    {

        // Instructions: For each view model we need 3 parts.

        // Part 1: A command.  Name this what you want to show up on the button minus the "ViewModelCommand" part.
        //private ICommand _exampleViewModelCommand;
        //ICommand ExampleViewModelCommand { get; }

        public int TestCommandHandlerCallCount { get; private set; } = 0;
        public int TestAnotherCommandHandlerCallCount { get; private set; } = 0;

        private ICommand _testViewModelCommand;
        [Browsable(false)]
        public ICommand TestViewModelCommand
        {
            get
            {
                return _testViewModelCommand;
            }
        }

        private ICommand _testAnotherViewModelCommand;
        [Browsable(false)]
        public ICommand TestAnotherViewModelCommand
        {
            get
            {
                return _testAnotherViewModelCommand;
            }
        }

        public FakeViewModel()
        {
            // Part 2: Create the command like so.
            //_exampleCommand = new RelayCommand(param => true, ExampleCommandHandler);

            _testViewModelCommand = new RelayCommand(param => true, TestCommandHandler);
            _testAnotherViewModelCommand = new RelayCommand(param => true, TestAnotherCommandHandler);
        }


        // Part 3: Create a function that runs when the button is pressed.
        //private void ExampleCommandHandler(object arg)
        //{
        //    // do stuff here...
        //}


        private void TestCommandHandler(object arg)
        {
            TestCommandHandlerCallCount++;
        }

        private void TestAnotherCommandHandler(object arg)
        {
            TestAnotherCommandHandlerCallCount++;
        }


    }
}
