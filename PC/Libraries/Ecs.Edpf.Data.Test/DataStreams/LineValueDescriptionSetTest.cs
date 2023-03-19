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
    public class LineValueDescriptionSetTest
    {
        private LineValueDescriptionSet _lineValDescSet;

        [TestInitialize]
        public void InitializeTest()
        {
            _lineValDescSet = new LineValueDescriptionSet();
        }


        [TestMethod]
        public void GetIsValid_NoValues_False()
        {
            // -- arrange
            // no values whatsoever

            // -- act
            bool actualIsValid = _lineValDescSet.GetIsValid();

            // -- assert
            Assert.IsFalse(actualIsValid, "No values means it should be invalid.");

        }

        [TestMethod]
        public void GetIsValid_ValidVals_True()
        {
            // -- arrange
            _lineValDescSet.Add(new LineValueDescription { ValueName = "valone" });
            _lineValDescSet.Add(new LineValueDescription { ValueName = "valtwo" });

            // -- act
            bool actualIsValid = _lineValDescSet.GetIsValid();

            // -- assert
            Assert.IsTrue(actualIsValid, "Valid multiple LineValueDescriptions should be valid.");
        }



        // values have different names
        [TestMethod]
        public void GetIsValid_SameNames_False()
        {
            // -- arrange
            string sameName = "samename";
            _lineValDescSet.Add(new LineValueDescription { ValueName = sameName });
            _lineValDescSet.Add(new LineValueDescription { ValueName = sameName });

            // -- act
            bool actualIsValid = _lineValDescSet.GetIsValid();

            // -- assert
            Assert.IsFalse(actualIsValid, "Multiple values with the same name should return false.");
        }

    }
}
