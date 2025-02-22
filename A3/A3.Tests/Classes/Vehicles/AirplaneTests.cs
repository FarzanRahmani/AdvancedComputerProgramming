using Microsoft.VisualStudio.TestTools.UnitTesting;
using A3.Classes.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3Tests.Classes.Vehicles
{
    [TestClass()]
    public class AirplaneTests
    {
        Airplane airplane = new Airplane(1000, "C130");

        [TestMethod()]
        public void FlyTest()
        {
            //Assert.Inconclusive();

            // Arrange
            string expected = $"{airplane.Model} with {airplane.SpeedRate} speed rate is flying";

            // Act
            string actual = airplane.Fly();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}