using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace C18.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMagnitude()
        {
            Point p = new Point(1,2,2);
            Assert.AreEqual(p.Magnitude(),3);
            Point p1 = new Point(3,4);
            Assert.AreEqual(p1.Magnitude(),5);
        }

        [TestMethod]
        public void TestCompare()
        {
            Point p = new Point(1,2,2);
            Point p1 = new Point(7,8,9);
            Assert.IsTrue(p.CompareTo(p1) < 0);
            Point p2 = new Point(0,0,1);
            Point[] points = new Point[]{p, p1, p2};
            Array.Sort(points);
            Point[] expected = new Point[]{p2, p, p1};
            for (int i = 0; i < points.Length; i++)
            {
                Assert.IsTrue(points[i] == expected[i]);
            }
        }

        [TestMethod]
        public void TestAddTo()
        {
            Point p1 = new Point(new int[]{1,2,3,4});
            Point p2 = new Point(new int[]{1,2,3,4});
            Point p3 = p1.AddTo(p2);
            Point expected = new Point(new int[]{2,4,6,8});
            Assert.IsTrue(p3 == expected);
        }

        [TestMethod]
        public void TestOperatorPlus()
        {
            Point p1 = new Point(new int[]{1,2,3,4});
            Point p2 = new Point(new int[]{8,7,6,5});
            Point pPlus = p1+p2;
            Assert.IsTrue(pPlus == new Point(new int[]{9,9,9,9})); 
            Point pPlusInt = p1 + 9;
            Assert.IsTrue(pPlusInt == new Point(new int[]{10,11,12,13}));
        }

        [TestMethod]
        public void TestOperatorMinus()
        {
            Point p1 = new Point(new int[]{1,2,3,4});
            Point p2 = new Point(new int[]{8,7,6,5});
            Point pMinus = p1-p2;
            Assert.IsTrue(pMinus == new Point(new int[]{-7,-5,-3,-1})); 
            Point pMinusInt = p1 - 9;
            Assert.IsTrue(pMinusInt == new Point(new int[]{-8,-7,-6,-5}));
        }

        [TestMethod]
        public void TestOperatorMulti_Divide()
        {
            Point p1 = new Point(new int[]{1,2,3,4});
            Point p2 = new Point(new int[]{4,6,8,2});
            Point pMult = p1*2;
            Assert.IsTrue(pMult == new Point(new int[]{2,4,6,8})); 
            Point pDiv = p2 / 2;
            Assert.IsTrue(pDiv == new Point(new int[]{2,3,4,1}));
        }

        [TestMethod]
        public void TestEquality()
        {
            Point p1 = new Point(new int[]{1,2,3,4});
            Point p2 = new Point(new int[]{1,2});
            Point p3 = new Point(new int[]{4,5,6});
            Point p4 = new Point(new int[]{1,2,3,4});
            Point p5 = new Point(new int[]{4,5,6,4});
            Assert.IsTrue(p1.Equals(p4));
            Assert.IsFalse(p1.Equals(p5));
            Assert.IsFalse(p1.Equals(p2));
            Assert.IsTrue(p1 == p4);
            Assert.IsFalse(p1 == p3);
            Assert.IsTrue(p1 != p5);
            Assert.IsFalse(p1 != p4);
        }

        [TestMethod]
        public void TestInEquality()
        {
            Point p1 = new Point(new int[]{1,2,3,4});
            Point p2 = new Point(new int[]{7,8,9,10});
            Point p3 = new Point(new int[]{20,21,22,23});
            Point p4 = new Point(new int[]{1,2,3,4});
            Point p5 = new Point(new int[]{4,5,6,4});
            Assert.IsTrue(p1 < p2);
            Assert.IsFalse(p3 < p1);
            Assert.IsFalse(p4 > p1);
            Assert.IsTrue(p5>p4);
            Assert.IsFalse(p1 >= p3);
            Assert.IsTrue(p1 >= p4);
            Assert.IsTrue(p5 >= p4);
            Assert.IsTrue(p1 <= p3);
            Assert.IsTrue(p1 <= p4);
            Assert.IsFalse(p5 <= p4);
        }

        [TestMethod]
        public void TestIndexer()
        {
            Point p = new Point(5, 4, 2, 3, 1);
            Assert.AreEqual( p[0] , 5);
            Assert.AreEqual( p[1] , 4);
            Assert.AreEqual( p[2] , 2);
            Assert.AreEqual( p[3] , 3);
            Assert.AreEqual( p[4] , 1);
            int w = p[3];
            Assert.AreEqual( w , 3);
            p["3"] = 5;
            Assert.AreEqual( p["3"] , 5);
        }
    }
}
