using System;
using System.Collections;
using System.Collections.Generic;

namespace C11
{
    public class Point
    {
        public int x;public int y; // field

        public Point(int v1, int v2) // method
        {
            x = v1;
            y = v2;
        }

        // public int x { get; }
        // public int y { get; } // property
    }
    public interface IShape
    {
        void Move(int x, int y);
        string Name {get;}
    }

    public class Triangle: IShape // Constructor?
    {
        public Point p1;public Point p2;public Point p3;public string name;
        public Triangle(Point a,Point b,Point c,string n)
        {
            p1 = a;p2 =b;p3=c;name = n;
        }

        public string Name => name;

        public void Move(int x, int y)
        {
            p1.x += x;p2.x += x;p3.x += x;
            p1.y += y;p2.y += y;p3.y += y;
        }
    }

    public class Circle: IShape
    {
        public Point center;public string name;public int Radius;

        public Circle(string n,Point p, int R)
        {
            center = p;name = n;Radius = R;
        }

        public string Name => name;

        public void Move(int x, int y)
        {
            center.x += x;center.y += y;
        }
    }

    public class Square: IShape // Constructor?
    {
        public Point p1;public Point p2;public Point p3;public Point p4;public string name;

        public Square()
        {
        }

        public Square(Point a,Point b,Point c,Point d,string n)
        {
            p1 = a;p2 = b; p3 = c ;p4 = d;name = n;
        }

        public string Name => name;

        public void Move(int x, int y)
        {
            p1.x += x;p2.x += x;p3.x += x;p4.x +=x;
            p1.y += y;p2.y += y;p3.y += y;p4.y += y;
        }
    }

    public class Board: IEnumerable<IShape>
    {
        public void MoveAllShapes(int x, int y)
        {
            foreach(IShape shape in this)
                shape.Move(x, y);
        }

        public List<IShape> shapes = new List<IShape>();
        public IEnumerable<IShape> Shapes { get; }

        public void AddShape(IShape s)
        {
            shapes.Add(s);
        }

        public IEnumerator<IShape> GetEnumerator()
        {
            return new ShapeEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ShapeEnumerator(this);
        }
    }

    public class ShapeEnumerator :IEnumerator<IShape>
    {
        private Board board;
        private int pos = -1;

        public ShapeEnumerator(Board board)
        {
            this.board = board;
        }

        public IShape Current => board.shapes[pos];

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {}

        public bool MoveNext()
        {
            pos++;
            return pos < board.shapes.Count;
        }

        public void Reset()
        {
            this.pos = -1;
        }
    }

    public class BoardProgram
    {
        public static void Main3(string[] args)
        {
            Board b = new Board();
            Circle c = new Circle("ball",new Point(1,2), 3);
            Circle c2 = new Circle("target", new Point(1,2), 3);
            Square s1 = new Square();//("target", 1, 2, 3);
            b.AddShape(c);
            b.AddShape(c2);
            b.AddShape(s1);
            foreach(IShape s in b)
            {
                Console.WriteLine(s.Name);
            }
        }
    }
}