using System;
using Ecs.Edpf.Devices.IO;
using Ecs.Edpf.Devices.IO.Params;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ecs.Edpf.Devices.Test.IO
{
    [TestClass]
    public class BoolParameterTest
    {

        [TestMethod]
        [DataRow(2, true, "p[2]=1")]
        [DataRow(3, false, "p[3]=0")]
        public void GetParameterText_Val_CorrectText(int parameterIndex, bool val, string expectedText)
        {
            //-- arrange
            BoolParameter boolParameter = new BoolParameter("fake name", parameterIndex);
            boolParameter.Value = val;

            //-- act
            string result = boolParameter.GetParameterText();

            //-- assert
            Assert.AreEqual(expectedText, actual: result, "Expected value was not returend.");
        }



    }
}
