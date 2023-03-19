using Ecs.Edpf.Data.DataStreams;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecs.Edpf.Data.Test
{

    [TestClass]
    public class DataStreamExpressionFilterTest
    {

        private DataStreamExpressionFilter _dataStreamExpressionFilter;

        [TestInitialize]
        public void InitializeTest()
        {
        }


        [DataTestMethod]
        [DataRow(":{val1},{val2}")]                 // no val_prefix name
        [DataRow("valprefix:{val1}{val2}")]         // missing comma
        [DataRow("valprefix:")]                     // no values
        [DataRow("valprefix:{VAL1},{val1}")]        // not distinct names
        public void Create_InvalidExpression_ExceptionThrown(string invalidExpression)
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                _dataStreamExpressionFilter = new DataStreamExpressionFilter(invalidExpression);
            },
            $"Invalid expression ({invalidExpression}) should throw an expression.");
        }

        [TestMethod]
        public void Create_ValidExperession_PrefixDetermined()
        {
            // arrange
            string expression = "val_prefix:{val1},{val2}";

            // act
            _dataStreamExpressionFilter = new DataStreamExpressionFilter(expression);

            // assert
            Assert.AreEqual(
                expected: "val_prefix", 
                actual: _dataStreamExpressionFilter.ValuesPrefix,
                message: "The expected val prefix was not found.");
        }

        [TestMethod]
        public void Create_ValidExperession_ValueNamesDetermined()
        {
            // arrange
            string expression = "val_prefix:{val1},{val2}";
            List<string> expectedValNames = new List<string> { "val1", "val2" };

            // act
            _dataStreamExpressionFilter = new DataStreamExpressionFilter(expression);

            // assert
            Assert.IsTrue(
                condition: Enumerable.SequenceEqual(expectedValNames, _dataStreamExpressionFilter.ValueNames),
                message: "The expected value names were not found.");
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("val_prefix 45,45,45")]        // wrong number of args
        [DataRow("not_val_prefix 45,45")]       // wrong value prefix
        [DataRow("val_prefix 45,sssss")]        // correct number of vals, but 1 is not a number
        public void GetResults_InvalidLines_NullReturned(string invalidLine)
        {
            // arrange
            string expression = "val_prefix:{val1},{val2}";
            _dataStreamExpressionFilter = new DataStreamExpressionFilter(expression);

            // act
            LineResultsSet resultsSet = _dataStreamExpressionFilter.GetResults(invalidLine);

            // assert
            Assert.IsNull(resultsSet, "Invalid data lines should return null.");
        }

        [TestMethod]
        public void GetResults_ValidLine_ValuesReturned()
        {
            // arrange
            string expression = "val_prefix:{val1},{val2}";
            _dataStreamExpressionFilter = new DataStreamExpressionFilter(expression);

            // act
            LineResultsSet resultsSet = _dataStreamExpressionFilter.GetResults("val_prefix 12,34");

            // assert
            Assert.IsNotNull(resultsSet, "Valid data lines should return not null.");

            Assert.AreEqual(
                expected: 2,
                actual: resultsSet.Count,
                message: "Should get back two results.");

            LineResult val1Result = resultsSet.FirstOrDefault(result => result.ValueName == "val1");
            Assert.IsNotNull(val1Result, "'val1' should be retrievable by name.");
            Assert.AreEqual(expected: 12, actual: (float)val1Result.Value, delta: 0.01,
                "'val1' was not the expected value.");

            LineResult val2Result = resultsSet.FirstOrDefault(result => result.ValueName == "val2");
            Assert.IsNotNull(val2Result, "'val2' should be retrievable by name.");
            Assert.AreEqual(expected: 34, actual: (float)val2Result.Value, delta: 0.01,
                "'val2' was not the expected value.");
        }

    }
}