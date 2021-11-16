using Ecs.Edpf.Devices.Charting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.Devices.Test.Charting
{
    [TestClass]
    public class SimpleChartingExpressionFilterTest
    {


        private SimpleChartingExpressionFilter _simpleChartExpressionFilter;

        [TestInitialize]
        public void InitializeTest()
        {
            _simpleChartExpressionFilter = new SimpleChartingExpressionFilter();
        }


        [TestMethod]
        public void GetSeriesNames_FilterHasSeriesNames_SeriesNamesGotten()
        {
            //-- arrange
            _simpleChartExpressionFilter.Expression = "vals:{a|ch1},{b|ch2},{c|ch3}";

            //-- act
            List<string> valueNames = _simpleChartExpressionFilter.GetSeriesNames();

            //-- assert
            Assert.AreEqual(expected: 3, valueNames.Count);
            Assert.IsNotNull(valueNames.SingleOrDefault(testValue => testValue == "a"));
            Assert.IsNotNull(valueNames.SingleOrDefault(testValue => testValue == "b"));
            Assert.IsNotNull(valueNames.SingleOrDefault(testValue => testValue == "c"));
        }



        [TestMethod]
        public void GetChartPoints_LineHasPoints_PointsGotten()
        {
            //-- arrange
            _simpleChartExpressionFilter.Expression = "vals:{a|chart1},{b|chart1},{c|chart1}";
            string lineWithPoints = "vals:45.32,32.98,10.01";

            //-- act
            Dictionary<string, double> valDict = _simpleChartExpressionFilter.GetChartPoints(lineWithPoints);

            //-- assert
            Assert.AreEqual(expected: 45.32, actual: valDict["a"]);
            Assert.AreEqual(expected: 32.98, actual: valDict["b"]);
            Assert.AreEqual(expected: 10.01, actual: valDict["c"]);
        }


        [DataTestMethod]
        [DataRow("vals:45.1,45.1,45.1,45.1,45.1,45.1")]     // line with too many values
        [DataRow("vals:45.1,45.1")]                         // line with too few number
        [DataRow("vals:45.1,45.1,")]                        // line missing a number
        [DataRow("vals:a,45.1,45.1")]                       // line with a non-number
        public void GetChartPoints_LineDoesntHavePoints_NullReturned(string line)
        {
            //-- arrange
            _simpleChartExpressionFilter.Expression = "vals:{a|chart1},{b|chart1},{c|chart2}";

            //-- act
            Dictionary<string, double> valDict = _simpleChartExpressionFilter.GetChartPoints(line);

            //-- assert
            Assert.IsNull(valDict);
        }


    }
}
