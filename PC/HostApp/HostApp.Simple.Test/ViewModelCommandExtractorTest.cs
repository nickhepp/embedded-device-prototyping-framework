using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using Ecs.Edpf.GUI.UI.ViewModels;
using Ecs.Edpf.GUI.ComponentModel;
using HostApp.Simple;

namespace HostApp.Simple.Test
{

    [TestClass]
    public class ViewModelCommandExtractorTest
    {

        public class TestViewModel : IViewModel
        {

            private ICommand _testViewModelCommand;
            public ICommand TestViewModelCommand
            {
                get
                {
                    return _testViewModelCommand;
                }
            }

            private ICommand _testAnotherViewModelCommand;


            public ICommand TestAnotherViewModelCommand
            {
                get
                {
                    return _testAnotherViewModelCommand;
                }
            }

            public int TestCommandHandlerCallCount { get; private set; } = 0;
            public int TestAnotherCommandHandlerCallCount { get; private set; } = 0;

            public TestViewModel()
            {
                _testViewModelCommand = new RelayCommand(param => true, TestCommandHandler);
                _testAnotherViewModelCommand = new RelayCommand(param => true, TestAnotherCommandHandler);
            }

            public event PropertyChangedEventHandler PropertyChanged;

            private void TestCommandHandler(object arg)
            {
                TestCommandHandlerCallCount++;
            }

            private void TestAnotherCommandHandler(object arg)
            {
                TestAnotherCommandHandlerCallCount++;
            }

        }


        [TestMethod]
        public void TestGetCommands()
        {
            //-- arrange
            TestViewModel testVwMdl = new TestViewModel();
            ViewModelCommandExtractor commandExtractor = new ViewModelCommandExtractor();


            //-- act
            List<Tuple<string, ICommand>> cmdNameTuples = commandExtractor.GetCommands(testVwMdl);

            //-- assert
            Assert.AreEqual(nameof(TestViewModel.TestViewModelCommand), "TestViewModelCommand");
            Assert.AreEqual(nameof(TestViewModel.TestAnotherViewModelCommand), "TestAnotherViewModelCommand");

            string[] expectedCmds = { "Test", "Test Another" };
            Assert.AreEqual(expectedCmds.Length, cmdNameTuples.Count);

            Assert.IsTrue(cmdNameTuples.Any(param => param.Item1 == "Test"));
            Assert.IsTrue(cmdNameTuples.Any(param => param.Item1 == "Test Another"));
        }

    }

}
