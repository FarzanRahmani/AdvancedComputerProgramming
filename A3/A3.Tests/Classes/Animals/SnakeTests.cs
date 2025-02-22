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
    public class SnakeTests
    {
        Snake snakA3 = new Snake("Snake 1", 45, 64, 69.3);
        Snake snake2 = new Snake("Snake 2", 75, 84, 68.9);

        [TestMethod()]
        public void EatFoodTest()
        {
            //Assert.Inconclusive();

            // Arrange
            string snakA3Expected = $"{snakA3.Name} is a {typeof(Snake).Name} and is eating";
            string snake2Expected = $"{snake2.Name} is a {typeof(Snake).Name} and is eating";

            // Act
            string snakA3Actual = snakA3.EatFood();
            string snake2Actual = snake2.EatFood();

            // Assert
            Assert.AreEqual(snakA3Expected, snakA3Actual);
            Assert.AreEqual(snake2Expected, snake2Actual);
        }

        [TestMethod()]
        public void ReproductionTest()
        {
            //Assert.Inconclusive();

            // Arrange
            string snakA3And2Expected =
                $"{snakA3.Name} is a {typeof(Snake).Name} and reproductive with {snake2.Name}";

            // Act
            string snakA3And2Actual = snakA3.Reproduction(snake2);

            // Assert
            Assert.AreEqual(snakA3And2Expected, snakA3And2Actual);
        }

        [TestMethod()]
        public void MoveTest()
        {
            //Assert.Inconclusive();

            // Arrange
            Snake[] snakes = new[] { snakA3, snake2 };
            string[] expected = new[]
            {
                $"{snakA3.Name} is a {typeof(Snake).Name} and can't move in {Enum.GetName(typeof(A3.Enums.Environment), A3.Enums.Environment.Air)} environment",
                $"{snakA3.Name} is a {typeof(Snake).Name} and can't move in {Enum.GetName(typeof(A3.Enums.Environment), A3.Enums.Environment.Watery)} environment",
                $"{snakA3.Name} is a {typeof(Snake).Name} and is crawling",
                $"{snake2.Name} is a {typeof(Snake).Name} and can't move in {Enum.GetName(typeof(A3.Enums.Environment), A3.Enums.Environment.Air)} environment",
                $"{snake2.Name} is a {typeof(Snake).Name} and can't move in {Enum.GetName(typeof(A3.Enums.Environment), A3.Enums.Environment.Watery)} environment",
                $"{snake2.Name} is a {typeof(Snake).Name} and is crawling",
            };
            List<string> actual = new List<string>();

            // Act
            foreach (Snake snake in snakes)
            {
                actual.Add(snake.Move(A3.Enums.Environment.Air));
                actual.Add(snake.Move(A3.Enums.Environment.Watery));
                actual.Add(snake.Move(A3.Enums.Environment.Land));
            }

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CrawlTest()
        {
            //Assert.Inconclusive();

            // Arrange
            string snakA3Expected = $"{snakA3.Name} is a {typeof(Snake).Name} and is crawling";
            string snake2Expected = $"{snake2.Name} is a {typeof(Snake).Name} and is crawling";

            // Act
            string snakA3Actual = snakA3.Crawl();
            string snake2Actual = snake2.Crawl();

            // Assert
            Assert.AreEqual(snakA3Expected, snakA3Actual);
            Assert.AreEqual(snake2Expected, snake2Actual);
        }
    }
}