using Ecs.Edpf.Devices.IO.Cmds;
using Ecs.Edpf.Devices.IO.Params;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.Devices.Test.IO.Cmds
{

    [TestClass]
    public class CommandsByDescriptionBuilderTest
    {

        private CommandByDescriptionBuilder _builder;

        [TestInitialize]
        public void InitializeTest()
        {
            _builder = new CommandByDescriptionBuilder();
        }

        // 

        [TestMethod]
        public void GetCommandByDescription_ValidCommand_CommandGotten()
        {

            // -- arrange
            string testCommandDescription = "testCommand {p[0]:(uint8)PinBank,p[1]:(double)AnalogReading}";

            // -- act
            IDeviceCommand deviceCmd = _builder.GetCommandByDescription(testCommandDescription);

            // -- assert
            Assert.AreEqual(expected: "testCommand", actual: deviceCmd.MethodName);

            Assert.AreEqual(expected: 2, actual: deviceCmd.Parameters.Count);

            Assert.AreEqual(expected: "PinBank", deviceCmd.Parameters[0].GetName());
            Assert.AreEqual(expected: typeof(UInt8Parameter), deviceCmd.Parameters[0].GetType());

            Assert.AreEqual(expected: "AnalogReading", deviceCmd.Parameters[1].GetName());
            Assert.AreEqual(expected: typeof(DoubleParameter), deviceCmd.Parameters[1].GetType());


        }

    }
}
