using System;


namespace C8
{
    enum Color // enumuration shabihe (32 bit int)
    {
        Red, // auto --> 0
        Green, // auto --> 1
        Yellow, // auto --> 2
    }

    enum StudentStatus: long // 32 bit int --> 62 bit int (long)
    {
        IsLocal= 1, // 0x1 0b1
        IsFemale= 1 << 1, // 0x2 // 0b10
        IsMarried= 1 << 2, // 0x4 // 0b100
        IsGraduateStudent= 1 << 3, // 0x8 // 0b1000
        IsLeftHanded= 1 << 4, // 16, 0b10000, 0x10, 
        IsSensitive = IsFemale | IsGraduateStudent
    }

    class Student
    {
        public string Name; // = default(string);
        public int Id ;
        public Color FavoriteColor;
        public StudentStatus Status;

        public bool IsLocal()
        {
            return (this.Status & StudentStatus.IsLocal) > 0; // bit byte and
        }

        public bool IsMarried()
        {
            return (this.Status & StudentStatus.IsMarried) >0;
        }

        public bool IsSenstive()
        {
            return (this.Status & StudentStatus.IsSensitive) == 
                    StudentStatus.IsSensitive;
        }
    }

    class Instructor
    {
        public string Name;
    }

    class Program
    {
        static void PrintId(int id){}

        static void Test()
        {
            double d = 5.0;

            if ((int)d == d)
            {
                // PrintId(d);
            }
        }

        // static void PrintName(Student s)
        // {}

        // static void PrintName(Instructor i)
        // {}

        static void PrintName(object o)
        {
            if (o is Student)
            {
                // Student s = (Student) o;
                Student s = o as Student; // cast behtar error nemide age nashe nullptr mizare
                System.Console.WriteLine($"Student Name is {s.Name}"); // o.Name javab nemide line 54
            }
            else if (o is Instructor)
            {
                Instructor i = (Instructor)o;
                System.Console.WriteLine($"Instructor Name is {i.Name}"); // o.Name javab nemide line 54
            }
            else if(o is string)
            {
                string s = o as string;
                System.Console.WriteLine($"The string is {s}");
            }
            else
            {
                System.Console.WriteLine($"Unknown Type: {o}");
            }
        }
        static void PrintName(object[] objs)
        {
                //   var        array
            foreach(object o in objs) // shabihe python ( for n in names )
            {
                PrintName(o);
            }
            // Color c = (Color) 5;
            // char s;
        }

        static void Main(string[] args)
        {
            Student s = new Student{Name = "Zohreh"}; // be tor pish farz favoritecolor va id va status ro 0 mizare
            Instructor i = new Instructor{Name = "Jaleh"};

            object[] people = new object[6];
            people[0] = s;
            people[1] = i;
            people[2] = new Student{Name = "Ali"};
            people[3] = new Instructor{Name = "Ali Instructor"};
            people[4] = 5; // Boxing
            people[5] = "Alexandra";
            PrintName(people);
            // PrintName(s);
            // PrintName(i);              

            // ** obect --> reference type **
            int j = 42;
            object o = j; // Boxing  stack --> heap (reference type)
            int w = (int)o; // Unboxing  heap --> stack (value type)
            Student s1 = new Student(){Name = "Zahra"};
            s1 = new Student(){Name="Ali"};

            // Nullable<int> --> 0 nist hichi ast etelaati raje behesh nadarim
            // int w;

            // Nullable<int> x;
            // int? x;
            int? x = null; // farghdaran //  class --> ye bool ham dare ke mige meghdar dehi shode ya na (int Value ,bool HasValue)
            int t = 0; // farghdaran

            bool is_t_Assigned = false;
            
            t = 5;
            is_t_Assigned = true;

            if (is_t_Assigned) // (t != 0)
                Console.WriteLine($"number of errors found and is {t}");
            else
                Console.WriteLine($"number of errors unknown");
            
            if (x.HasValue)
                System.Console.WriteLine(x.Value);
            x = 8;
            t = x.Value;
            Console.WriteLine($"number of errors unknown {x.Value}");;
            is_t_Assigned = x.HasValue;
        }
        static void Main1(string[] args)
        {
            Student s = new Student{Name="Zohreh", Id=234, FavoriteColor=Color.Red};
            s.Status = StudentStatus.IsLocal | 
                        StudentStatus.IsSensitive | 
                        StudentStatus.IsMarried;
            
            // ozv haye enum (class) khodeshon ye adad sabetand cali vaghti baraye ye object tarif mishan 0 mishan 
            // ta zamani ke ma biaim beheshon meghdar bedim

            int i = 1 | 4 | 8; // 0b1101

            Color c = (Color) 3; // 3
            c = (Color) 0; // red
            c = (Color) 1; // green
            c = (Color) 2; // yellow

            Console.WriteLine("Hello World!");
        }
    }
}
