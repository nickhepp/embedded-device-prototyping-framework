using Ecs.Edpf.Data.DataStreams;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.Data.Test.DataStreams
{

    [TestClass]
    public class LineValueDescriptionTest
    {
        private LineValueDescription _lineValDesc;


        [TestInitialize]
        public void InitializeTest()
        {
            _lineValDesc = new LineValueDescription();
        }


        [TestMethod]
        public void GetIsValid_NameValid_True()
        {
            // -- arrange
            _lineValDesc.ValueName = "NothingButLetters";

            // -- act
            bool actualIsValue = _lineValDesc.GetIsValid();

            // -- assert
            Assert.IsTrue(actualIsValue, "Valid name should return True.");
        }

        [DataTestMethod]
        [DataRow("4InvalidWithNumbers")]
        [DataRow("Invalid5WithNumbers")]
        [DataRow("$$SpecialChars")]
        [DataRow("Has Space")]
        public void GetIsValid_InvalidValueName_False(string invalidValueName)
        {
            // -- arrange
            _lineValDesc.ValueName = invalidValueName;
        
            // -- act
            bool actualIsValue = _lineValDesc.GetIsValid();

            // -- assert
            Assert.IsFalse(actualIsValue, "Invalid name should return False.");
        }




    }
}
