using System;
public class Shape // reference type
{
    public Shape(string name, int cornerCount)
    {
        CornerCount = cornerCount;
        Corners = new Point[cornerCount];
        Name = name;
    }

    public void UpdateCorner(int i,Point p)
    {
        Corners[i] = p;
    }

    public Point GetCorner(int i)
    {
        return Corners[i];
        throw new NotImplementedException();
    }

    public void SwitchXY(ref Point p)
    {
        int tmp = p.X;
        p.X = p.Y;
        p.Y = tmp;
    }

    public void ExchangeCorners(int i, int j)
    {
        Point tmp = Corners[i];
        Corners[i] = Corners[j];
        Corners[j] = tmp;
    }

    public void PrintCorners()
    {
        Console.WriteLine("The name of shape is: " + Name);
        for (int i = 0; i < CornerCount; i++)
            Console.WriteLine($"The corner {i+1} is ({Corners[i].X},{Corners[i].Y}) ");
        // Print shape and corners
    }

    private Point[] Corners; // Point[] --> Point array
    private string Name;
    private int CornerCount;
}
