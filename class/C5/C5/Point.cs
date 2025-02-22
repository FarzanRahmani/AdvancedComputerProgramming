using System;
// csproj hameye file haye dakhele in directory ro be ham rabt mide dige niazi be import nist
public class Point // reference type --> heap
{
    public Point(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public double DistanceTo(Point other)
    {
        return DistanceTo(this,other);
    }

    public static double DistanceTo(Point a, Point b)
    {
        int d_x = a.X - b.X;
        int d_y = a.Y - b.Y;
        int d_z = a.Z - b.Z;
        double sqr = d_x*d_x + d_y*d_y + d_z*d_z;
        return System.Math.Sqrt(sqr);
    }

    void PrintInfo()
    {
        Console.WriteLine($"X: {this.X} Y: {this.Y} Z: {this.Z}");
        System.Console.WriteLine("X: " + this.X + "Y: " + this.Y + "Z: " + this.Z);
        // string s_x = X.ToString();  
        // string s_y = Y.ToString();
        // string s_z = Z.ToString();
}

    public int X;
    public int Y;
    public int Z;
}


public struct PointValue // value type --> stack
{
    public PointValue(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public double DistanceTo(PointValue other)
    {
        return DistanceTo(this,other);
    }

    public static double DistanceTo(PointValue a, PointValue b)
    {
        int d_x = a.X - b.X;
        int d_y = a.Y - b.Y;
        int d_z = a.Z - b.Z;
        double sqr = d_x*d_x + d_y*d_y + d_z*d_z;
        return System.Math.Sqrt(sqr);
    }

    void PrintInfo()
    {
        Console.WriteLine($"X: {this.X} Y: {this.Y} Z: {this.Z}");
        System.Console.WriteLine("X: " + this.X + "Y: " + this.Y + "Z: " + this.Z);
        // string s_x = X.ToString();  
        // string s_y = Y.ToString();
        // string s_z = Z.ToString();
}
    public int X;
    public int Y;
    public int Z;
}