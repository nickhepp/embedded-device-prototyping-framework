using System;
using Ecs.Edpf.Devices.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ecs.Edpf.Devices.Test.IO
{
    [TestClass]
    public class UInt32ParameterTest
    {
        [TestMethod]
        [DataRow(0, (UInt32)123, "p[0]=123")]
        [DataRow(2, UInt32.MaxValue, "p[2]=4294967295")]
        public void GetParameterText_Val_CorrectText(int parameterIndex, UInt32 val, string expectedText)
        {
            //-- arrange
            UInt32Parameter uint32Parameter = new UInt32Parameter("fake name", parameterIndex);
            uint32Parameter.Value = val;

            //-- act
            string result = uint32Parameter.GetParameterText();

            //-- assert
            Assert.AreEqual(expectedText, actual: result, "Expected value was not returend.");
        }
    }
}
