using System; // #include<stdlib.h> or import in python
// csproj hameye file haye dakhele in directory ro be ham rabt mide dige niazi be import nist
class Program // to C# hame chi dakhele kelase
{
    static void Print() // baraye class ee line 12
    {}
    void PrintP() // baraye object ee 
    {}

    static void Main(string[] args) // int main(int argc, char const *argv[])
    {
        Print(); // line 5
        Program p = new Program();
        p.PrintP(); // line 7

        Student ali = new Student("ali", Student.NewStudentId()); // syntax:new // reference type (heap)
        System.Console.WriteLine(ali.getName()); // printf
        System.Console.WriteLine(ali.getId());

        StudentV aliV = new StudentV("ali", Student.NewStudentId()); // syntax:new // value type (stack)
        System.Console.WriteLine(aliV.getName());
        System.Console.WriteLine(aliV.getId());

        // int x =5;
        // int w;
        // double s;
        Point a = new Point(2,3,4);
        Point b = new Point(1,4,2);
        double x = a.DistanceTo(b);
        double y = b.DistanceTo(a);
        double z = Point.DistanceTo(a,b);
        Console.WriteLine($" {x}  {y} {z}");

        PointValue a1 = new PointValue(5,6,7);
        PointValue b1 = new PointValue(3,8,6);
        x = a1.DistanceTo(b1);
        y = b1.DistanceTo(a1);
        z = PointValue.DistanceTo(a1,b1);
        Console.WriteLine($" {x}  {y} {z}");
    }
}
