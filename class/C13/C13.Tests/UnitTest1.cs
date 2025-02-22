using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace C13.Tests
{

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PointXSortTest()
        {
            Point[] points = new Point[] {
                new Point(0,0),
                new Point(9,4),
                new Point(7,8),
                new Point(2,10),
                new Point(11,1),
                new Point(1,2),
                new Point(10,7),
            };
            Program.Sort<Point>(points , (p1,p2) => p1.X < p2.X );
            int[] res = new int[] {11,10,9,7,2,1,0};
            for(int i = 0 ; i < 7 ; i++ ){
                Assert.AreEqual(points[i].X , res[i]);
            }
        }

        [TestMethod]
        public void PointYSortTest()
        {
            Point[] points = new Point[] {
                new Point(0,0),
                new Point(9,4),
                new Point(7,8),
                new Point(2,10),
                new Point(11,1),
                new Point(1,2),
                new Point(10,7),
            };
            Program.Sort<Point>(points , (p1,p2) => p1.Y<p2.Y );
            int [] res = new int[] {10,8,7,4,2,1,0};
            for(int i = 0 ; i < 7 ; i++ ){
                Assert.AreEqual(points[i].Y , res[i]);
            }
        }

        [TestMethod]
        public void PointMagnitudeSortTest()
        {
            Point[] points = new Point[] {
                new Point(0,0),
                new Point(4,3),
                new Point(0,2),
                new Point(6,8),
                new Point(2,1)
            };
            Program.Sort<Point>(points ,
            (p1,p2) => Math.Sqrt(p1.X*p1.X + p1.Y*p1.Y) < Math.Sqrt(p2.X*p2.X + p2.Y*p2.Y)
            );
            double[] res =new double[] {10,5,Math.Sqrt(5),2,0};
            for(int i = 0 ; i<5 ; i++){
                Assert.AreEqual(points[i].Magnitude() , res[i]);
            }
        }

    }
}
