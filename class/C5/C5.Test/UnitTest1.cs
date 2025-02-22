using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace C5.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Point p = new Point(5, 2, 3);
            Point p2 = new Point(4, 3, 2);
            Assert.AreEqual(p.DistanceTo(p2), System.Math.Sqrt(3));

            Assert.AreEqual(Point.DistanceTo(p, p), 0);
            Assert.AreEqual(Point.DistanceTo(p, p2), System.Math.Sqrt(3));

            Assert.AreEqual(
                Point.DistanceTo(p, p2),
                Point.DistanceTo(p2, p));

            
            PointValue pv = new PointValue(5, 2, 3);
            PointValue pv2 = new PointValue(4, 3, 2);
            Assert.AreEqual(pv.DistanceTo(pv2), System.Math.Sqrt(3));

            Assert.AreEqual(PointValue.DistanceTo(pv, pv), 0);
            Assert.AreEqual(PointValue.DistanceTo(pv, pv2), System.Math.Sqrt(3));

            Assert.AreEqual(
                PointValue.DistanceTo(pv, pv2),
                PointValue.DistanceTo(pv2, pv));


        Point a = new Point(2,3,4);
        Point b = new Point(1,4,2);
        double x = a.DistanceTo(b);
        double y = b.DistanceTo(a);
        double z = Point.DistanceTo(a,b);
        Assert.AreEqual(x,System.Math.Sqrt(6));
        Assert.AreEqual(y,System.Math.Sqrt(6));
        Assert.AreEqual(z,System.Math.Sqrt(6));

        PointValue a1 = new PointValue(5,6,7);
        PointValue b1 = new PointValue(3,8,6);
        x = a1.DistanceTo(b1);
        y = b1.DistanceTo(a1);
        z = PointValue.DistanceTo(a1,b1);
        Assert.AreEqual(x,3);
        Assert.AreEqual(y,3);
        Assert.AreEqual(z,3);
        }
    }
}
