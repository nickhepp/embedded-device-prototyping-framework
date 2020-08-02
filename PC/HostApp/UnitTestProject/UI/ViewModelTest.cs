using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using HostApp.UI;
using HostApp;
using HostApp.UI.ChildUI;

namespace UnitTestProject.UI
{
    [TestClass]
    public class ViewModelTest
    {


        //public class ConnectionViewModel : HostApp.UI.ChildUI.ViewModels.BaseConnectionViewModel
        //{
        //    private bool _openCanExecute;

        //    public ConnectionViewModel() 
        //    {
        //    }

        //    public bool OpenCanExecute
        //    {
        //        get
        //        {
        //            return _openCanExecute;
        //        }
        //        set
        //        {
        //            _openCanExecute = value;
        //        }
        //    }


        //    protected override bool OpenConnectionCommandCanExecute(object obj)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}







        [TestMethod]
        public void TestOpenClosedButtonEnabled()
        {

            //AppInfo.ViewModelTypeName = "ThinkerBridgePrototypeHostApp.UI.FakeViewModel, ThinkerBridgePrototypeHostApp";
            //AppInfo.DeviceTypeName = "ThinkerBridgePrototypeHostApp.Business.BaseDevice, ThinkerBridgePrototypeHostApp"; 

            //IViewModel vwMdl = ViewModelFactory.GetViewModel();
            //Assert.IsTrue(vwMdl.OpenButtonEnabled);
            //Assert.IsFalse(vwMdl.CloseButtonEnabled);

            //Assert.IsTrue(vwMdl.OpenCommand.CanExecute(null));
            //Assert.IsFalse(vwMdl.CloseCommand.CanExecute(null));

            //vwMdl.OpenCommand.Execute(null);

            //Assert.IsFalse(vwMdl.OpenButtonEnabled);
            //Assert.IsTrue(vwMdl.CloseButtonEnabled);

            //Assert.IsFalse(vwMdl.OpenCommand.CanExecute(null));
            //Assert.IsTrue(vwMdl.CloseCommand.CanExecute(null));

        }
    }
}
