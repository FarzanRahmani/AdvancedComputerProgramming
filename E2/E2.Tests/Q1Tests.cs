
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace E2.Tests
{
    [TestClass()]
    public class RangeExtTests
    {

        [TestMethod()]
        public void Q01EuclideanDistance()
        {
            var actual = QExt.Q01EuclideanDistance(new Point(0, 0), new Point(3, 4));
            Assert.AreEqual(5, actual);
        }

        [TestMethod()]
        public void Q02ManhatanDistance()
        {
            var actual = QExt.Q02ManhatanDistance(new Point(0, 0), new Point(3, 4));
            Assert.AreEqual(7, actual);
        }


        [TestMethod()]
        public void Q11GetRangeTest()
        {
            var actual = inums1.Q11GetRange();
            Assert.AreEqual((-5, 4), actual);

            actual = inums2.Q11GetRange();
            Assert.AreEqual((-2, 4), actual);

            actual = inums3.Q11GetRange();
            Assert.AreEqual((0, 0), actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Q11GetRangeExceptionTest()
        {
            var r = new int[]{}.Q11GetRange();
        }

        [TestMethod()]
        public void Q12GetRangeTest()
        {
            int actual = inums1.Q12GetRange();
            Assert.AreEqual(9, actual);

            actual = inums2.Q12GetRange();
            Assert.AreEqual(6, actual);

            actual = inums3.Q12GetRange();
            Assert.AreEqual(0, actual);
        }

        [TestMethod()]
        public void Q13GetRangeTest()
        {
            // int
            var actual = inums1.Q13GetRange();
            Assert.AreEqual((-5, 4), actual);

            actual = inums2.Q13GetRange();
            Assert.AreEqual((-2, 4), actual);

            actual = inums3.Q13GetRange();
            Assert.AreEqual((0, 0), actual);

            // double        
            var dactual = dnums1.Q13GetRange();
            Assert.AreEqual((-2.3, 5.7), dactual);

            dactual = dnums2.Q13GetRange();
            Assert.AreEqual((-7.5, 31.5), dactual);
        }

        [TestMethod()]
        public void Q14GetRangeTest()
        {
            // int, sub
            var actual = inums1.Q14GetRange((i1, i2) => i1 - i2);
            Assert.AreEqual((-5, 4), actual);

            // int, divide
            actual = inums2.Q14GetRange((i1, i2) => (double)i1 / i2);
            Assert.AreEqual((1, 4), actual);

            // int, reverse divide
            actual = inums2.Q14GetRange((i1, i2) => (double)i2 / i1);
            Assert.AreEqual((4, 1), actual);

            // double, sub
            var dactual = dnums1.Q14GetRange((d1, d2) => d1 - d2);
            Assert.AreEqual((-2.3, 5.7), dactual);

            // double, divide
            dactual = dnums2.Q14GetRange((d1, d2) => d1 / d2);
            Assert.AreEqual((0.05, 31.5), dactual);

            // double, reverse divide
            dactual = dnums2.Q14GetRange((d1, d2) => d2 / d1);
            Assert.AreEqual((31.5, 0.05), dactual);
        }

        [TestMethod()]
        public void Q14GetRangeTest_2()
        {
            // point, euclidean distance
            Point[] points = new Point[]{new Point(0,0), new Point(3, 4), new Point(6, 0), new Point(3,1), new Point(2,1), new Point(4,1)};
            var pactual = points.Q14GetRange(QExt.Q01EuclideanDistance);
            Assert.AreEqual(( new Point(6,0), new Point(0,0)), pactual);

            // point, manhatan distance
            pactual = points.Q14GetRange(QExt.Q02ManhatanDistance);
            Assert.AreEqual(( new Point(3,4), new Point(0,0) ), pactual);

            string[] patterns = new string[]{"abcd", "aaaa", "a", "zdef", "abdefghi", "bbbbddddeeefffgggsx"};
            var sactual = patterns.Q14GetRange(QExt.Q03StringDistance);
            Assert.AreEqual( ("aaaa", "bbbbddddeeefffgggsx"), sactual);
        }



        [TestMethod()]
        public void Q15GetRangeTest()
        {
            // int, sub
            var actual = inums1.Q15GetRange((i1, i2) => i1 - i2);
            Assert.AreEqual(9, actual);

            // int, divide
            actual = inums2.Q15GetRange((i1, i2) => (double)i1 / i2);
            Assert.AreEqual(4, actual);

            // int, reverse divide
            actual = inums2.Q15GetRange((i1, i2) => (double)i2 / i1);
            Assert.AreEqual(4, actual);

            // double, sub
            var dactual = dnums1.Q15GetRange((d1, d2) => d1 - d2);
            Assert.AreEqual(8, dactual);

            // double, divide
            dactual = dnums2.Q15GetRange((d1, d2) => d1 / d2);
            Assert.AreEqual(630, dactual);

            // double, reverse divide
            dactual = dnums2.Q15GetRange((d1, d2) => d2 / d1);
            Assert.AreEqual(630, dactual);
 
            // point, euclidean distance
            Point[] points = new Point[]{new Point(0,0), new Point(3, 4), new Point(6, 0), new Point(3,1), new Point(2,1), new Point(4,1)};
            var pactual = points.Q15GetRange(QExt.Q01EuclideanDistance);
            Assert.AreEqual(6, pactual);

            // point, manhatan distance
            pactual = points.Q15GetRange(QExt.Q02ManhatanDistance);
            Assert.AreEqual(7, pactual);

            string[] patterns = new string[]{"abcd", "aaaa", "a", "zdef", "abdefghi", "bbbbddddeeefffgggsx"};
            var sactual = patterns.Q15GetRange(QExt.Q03StringDistance);
            Assert.AreEqual( 19, sactual);
        }

        static readonly int[] inums1 = new int[]{2, 2, 1, -3, -2, 2, -5, 4, 3};
        static readonly int[] inums2 = new int[]{2, 2, 1, 2, -2, 4, 3};
        static readonly int[] inums3 = new int[]{0, 0, 0, 0, 0};    

        static readonly double[] dnums1 = new double[]{1.2, 3.4, 0.01, -2.3, 4.5, 5.7};
        static readonly double[] dnums2 = new double[]{31.5, -3.4, 0.05, -2.3, -7.5, 5.3};

    }
}
