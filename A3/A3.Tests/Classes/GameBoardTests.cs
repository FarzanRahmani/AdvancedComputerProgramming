using Microsoft.VisualStudio.TestTools.UnitTesting;
using A3.Classes;
using A3.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A3.Classes.Animals;
using A3.Interfaces;

namespace A3Tests.Classes
{
    [TestClass()]
    public class GameBoardTests
    {
        private static IAnimal[] animals = new IAnimal[]
        {
            new Crow("Kalagh 1", 2, 90.5, 23),
            new Frog("GhoorGhoori", 2, 64.3, 33),
            new Partridge("kankak", 5, 26, 100),
            new Snake("MarMari", 32, 45.5, 89), 
        };

        private static GameBoard<IAnimal> _gameBoard = new GameBoard<IAnimal>(animals);

        [TestMethod()]
        public void MoveAnimalsTest()
        {
            //Assert.Inconclusive();

            // Arrange
            string[] expected = new[]
            {
                $"{animals[0].Name} is a {typeof(Crow).Name} and is flying",
                $"{animals[0].Name} is a {typeof(Crow).Name} and can't move in {System.Enum.GetName(typeof(Environment), A3.Enums.Environment.Land)} environment",
                $"{animals[0].Name} is a {typeof(Crow).Name} and can't move in {System.Enum.GetName(typeof(Environment), A3.Enums.Environment.Watery)} environment",
                $"{animals[1].Name} is a {typeof(Frog).Name} and can't move in {System.Enum.GetName(typeof(Environment), A3.Enums.Environment.Air)} environment",
                $"{animals[1].Name} is a {typeof(Frog).Name} and is walking",
                $"{animals[1].Name} is a {typeof(Frog).Name} and is swimming",
                $"{animals[2].Name} is a {typeof(Partridge).Name} and is flying",
                $"{animals[2].Name} is a {typeof(Partridge).Name} and is walking",
                $"{animals[2].Name} is a {typeof(Partridge).Name} and can't move in {System.Enum.GetName(typeof(Environment), A3.Enums.Environment.Watery)} environment",
                $"{animals[3].Name} is a {typeof(Snake).Name} and can't move in {System.Enum.GetName(typeof(Environment), A3.Enums.Environment.Air)} environment",
                $"{animals[3].Name} is a {typeof(Snake).Name} and is crawling",
                $"{animals[3].Name} is a {typeof(Snake).Name} and can't move in {System.Enum.GetName(typeof(Environment), A3.Enums.Environment.Watery)} environment",
            };

            // Act
            List<string> actual = _gameBoard.MoveAnimals().ToList();

            // Assert

            CollectionAssert.AreEqual(expected,actual);
        }
    }
}