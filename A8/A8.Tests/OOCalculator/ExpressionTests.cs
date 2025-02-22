using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace A8.OOCalculator.Tests
{
    [TestClass()]
    public class ExpressionTests
    {

        [TestMethod()]
        public void MultiplyOperatorTest()
        {
            string fileName = "MultiplyTest";
            File.WriteAllText(fileName, "2\n3");
            MultiplyOperator multiplyOperator = new MultiplyOperator(File.OpenText(fileName));
            Assert.AreEqual(multiplyOperator.ToString(), "(2*3)");
            Assert.AreEqual(multiplyOperator.Evaluate(), 6);
        }
        [TestMethod()]
        public void AddOperatorTest()
        {
            string fileName = "AddTest";
            File.WriteAllText(fileName, "4\n5");
            AddOperator addOperator = new AddOperator(File.OpenText(fileName));
            Assert.AreEqual(addOperator.ToString(), "(4+5)");
            Assert.AreEqual(addOperator.Evaluate(), 9);
        }
        [TestMethod()]
        public void SubtractOperatorTest()
        {
            string fileName = "SubtractTest";
            File.WriteAllText(fileName, "9\n7");
            SubtractOperator subtractOperator = new SubtractOperator(File.OpenText(fileName));
            Assert.AreEqual(subtractOperator.ToString(), "(9-7)");
            Assert.AreEqual(subtractOperator.Evaluate(), 2);
        }
        [TestMethod()]
        public void DivideOperatorTest()
        {
            string fileName = "DivideTest";
            File.WriteAllText(fileName, "10\n5");
            DivideOperator divideOperator = new DivideOperator(File.OpenText(fileName));
            Assert.AreEqual(divideOperator.ToString(), "(10/5)");
            Assert.AreEqual(divideOperator.Evaluate(), 2);
        }
        [TestMethod()]
        public void SquareOperatorTest()
        {
            string fileName = "SquareTest";
            File.WriteAllText(fileName, "7");
            SquareOperator squareOperator = new SquareOperator(File.OpenText(fileName));
            Assert.AreEqual(squareOperator.ToString(), "Square(7)");
            Assert.AreEqual(squareOperator.Evaluate(), 49);
        }

        [TestMethod()]
        public void NegateOperatorTest()
        {
            string fileName = "NegateTest";
            File.WriteAllText(fileName, "1");
            NegateOperator negateOperator = new NegateOperator(File.OpenText(fileName));
            Assert.AreEqual(negateOperator.ToString(), "-(1)");
            Assert.AreEqual(negateOperator.Evaluate(), -1);
        }
        [TestMethod()]
        public void SqrtOperatorTest()
        {
            string fileName = "SqrtTest";
            File.WriteAllText(fileName, "100");
            SqrtOperator sqrtOperator = new SqrtOperator(File.OpenText(fileName));
            Assert.AreEqual(sqrtOperator.ToString(), "Sqrt(100)");
            Assert.AreEqual(sqrtOperator.Evaluate(), 10);
        }

    }
}
