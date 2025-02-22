using System;
// F12 --> tarif tabe
namespace C7
{
    class Program
    {
        static int Test1(int a)
        {
            return Test2(a)+1;
        }

        static int Test2(int a)
        {
            return Test3(a)+1;
        }

        static int Test3(int a)
        {
            return a+1;
        }

        static int Fib(int n)
        {   
            int x = 5;
            int w = 6;
            int t = 2;
            // if (n <= 1)  
            //     return 1;

            if (n % 100 == 0)
                Console.WriteLine("{0},{1},{2},{3}", n, x, w, t);            

            return Fib(n-1) + Fib(n-2); // Stack Over Flow error
        }
        class Person // reference type --> pointer --> heap
        {
            public int id;
            public Person Clone()
            {
                Person p = new Person(){id=this.id}; // new hafeze jadid dar heap malloc mikone ta be ye ja eshare nakonan jofteshon
                return p;
            }
        }
        struct PersonV  // value type --> int --> stack
        {         
            public int id;
        }
        static void Modify(ref Person p)
        {
            p.id = 5;
            p = new Person() {id=16};
        }

        // static int Update1(ref int n) // ref == reference --> lozooman niaz nist meghdar bedi
        // {
        //     return n+1;
        // }

        // static void Update(out int n, out int w, out int x, out int s) // out --> lozooman niaz hast meghdar bedi va mesl ref pass by reference ham dare
        // {
        //     n = 1;
        //     n = n + 1;
        //     // return n;
        // }

        static double readnumber(string name_of_dimention)
        {
            string str;double result;
            do
            {
                Console.Write( "Enter the {0} of point :",name_of_dimention );
                str = Console.ReadLine();
            } while (! double.TryParse(str,out result));
            return result;
        }

        class Point // class Point (x, y) // pass by ref
            {
                public double x;
                public double y;
            }
        static void readpoint(Point p)
        {
            string x = "x";string y = "y";
            p.x = readnumber(x);
            p.y = readnumber(y);
        }
        static double Distance(Point p1,Point p2)
        {
            return System.Math.Sqrt((p1.x-p2.x)*(p1.x-p2.x)+(p1.y-p2.y)*(p1.y-p2.y));
        }
        static void ProcessPointsRef()
        {
            Point p1 = new Point();
            Console.WriteLine("Point 1 :");
            readpoint(p1);
            Point p2 = new Point();
            Console.WriteLine("Point 2 :");
            readpoint(p2);
            Console.WriteLine("The distance between Point 1 and Point 2 is {0} .",Distance(p1,p2));
            double x = readnumber("your favorite");
            Console.WriteLine("Your favorite of point multiplied by 2 is {0}",x*2);
        }

        struct PointV // struct Point (x, y) // pass by value
        {
            public double x;
            public double y;
        }

        static void readpointV(out PointV pv)
        {
            string x = "x";string y = "y";
            pv.x = readnumber(x);
            pv.y = readnumber(y);
        }

        static double DistanceV(PointV p1,PointV p2)
        {
            return System.Math.Sqrt((p1.x-p2.x)*(p1.x-p2.x)+(p1.y-p2.y)*(p1.y-p2.y));
        }

        static void ProcessPointsValue()
        {
            PointV pv1;
            Console.WriteLine("Point 1 :");
            readpointV(out pv1);
            PointV pv2;
            Console.WriteLine("Point 2 :");
            readpointV(out pv2);
            Console.WriteLine("The distance between Point 1 and Point 2 is {0} .",DistanceV(pv1,pv2));
            double x = readnumber("your favorite");
            Console.WriteLine("Your favorite of point multiplied by 2 is {0}",x*2);
        }



        static void Main(string[] args)
        {   
            // // int n1;
            // // Update1(ref n1); // mige chera be n1 meghdar nadadi (compliler:man chi bezaram tosh!) age ba out bezani OK ee chon hatman meghdar mide
            // // Update(out n1);                

            // // Person p2;  // Person p2 = new Person()
            // // p2.id = 9; // chon baraye p2 new(memory allocation in heap) nazadi

            // Person p = new Person{id=5}; // by ref
            // Person p1 = p;
            // p.id = 6; // p1.id ham taghir mikone pass y ref shode
            // p = new Person{id=12};
            // System.Console.WriteLine(p1.id);

            // PersonV pv; // by value // bedon new kar mikone chon ro stacke va pass by value
            // pv.id = 52;
            // PersonV pv1 = pv; // copy migire // by value na ref
            // pv.id=6; // faghat py taghir mikone
            // System.Console.WriteLine(pv1.id); // F12 --> tarif tabe

            // int n;
            // string str;
            // do
            // {
            //     Console.Write("Enter? ");
            //     str = Console.ReadLine(); // shabihe scanf(c) ya st::cout(c++) ya input(python)  **readline string return mikone**
            // } while(! int.TryParse(str, out n)); // out --> shabihe ref + hatman meghdar mide behesh (garanty mikone ke meghdar migire)
            // Console.WriteLine($"You number plus 1 is: {n+1}");            


            // // int n;
            // // if (!int.TryParse(str, out n)) F12 --> tarif tabe
            // // {
            // //     Console.Write("Enter? ");
            // //     str = Console.ReadLine();
            // //     n = int.Parse(str); // F12 --> tarif tabe
            // // }


            ProcessPointsRef();
            ProcessPointsValue();
        }
    }
}
