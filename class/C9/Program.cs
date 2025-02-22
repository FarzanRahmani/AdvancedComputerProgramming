using System;
using System.Collections.Generic;
using System.Collections;

namespace C9
{
    interface IAddable // I --> Interface(standard or vizhegi or khasiat)
    {
        void AddToMe(IAddable o);
        int GetValue();
    }

    class Number: IAddable
    {
        public int a;

        public int GetValue() => a;
        public void AddToMe(IAddable x) // moteghayeri ke in vizheghi ro dare (IAddable x)
        {
            // IAddable a = new Student();
            a += x.GetValue();
        }
    }

    class Student: IAddable // in Interface(standard or vizhegi or khasiat) dare
    {
        public string Name;
        public int Id;
        public double GPA;

        public int GetValue() => (int) GPA; // IAddable

        public void AddToMe(IAddable x) // IAddable
        {
            GPA += x.GetValue();
        }

        // ToString defaul miad namespace + type ro minevise
        public override string ToString() // override bara thagire yan ye tabe ToString darim ke ghabel taghir neveshte shode
        {
            return $"Student: {Name}: {Id}";
        }
    }

    class Employee: IAddable // in Interface(standard or vizhegi or khasiat) dare
    {
        public string Name;
        public int Id;
        public double Rating;

        public void AddToMe(IAddable o)
        {
            Rating += o.GetValue();
        }

        public int GetValue()
        {
            return (int) Rating;
        }

        public override string ToString() // override --> laghv ya batel kardan (ToSrting default ro tagir(batel) mikone ino mizare jash)
        {
            return $"Employee: {Name}: {Id}";
        }        
    }

    class Program
    {

        static void GenericPrintPeople<_Type>(_Type[] people) // _Type or _farzanType or ...
        {
            foreach(_Type p in people) // generic --> omoomi
                Console.WriteLine(p.ToString());            
        }

        static void Swap(ref int a, ref int b) // pass bey reference
        {
            int t = a;
            a = b;
            b = t;
        }

        static void Swap(ref double a, ref double b)
        {
            double t = a;
            a = b;
            b = t;
        }

        static void Swap(ref object a, ref object b)
        {
            object t = a;
            a = b;
            b = t;
        }

        static void Swap<_MyType>(ref _MyType a, ref _MyType b) // 3 ta balee dar yeki
        {
            _MyType t = a;
            a = b;
            b = t;
        }

        static _AddableType Add<_AddableType>(_AddableType a, _AddableType b) where
            _AddableType: IAddable // _AddableType is IAddable(has this property(interface))        
        {
            a.AddToMe(b);
            return a;
        }


        static void PrintPeople(object[] people)
        {
            foreach(object p in people)
            {
                // if (p.GetType() == typeof(Student))
                if (p is Student)
                {
                    Student s = p as Student; // (Student) p
                    Console.WriteLine(s.ToString() + $"GPA: {s.GPA}");
                }
                else if (p is Employee)
                {
                    Employee e = p as Employee;
                    Console.WriteLine(e.ToString() + $"Rating: {e.Rating}");
                }
            }
        }

        static void PrintPeople2(object[] people)
        {
            foreach(object o in people)
                Console.WriteLine( o?.ToString() ); // *** ?. ***

            foreach(object o in people)
                if (o is not null)
                    Console.WriteLine( o.ToString() ); // age if nabashe va o null bashe ToString error mide
        }

        static void Main(string[] args)
        {
            Student s1 = new Student();
            Student s2 = new Student();
            Student s3 = Add<Student>(s1, s2);
            Number n1 = new Number() {a = 5};
            Number n2 = new Number() {a = 7};
            Number x = Add<Number>(n1, n2);
            int z = default(int);// dar C# har moteghayer ye defaukt value dare ke masaln int 0 va ref ha null hastan
            
        }
            
        static void Main2(string[] args)
        {
            List<int> nums = new List<int>(); // By default List<_Type>
            nums.Add(5);
            nums.Add(4);
            int s = 0;
            foreach(int n in nums)
                s += n;

            ArrayList alNums = new ArrayList(); // ArrayList = List<Object>
            alNums.Add(5);
            alNums.Add(3);
            alNums.Add("sdfds");
            alNums.Add(3.4);
            foreach(object n in alNums)
            {
                int nn = (int) n; // "sdfds" --> error
                s += nn;
            }



            int a = 5;
            int b = 6;
            Swap<int>(ref a, ref b);
            // System.Console.WriteLine(Add(a, b));

            double c = 5.5;
            double d = 4.1;
            Swap<double>(ref c, ref d);
            // double g = Add(c, d);
        }

        static void Main1(string[] args)
        {
            Student[] students= new Student[]{ 
                new Student() {Name="Zhaleh", Id=99521322, GPA=19.5},
                new Student() {Name="Sohrab", Id=99522422, GPA=19}
            };

            Employee[] employees= new Employee[]{ 
                new Employee() {Name="Zhaleh", Id=99521322, Rating=3},
                new Employee() {Name="Sohrab", Id=99522422, Rating=4}
            };

            GenericPrintPeople<Student>(students); // generic --> omoomi
            GenericPrintPeople<Employee>(employees); // compiler Employee ro mizare be jaye _Type va ye tabe misaze bad ejra mikone

            // Object[] people = new object[5];
            // people[0] = s;
            // people[1] = e;

            // PrintPeople(people);
        }
    }
}
