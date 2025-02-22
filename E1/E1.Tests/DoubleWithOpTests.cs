using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace E1.Tests
{
    [TestClass()]
    public class DoubleWithOpTests
    {
        [TestMethod()]
        public void Q2_1_DoubleWithOpConstructorTest()
        {
            DoubleWithOp d1 = new DoubleWithOp(3.5);
            Assert.AreEqual(3.5, d1.Value);

            DoubleWithOp d2 = new DoubleWithOp(4.5);
            Assert.AreEqual(4.5, d2.Value);
        }

        [TestMethod()]
        public void Q2_2_DoubleWithOpAddTest()
        {
            DoubleWithOp d1 = new DoubleWithOp(3.5);
            DoubleWithOp d2 = new DoubleWithOp(4.5);
            DoubleWithOp d3 = new DoubleWithOp(5.5);

            var d4 = d1.AddWith(d2);
            Assert.AreEqual(d4.Value, 8);

            var d5 = d4.AddWith(d3);
            Assert.AreEqual(d5.Value, 13.5);

            Assert.AreEqual(d1.Value, 3.5);
            Assert.AreEqual(d2.Value, 4.5);
            Assert.AreEqual(d3.Value, 5.5);
        }

        [TestMethod()]
        public void Q2_3_DoubleWithOpMultiplyTest()
        {
            DoubleWithOp d1 = new DoubleWithOp(3.5);
            DoubleWithOp d2 = new DoubleWithOp(4.5);
            DoubleWithOp d3 = new DoubleWithOp(5.5);

            var d4 = d1.MultiplyBy(d2);
            Assert.AreEqual(d4.Value, 15.75);

            var d5 = d4.MultiplyBy(d3);
            Assert.AreEqual(d5.Value, 86.625);

            Assert.AreEqual(d1.Value, 3.5);
            Assert.AreEqual(d2.Value, 4.5);
            Assert.AreEqual(d3.Value, 5.5);

        }

        [TestMethod()]
        public void Q2_4_DoubleWithOpResetTest()
        {
            DoubleWithOp d1 = new DoubleWithOp(3.5);
            Assert.AreEqual(d1.Value, 3.5);
            d1.Reset();
            Assert.AreEqual(d1.Value, 0);
        }

        [TestMethod()]
        public void Q2_5_DoubleWithOpLoadFromStr()
        {
            DoubleWithOp d1 = new DoubleWithOp();
            d1.LoadFromStr("3.5");
            Assert.AreEqual(d1.Value, 3.5);
            d1.LoadFromStr("4.5");
            Assert.AreEqual(d1.Value, 4.5);
        }

        [TestMethod()]
        public void Q2_6_DoubleWithOpRndSet()
        {
            DoubleWithOp d1 = new DoubleWithOp(0.5);
            Assert.AreEqual(d1.Value, 0.5);
            while (d1.Value != 0.5)
                d1.RndSet();

            while (d1.Value != 0)
                d1.RndSet();
        }

        [TestMethod()]
        public void Q2_7_DoubleWithOpSet()
        {
            DoubleWithOp d1 = new DoubleWithOp(3.5);
            Assert.AreEqual(d1.Value, 3.5);
            DoubleWithOp d2 = new DoubleWithOp(4.5);
            Assert.AreEqual(d2.Value, 4.5);
            d1.Set(d2);
            Assert.AreEqual(d1.Value, 4.5);
        }

        [TestMethod()]
        public void Q2_8_DoubleWithOpClone()
        {
            DoubleWithOp d1 = new DoubleWithOp(3.5);
            var d2 = d1.Clone();
            Assert.AreEqual(d2.Value, 3.5);
            DoubleWithOp d3 = new DoubleWithOp(7.5);
            var d4 = d3.Clone();
            Assert.AreEqual(d4.Value, 7.5);
        }

        [TestMethod()]
        public void Q2_9_DoubleWithOpToString()
        {
            DoubleWithOp d1 = new DoubleWithOp(3.5);
            Assert.AreEqual(d1.ToString(), "3.5");
            d1 = new DoubleWithOp(5.5);
            Assert.AreEqual(d1.ToString(), "5.5");
        }

        [TestMethod()]
        public void Q2_9_DoubleWithOpEquatable()
        {
            var d1 = new DoubleWithOp(3.5);
            var d2 = new DoubleWithOp(5.5);
            var d3 = new DoubleWithOp(3.5);
            Assert.AreEqual(d1, d3);
            Assert.AreNotEqual(d1, d2);
            Assert.AreNotEqual(d2, d3);
        }

        [TestMethod()]
        public void Q2_10_Identity()
        {
            var d1 = new DoubleWithOp().PlusIdentity;
            var d2 = new DoubleWithOp().NegIdentity;
            Assert.AreEqual(d1.Value, 1);
            Assert.AreEqual(d2.Value, -1);
        }

    }
}