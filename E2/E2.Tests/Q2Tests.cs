
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace E2.Tests
{
    [TestClass()]
    public class Q2LinqTests
    {
        public Q2ChildMortailityStats mortalityData = new Q2ChildMortailityStats(@"../../../ChildMortality.csv");

        [TestMethod()]
        public void Q21_HighestNeoNatalMortalityYearTest()
        {
            Assert.AreEqual(1989, mortalityData.Q21_HighestNeoNatalMortalityYear);
        }

        [TestMethod()]
        public void Q22_HighestDifferenceBetweenMaleAndFemaleTest()
        {
            Assert.AreEqual(("Côte d'Ivoire", 1955), mortalityData.Q22_HighestDifferenceBetweenMaleAndFemale);
        }

        [TestMethod()]
        public void Q23_CountryWithHighestNeoNatalImprovementTest()
        {
            Assert.AreEqual("Republic of Korea", mortalityData.Q23_CountryWithHighestNeoNatalImprovement);
        }

    }
}
