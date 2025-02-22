using System;

namespace C25
{
    class Test // : object
    {
        public override string ToString()
        {
            return "this is my test class";
        }
    }

    class Program
    {
        static void PrintInfo(params Person[] persons) // Polymorphism
        {
            foreach(var p in persons) // ina person hastan vali too deleshon employee?student daran
                p.PrintName();
        }
        
        static void Main(string[] args)
        {
            Test t = new Test(); // chon object ctor dare inam dare
            t.GetHashCode();
            t.GetType();
            t.ToString();
            t.Equals(5);


            // Person p = new Person("ali", 234324, false);

            Student s = new Student("Zahra", 527123344, 99521123, true);
            s.PrintName();

            Person p = new Student("Ali", 342343432, 99521223, false); // dar vaghe p ye Student to delesh dare {Student}
            p.PrintName(); // agar PrintName abstract or virtual nabood PrintName Person ro seda mizad vali inja bara student ro seda mizane
            // p to delesh stdid dare vali be ma nemide --> p.Stdid 

            Employee e = new Employee("hasan", 234324, false, 343243243);

            PrintInfo(s, p, e); // Polymorphism
            
        }
    }
}
