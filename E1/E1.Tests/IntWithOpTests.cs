using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace E1.Tests
{
    [TestClass()]
    public class IntWithOpTests
    {
        [TestMethod()]
        public void Q1_1_IntWithOpConstructorTest()
        {
            IntWithOp d1 = new IntWithOp(3);
            Assert.AreEqual(3, d1.Value);

            IntWithOp d2 = new IntWithOp(4);
            Assert.AreEqual(4, d2.Value);
        }

        [TestMethod()]
        public void Q1_2_IntWithOpAddTest()
        {
            IntWithOp d1 = new IntWithOp(3);
            IntWithOp d2 = new IntWithOp(4);
            IntWithOp d3 = new IntWithOp(5);

            var d4 = d1.AddWith(d2);
            Assert.AreEqual(d4.Value, 7);

            var d5 = d4.AddWith(d3);
            Assert.AreEqual(d5.Value, 12);

            Assert.AreEqual(d1.Value, 3);
            Assert.AreEqual(d2.Value, 4);
            Assert.AreEqual(d3.Value, 5);
        }

        [TestMethod()]
        public void Q1_3_IntWithOpMultiplyTest()
        {
            IntWithOp d1 = new IntWithOp(3);
            IntWithOp d2 = new IntWithOp(4);
            IntWithOp d3 = new IntWithOp(5);

            var d4 = d1.MultiplyBy(d2);
            Assert.AreEqual(d4.Value, 12);

            var d5 = d4.MultiplyBy(d3);
            Assert.AreEqual(d5.Value, 60);

            Assert.AreEqual(d1.Value, 3);
            Assert.AreEqual(d2.Value, 4);
            Assert.AreEqual(d3.Value, 5);
        }

        [TestMethod()]
        public void Q1_4_IntWithOpResetTest()
        {
            IntWithOp d1 = new IntWithOp(3);
            Assert.AreEqual(d1.Value, 3);
            d1.Reset();
            Assert.AreEqual(d1.Value, 0);
        }

        [TestMethod()]
        public void Q1_5_IntWithOpLoadFromStr()
        {
            IntWithOp d1 = new IntWithOp();
            d1.LoadFromStr("3");
            Assert.AreEqual(d1.Value, 3);
            d1.LoadFromStr("4");
            Assert.AreEqual(d1.Value, 4);
        }

        [TestMethod()]
        public void Q1_6_IntWithOpRndSet()
        {
            IntWithOp d1 = new IntWithOp(3);
            Assert.AreEqual(d1.Value, 3);
            while (d1.Value != 3)
                d1.RndSet();

            while (d1.Value != 0)
                d1.RndSet();
        }

        [TestMethod()]
        public void Q1_7_IntWithOpSet()
        {
            IntWithOp d1 = new IntWithOp(3);
            Assert.AreEqual(d1.Value, 3);
            IntWithOp d2 = new IntWithOp(4);
            Assert.AreEqual(d2.Value, 4);
            d1.Set(d2);
            Assert.AreEqual(d1.Value, 4);
        }

        [TestMethod()]
        public void Q1_8_IntWithOpClone()
        {
            IntWithOp d1 = new IntWithOp(3);
            var d2 = d1.Clone();
            Assert.AreEqual(d2.Value, 3);
            IntWithOp d3 = new IntWithOp(7);
            var d4 = d3.Clone();
            Assert.AreEqual(d4.Value, 7);
        }

        [TestMethod()]
        public void Q1_9_IntWithOpToString()
        {
            IntWithOp d1 = new IntWithOp(3);
            Assert.AreEqual(d1.ToString(), "3");
            d1 = new IntWithOp(5);
            Assert.AreEqual(d1.ToString(), "5");
        }

        [TestMethod()]
        public void Q1_9_IntWithOpEquatable()
        {
            var d1 = new IntWithOp(3);
            var d2 = new IntWithOp(5);
            var d3 = new IntWithOp(3);
            Assert.AreEqual(d1, d3);
            Assert.AreNotEqual(d1, d2);
            Assert.AreNotEqual(d2, d3);
        }

        [TestMethod()]
        public void Q1_10_Identity()
        {
            var d1 = new IntWithOp().PlusIdentity;
            var d2 = new IntWithOp().NegIdentity;
            Assert.AreEqual(d1.Value, 1);
            Assert.AreEqual(d2.Value, -1);
        }

    }
}