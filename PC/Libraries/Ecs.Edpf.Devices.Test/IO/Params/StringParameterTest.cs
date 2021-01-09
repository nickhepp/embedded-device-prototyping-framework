using System;
using Ecs.Edpf.Devices.IO.Params;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ecs.Edpf.Devices.Test.IO.Params
{
    [TestClass]
    public class StringParameterTest
    {

        private int _strParameterPropertyChanged = 0;
        private void StrParameterPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            _strParameterPropertyChanged++;
        }



        [TestMethod]
        [DataRow(0, "val1", "p[0]=val1")]
        [DataRow(2, "val2", "p[2]=val2")]
        public void GetParameterText_Val_CorrectText(int parameterIndex, string val, string expectedText)
        {
            //-- arrange
            StringParameter strParameter = new StringParameter("fake name", parameterIndex, "");
            strParameter.Value = val;

            //-- act
            string result = strParameter.GetParameterText();

            //-- assert
            Assert.AreEqual(expectedText, actual: result, "Expected value was not returend.");
        }


        [TestMethod]
        public void IsValid_ValueCleared_NotValid()
        {
            //-- arrange
            StringParameter strParameter = new StringParameter("fake name", 0, "good value");

            //-- act
            strParameter.Value = null;

            //-- assert
            Assert.AreEqual(expected: false, actual: strParameter.IsValid);
        }

        [TestMethod]
        public void IsValid_ValueCleared_PropertyChanged()
        {
            //-- arrange
            _strParameterPropertyChanged = 0;
            StringParameter strParameter = new StringParameter("fake name", 0, "good value");
            strParameter.PropertyChanged += StrParameterPropertyChanged;

            //-- act
            strParameter.Value = null;

            //-- assert
            Assert.AreEqual(expected: 1, actual: _strParameterPropertyChanged);
        }

    }
}
