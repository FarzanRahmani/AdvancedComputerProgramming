using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace A8.OOCalculator.Tests
{
    [TestClass]
    public class OperatorTests
    {
        [TestMethod()]
        public void AddTest()
        {
            StreamReader reader = new StreamReader(@"OOCalculator\TestData\AddTest.txt");
            Expression exp = Expression.BuildExpressionTree(reader);
            Assert.IsTrue(exp is AddOperator);
            Assert.AreEqual(5, exp.Evaluate());
        }

        [TestMethod()]
        public void SubtractTest()
        {
            StreamReader reader = new StreamReader(@"OOCalculator\TestData\SubtractTest.txt");
            Expression exp = Expression.BuildExpressionTree(reader);
            Assert.IsTrue(exp is SubtractOperator);
            Assert.AreEqual(-1, exp.Evaluate());
        }

        [TestMethod()]
        public void MultiplyTest()
        {
            StreamReader reader = new StreamReader(@"OOCalculator\TestData\MultiplyTest.txt");
            Expression exp = Expression.BuildExpressionTree(reader);
            Assert.IsTrue(exp is MultiplyOperator);
            Assert.AreEqual(6, exp.Evaluate());
        }

        [TestMethod()]
        public void DivideTest()
        {
            StreamReader reader = new StreamReader(@"OOCalculator\TestData\DivideTest.txt");
            Expression exp = Expression.BuildExpressionTree(reader);
            Assert.IsTrue(exp is DivideOperator);
            Assert.AreEqual(2, exp.Evaluate());
        }

        [TestMethod()]
        public void NegateTest()
        {
            StreamReader reader = new StreamReader(@"OOCalculator\TestData\NegateTest.txt");
            Expression exp = Expression.BuildExpressionTree(reader);
            Assert.IsTrue(exp is NegateOperator);
            Assert.AreEqual(-5, exp.Evaluate());
        }

        [TestMethod()]
        public void ExpressionTest1()
        {            
            using StreamReader reader = new StreamReader(@"OOCalculator\TestData\ExpressionTest1.txt");
            Expression exp = Expression.BuildExpressionTree(reader);
            Assert.AreEqual(42, exp.Evaluate());
            Assert.AreEqual(exp.ToString(), "(2+(8*5))");
        }
        
        [TestMethod()]
        public void ExpressionTest2()
        {
            using StreamReader reader = new StreamReader(@"OOCalculator\TestData\ExpressionTest2.txt");
            Expression exp = Expression.BuildExpressionTree(reader);
            Assert.AreEqual(0, exp.Evaluate());
            Assert.AreEqual(exp.ToString(),"(-(5)+(2+3))");
        }
        [TestMethod()]
        public void ExpressionTest3()
        {
            using StreamReader reader = new StreamReader(@"OOCalculator\TestData\ExpressionTest3.txt");
            Expression exp = Expression.BuildExpressionTree(reader);
            Assert.AreEqual(100, exp.Evaluate());
            Assert.AreEqual(exp.ToString(), "(4*Square(-(5)))");
        }
    }
}
