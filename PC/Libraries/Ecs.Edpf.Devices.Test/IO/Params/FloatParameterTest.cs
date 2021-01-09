using System;
using Ecs.Edpf.Devices.IO;
using Ecs.Edpf.Devices.IO.Params;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ecs.Edpf.Devices.Test.IO.Params
{
    [TestClass]
    public class FloatParameterTest
    {
        [TestMethod]
        [DataRow(0, 123.56, "0.000", "p[0]=123.560")]
        [DataRow(2, -987d, "0.0", "p[2]=-987.0")]
        public void GetParameterText_Val_CorrectText(int parameterIndex, double val, string formatString, string expectedText)
        {
            //-- arrange
            FloatParameter floatParameter = new FloatParameter("fake name", parameterIndex, formatStr: formatString);
            floatParameter.Value = val;

            //-- act
            string result = floatParameter.GetParameterText();

            //-- assert
            Assert.AreEqual(expectedText, actual: result, "Expected value was not returend.");
        }
    }
}
