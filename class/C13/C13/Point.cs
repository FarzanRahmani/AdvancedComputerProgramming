using System;
namespace C13
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

}