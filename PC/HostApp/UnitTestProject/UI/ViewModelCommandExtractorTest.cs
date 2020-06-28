using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using HostApp;
using HostApp.UI;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject.UI
{
    [TestClass]
    public class ViewModelCommandExtractorTest
    {
        [TestMethod]
        public void TestGetCommands()
        {
            AppInfo.ViewModelTypeName = "ThinkerBridgePrototypeHostApp.UI.FakeViewModel, ThinkerBridgePrototypeHostApp";
            AppInfo.DeviceTypeName = "ThinkerBridgePrototypeHostApp.Business.BaseDevice, ThinkerBridgePrototypeHostApp";

            IViewModel vwMdl = ViewModelFactory.GetViewModel();

            List<Tuple<string, ICommand>> cmdNameTuples = ViewModelCommandExtractor.GetCommands(vwMdl);

            Assert.AreEqual(nameof(FakeViewModel.TestViewModelCommand), "TestViewModelCommand");
            Assert.AreEqual(nameof(FakeViewModel.TestAnotherViewModelCommand), "TestAnotherViewModelCommand");

            string[] expectedCmds = {"Test", "Test Another"};
            Assert.AreEqual(expectedCmds.Length, cmdNameTuples.Count);

            Assert.IsTrue(cmdNameTuples.Any(param => param.Item1 == "Test"));
            Assert.IsTrue(cmdNameTuples.Any(param => param.Item1 == "Test Another"));
        }

    }

}
