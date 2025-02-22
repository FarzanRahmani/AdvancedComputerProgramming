using Microsoft.VisualStudio.TestTools.UnitTesting;
using A3.Classes.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3Tests.Classes.Animals
{
    [TestClass()]
    public class PartridgeTests
    {
        Partridge partridgA3 = new Partridge("Partridge 1", 22, 44.9, 90.9);
        Partridge partridge2 = new Partridge("Partridge 1", 23, 42.9, 89.9);

        [TestMethod()]
        public void EatFoodTest()
        {
            //Assert.Inconclusive();

            // Arrange
            string partridgA3Expected = $"{partridgA3.Name} is a {typeof(Partridge).Name} and is eating";
            string partridge2Expected = $"{partridge2.Name} is a {typeof(Partridge).Name} and is eating";

            // Act
            string partridgA3Actual = partridgA3.EatFood();
            string partridge2Actual = partridge2.EatFood();

            // Assert
            Assert.AreEqual(partridgA3Expected, partridgA3Actual);
            Assert.AreEqual(partridge2Expected, partridge2Actual);
        }

        [TestMethod()]
        public void ReproductionTest()
        {
            //Assert.Inconclusive();

            // Arrange
            string partridgA3And2Expected =
                $"{partridgA3.Name} is a {typeof(Partridge).Name} and reproductive with {partridge2.Name}";

            // Act
            string partridgA3And2Actual = partridgA3.Reproduction(partridge2);

            // Assert
            Assert.AreEqual(partridgA3And2Expected, partridgA3And2Actual);
        }

        [TestMethod()]
        public void MoveTest()
        {
            //Assert.Inconclusive();

            // Arrange
            Partridge[] partridges = new[] { partridgA3, partridgA3};
            string[] expected = new[]
            {
                $"{partridgA3.Name} is a {typeof(Partridge).Name} and is flying",
                $"{partridgA3.Name} is a {typeof(Partridge).Name} and can't move in {Enum.GetName(typeof(A3.Enums.Environment), A3.Enums.Environment.Watery)} environment",
                $"{partridgA3.Name} is a {typeof(Partridge).Name} and is walking",
                $"{partridge2.Name} is a {typeof(Partridge).Name} and is flying",
                $"{partridge2.Name} is a {typeof(Partridge).Name} and can't move in {Enum.GetName(typeof(A3.Enums.Environment), A3.Enums.Environment.Watery)} environment",
                $"{partridge2.Name} is a {typeof(Partridge).Name} and is walking",
            };
            List<string> actual = new List<string>();

            // Act
            foreach (Partridge partridge in partridges)
            {
                actual.Add(partridge.Move(A3.Enums.Environment.Air));
                actual.Add(partridge.Move(A3.Enums.Environment.Watery));
                actual.Add(partridge.Move(A3.Enums.Environment.Land));
            }

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FlyTest()
        {
            //Assert.Inconclusive();

            // Arrange
            string partridgA3Expected = $"{partridgA3.Name} is a {typeof(Partridge).Name} and is flying";
            string partridge2Expected = $"{partridge2.Name} is a {typeof(Partridge).Name} and is flying";

            // Act
            string partridgA3Actual = partridgA3.Fly();
            string partridge2Actual = partridge2.Fly();

            // Assert
            Assert.AreEqual(partridgA3Expected, partridgA3Actual);
            Assert.AreEqual(partridge2Expected, partridge2Actual);
        }

        [TestMethod()]
        public void WalkTest()
        {
            //Assert.Inconclusive();

            // Arrange
            string partridgA3Expected = $"{partridgA3.Name} is a {typeof(Partridge).Name} and is walking";
            string partridge2Expected = $"{partridge2.Name} is a {typeof(Partridge).Name} and is walking";

            // Act
            string partridgA3Actual = partridgA3.Walk();
            string partridge2Actual = partridge2.Walk();

            // Assert
            Assert.AreEqual(partridgA3Expected, partridgA3Actual);
            Assert.AreEqual(partridge2Expected, partridge2Actual);
        }
    }
}