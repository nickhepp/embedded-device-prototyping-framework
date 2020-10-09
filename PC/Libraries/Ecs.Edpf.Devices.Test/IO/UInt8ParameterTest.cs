using System;
using Ecs.Edpf.Devices.IO;
using Ecs.Edpf.Devices.IO.Params;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ecs.Edpf.Devices.Test.IO
{
    [TestClass]
    public class UInt8ParameterTest
    {

        [TestMethod]
        [DataRow(0, (byte)1, "p[0]=1")]
        [DataRow(1, (byte)255, "p[1]=255")]
        public void GetParameterText_Val_CorrectText(int parameterIndex, byte val, string expectedText)
        {
            //-- arrange
            UInt8Parameter uint8Parameter = new UInt8Parameter("fake name", parameterIndex);
            uint8Parameter.Value = val;

            //-- act
            string result = uint8Parameter.GetParameterText();

            //-- assert
            Assert.AreEqual(expectedText, actual: result, "Expected value was not returend.");
        }


    }
}
