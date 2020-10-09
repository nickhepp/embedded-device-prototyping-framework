using System;
using Ecs.Edpf.Devices.IO;
using Ecs.Edpf.Devices.IO.Params;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ecs.Edpf.Devices.Test.IO
{
    [TestClass]
    public class UInt16ParameterTest
    {
        [TestMethod]
        [DataRow(0, (UInt16)123, "p[0]=123")]
        [DataRow(2, UInt16.MaxValue, "p[2]=65535")]
        public void GetParameterText_Val_CorrectText(int parameterIndex, UInt16 val, string expectedText)
        {
            //-- arrange
            UInt16Parameter uint16Parameter = new UInt16Parameter("fake name", parameterIndex);
            uint16Parameter.Value = val;

            //-- act
            string result = uint16Parameter.GetParameterText();

            //-- assert
            Assert.AreEqual(expectedText, actual: result, "Expected value was not returend.");
        }

    }
}
