using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace C6.Test
{
    [TestClass]
    public class ShapeTest
    {
        [TestMethod]
        public void ShapeConstructorTest()
        {
            Shape s = new Shape("window", 4);
            Point p = new Point();
            p.X = 3;
            p.Y = 2;
            s.UpdateCorner(0, p);
            p.Y = 3;
            s.UpdateCorner(1, p);
            p.X = 1;
            s.UpdateCorner(2, p);
            p.Y = 1; 
            s.UpdateCorner(3, p);
            Assert.AreEqual(s.GetCorner(0).X,3);
            Assert.AreEqual(s.GetCorner(0).Y,2);

            Shape tri = new Shape("triangle", 3);
            Point pt = new Point();
            pt.X = 1;
            pt.Y = 1;
            tri.UpdateCorner(0, pt);
            pt.Y = -1;
            tri.UpdateCorner(1, pt);
            pt.X = -1;
            tri.UpdateCorner(2, pt);
            Assert.AreEqual(tri.GetCorner(0).X,1);
            Assert.AreEqual(tri.GetCorner(0).Y,1);
        }

        [TestMethod]
        public void GetCornerTest()
        {
            Point p_test = new Point {X=1,Y=2};
            Assert.AreEqual(p_test.X , 1);
            Assert.AreEqual(p_test.Y , 2);
        }

        [TestMethod]
        public void UpdateCornerTest()
        {
            Shape tri = new Shape("triangle", 3);
            Point pt = new Point();
            pt.X = 1;
            pt.Y = 1;
            tri.UpdateCorner(0, pt);
            pt.Y = -1;
            tri.UpdateCorner(1, pt);
            pt.X = -1;
            tri.UpdateCorner(2, pt);

            Point ptest = new Point {X=-2,Y=-2};
            tri.UpdateCorner(2,ptest);
            Assert.AreEqual(tri.GetCorner(2).X,-2);
            Assert.AreEqual(tri.GetCorner(2).Y,-2);
        }

        [TestMethod]
        public void ExchangeCornerTest()
        {
            Shape s = new Shape("window", 4);
            Point p = new Point{X=1, Y=2};
            s.UpdateCorner(0, p); // (1,2)
            p.Y = 3;
            s.UpdateCorner(1, p); // (1,3)
            p.X = 3;
            s.UpdateCorner(2, p); // (3,3)
            p.Y = 1; 
            s.UpdateCorner(3, p); // (3,1)

            s.ExchangeCorners(0, 2);
            Assert.AreEqual(s.GetCorner(0).X , 3);
            Assert.AreEqual(s.GetCorner(0).Y , 3);

            Assert.AreEqual(s.GetCorner(2).X , 1);
            Assert.AreEqual(s.GetCorner(2).Y , 2);
        }
    }
}
