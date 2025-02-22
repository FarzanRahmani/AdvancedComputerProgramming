using System;
namespace C10
{
    public class Point
    {
        public Point(int x, int y)
        {
            X = x ; Y = y;
        }
        public int X;
        public int Y;    
        public double Magnitude()
        {
        return Math.Sqrt( (Y*Y)  + (X*X) );
        }
    }

    public class PointXComparer : IMyComparer<Point>
    {
        public bool Compare(Point p1,Point p2) => p1.X < p2.X;
    }

    public class PointYComparer : IMyComparer<Point>
    {
        public bool Compare(Point p1,Point p2) 
        {
            return p1.Y < p2.Y;
        }
    }

    public class PointMagnitudeComparer : IMyComparer<Point>
    {
        public bool Compare(Point p1,Point p2) 
        {
            return Math.Sqrt( (p1.Y*p1.Y)  + (p1.X*p1.X) ) < Math.Sqrt( (p2.Y*p2.Y)  + (p2.X*p2.X) );
        }
    }

    public static class PointComparer
    {
        public static PointXComparer PointXComparer = new PointXComparer();
        public static PointYComparer PointYComparer = new PointYComparer();
        public static PointMagnitudeComparer PointMagnitudeComparer = new PointMagnitudeComparer();
    }
}