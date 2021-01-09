using System;
using Ecs.Edpf.Devices.IO.Params;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ecs.Edpf.Devices.Test.IO.Cmds
{
    [TestClass]
    public class BaseCommandTest
    {

        private int _fakeDevCmdIsValidPropertyChanged;
        private void FakeDevCmdPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        [TestInitialize]
        public void InitializeTest()
        {

        }



        [TestMethod]
        public void PropertyChanged_ParameterIsValidRaised_SelfIsRaised()
        {
            _fakeDevCmdIsValidPropertyChanged = 0;
            FakeDeviceCommand fakeDevCmd = new FakeDeviceCommand();

            fakeDevCmd.PropertyChanged += FakeDevCmdPropertyChanged;


            StringParameter strParam = (StringParameter)fakeDevCmd.Parameters[1];

            strParam.SetValue("");



        }


    }
}
