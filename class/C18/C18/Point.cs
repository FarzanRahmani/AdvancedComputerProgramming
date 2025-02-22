using System;

namespace C18
{

    public class Point: IComparable<Point>
    {
        private int[] Dim; // dimenstions
        public int X {
            get => Dim[0];
            set => Dim[0] = value;
        }
        public int Y {
            get => Dim[1];
            set => Dim[1] = value;
        }  

        public int Z {
            get => Dim[2];
            set => Dim[2] = value;
        }  

        public int Length => Dim.Length;      
        public string Name {get; set;}
        public Point(int x, int y)
        {
            this.Dim = new int[2];
            this.X = x;
            this.Y = y;
        }

        public Point(int x, int y, int z)
        {
            this.Dim = new int[3];
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public void Swap(ref int[] a1, ref int[] b1)
        {
            int[] t = a1;
            a1 = b1;
            b1 = t;
        }

        public Point(params int[] nums)
        {
            this.Dim = new int[nums.Length]; // new allocation
            for(int i=0; i<nums.Length; i++)
                this.Dim[i] = nums[i];
        }


        public double Magnitude()
        {
            double sum = 0;
            for (int i = 0; i < Dim.Length; i++)
            {
                sum += Dim[i]*Dim[i];
            }
            return Math.Sqrt(sum);
        }
        public int CompareTo(Point other) // vaghti in tabe va interface sho dashte bashe mishe Sort ro Point[] seda zad IComparable
        {
            return this.Magnitude().CompareTo(other.Magnitude());
        }

        public Point AddTo(Point p) 
        {
            int[] sums = new int[p.Dim.Length];
            for (int i = 0; i < Dim.Length; i++)
            {
                sums[i] = this.Dim[i] + p.Dim[i];
            }
            return new Point(sums);
        }
        // operation overloading
        // mesl tabe mamooli faghat esmesh operatorX ee X --> +,-,*,/,...
        public static Point operator+(Point LHS, Point RHS) // return = LHS + RHS // LHS must be Point
        {
            int[] sums = new int[LHS.Dim.Length];
            for (int i = 0; i < LHS.Dim.Length; i++)
            {
                sums[i] = LHS.Dim[i] + RHS.Dim[i];
            }
            return new Point(sums);
        }
        public static Point operator+(Point LHS, int RHS) // LHS --> Left Hand Side
        {
            int[] sums = new int[LHS.Dim.Length];
            for (int i = 0; i < LHS.Dim.Length; i++)
            {
                sums[i] = LHS.Dim[i] + RHS;
            }
            return new Point(sums);
        }
        public static Point operator*(Point right, int left) // tabi ke esmesh operator* ee  --> tarz estefade : return = right * left
        {
            int[] sums = new int[right.Dim.Length];
            for (int i = 0; i < right.Dim.Length; i++)
            {
                sums[i] = right.Dim[i] * left;
            }
            return new Point(sums);
        }
        // Operator -
        public static Point operator-(Point LHS, Point RHS) // return = LHS + RHS // LHS must be Point
        {
            int[] sums = new int[LHS.Dim.Length];
            for (int i = 0; i < LHS.Dim.Length; i++)
            {
                sums[i] = LHS.Dim[i] - RHS.Dim[i];
            }
            return new Point(sums);
        }
        public static Point operator-(Point LHS, int RHS) // LHS --> Left Hand Side
        {
            int[] sums = new int[LHS.Dim.Length];
            for (int i = 0; i < LHS.Dim.Length; i++)
            {
                sums[i] = LHS.Dim[i] - RHS;
            }
            return new Point(sums);
        }
        // Operator /
        public static Point operator/(Point right, int left) // tabi ke esmesh operator* ee  --> tarz estefade : return = right / left
        {
            int[] sums = new int[right.Dim.Length];
            for (int i = 0; i < right.Dim.Length; i++)
            {
                sums[i] = right.Dim[i] / left;
            }
            return new Point(sums);
        }

        // Equal mamooli faghat address ha ro check mikone --> overidesh mikonim
        public override bool Equals(object obj)
        {
            Point p = obj as Point;
            // if (p == null || this == null ) ye ki an 141 va 142
            // if (null == p || null == p ) 
            if (ReferenceEquals(p, null) || ReferenceEquals(this, null) || p.Length != this.Length)
                return false;
            if (this.Length != p.Length)
            {
                return false;
            }
            for (int i = 0; i < p.Dim.Length; i++)
                if (p.Dim[i] != this.Dim[i])
                    return false;
            return true;
        }
        public static bool operator==(Point p1, Point p2) // == be tor pish farz hast vali faghat address ro moghayese mikone
        {
            if (ReferenceEquals(p2, null) && ReferenceEquals(p1, null)) 
                return true;
            
            if (ReferenceEquals(p2, null) || ReferenceEquals(p1, null)) // nemishe az == estefade kard chon Stack over flow mide (taze dari tarifesh mikoni nemishe estefade kard) p1 == null
                return false;

            if (p1.Length != p2.Length)
            {
                return false;
            }

            for (int i = 0; i < p1.Dim.Length; i++)
                if (p1.Dim[i] != p2.Dim[i])
                    return false;
            return true;
        }
        public static bool operator!=(Point left, Point right) => ! (left == right);

        public static bool operator<(Point p1, Point p2) => p1.Magnitude() < p2.Magnitude();
        public static bool operator>(Point p1, Point p2) => p1.Magnitude() > p2.Magnitude();
        public static bool operator>=(Point p1, Point p2) => p1.Magnitude() >= p2.Magnitude();
        public static bool operator<=(Point p1, Point p2) => p1.Magnitude() <= p2.Magnitude();

        // Indexer
        public int this[int x, int y]
        {
            get
            {
                return this.Dim[x + y];
            }
            set
            {
                this.Dim[x+y] = value;
            }   
        }

        public int this[string s]
        {
            get
            {
                return this.Dim[int.Parse(s)];
            }
            set
            {
                this.Dim[int.Parse(s)] = value;
            }
        }

        public int this[int n] // int pass az public noe value setter va return getter taeen mikone
        {
            get{
                return this.Dim[n];
            }
            set{
                // if (value >= 0)
                    this.Dim[n] = value;
            }
        }    
    }

    class Program1
    {
        public static void Main88(string[]  args)
        {
            int[] nums = new int[3] { 1, 2, 3};
            Point p = new Point(nums);
            nums[1] = 4;
            Point p1 = new Point(nums);
            Point p3 = new Point(5, 4, 2, 3, 1);
            p3[2] = 5;
            int w = p3[3];
            p3["3"] = 5;
        }
        public static void Main(string[]  args)
        {
            Point p1 = new Point(5, 10);
            Point p2 = new Point(3, 4);
            Point psum = p1.AddTo(p2);
            Point psum1 = p1 + p2;
            Point psum2 = p1 + 5;
            Point pScale = p1 * 5;
            
            Point p3 = new Point(5, 10);            

            if (p3 == p1)
                System.Console.WriteLine("Is Equal");
            else
                System.Console.WriteLine("Not Equal");

            Point p4 = null;
            if (p3.Equals(p4))
            {
                System.Console.WriteLine("Is Equal");
            }
            else
            {
                System.Console.WriteLine("Not Equal");
            }

            if (p1 < p2)
                System.Console.WriteLine("p1 < p2");

            Point[] points = new Point[]{p1, p2, p3};
            Array.Sort(points); // chon IComperable ee pas sort mishe zade
        }
    }

}