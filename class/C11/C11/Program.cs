using System;
using System.Collections.Generic;

namespace C11
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[]{
                new Student("ali", 99521234, 18.2),
                new Student("zahra", 99521334, 19.2),
                new Student("mojdeh", 99521222, 17.2),
                new Student("kiarash", 99521432, 19.2),
                new Student("hasan", 99521112, 15.2),
                new Student("zhaleh", 99521193, 16.2),
                new Student("hossein", 99521154, 14.2),
            };

            Student[] TAs = new Student[]{
                new Student("Ali Hosseini", 99521234, 19.4),
                new Student("Zahra Azhdari", 99521334, 19.2),
            };            

            Course c = new Course("Gholinezhad","rahmani", "Math 101", students, TAs);

            IEnumerable<string> members = c.Members; // Members --> method
            // IEnumerable<T> va IEnumerable Inteface hastan ke mitonan shomaresh shan va yeki yeki beran jolo mesl array va list va ...

            foreach(string member in members)         
                System.Console.WriteLine(member);

            IEnumerable<string> instructors = c.GetInstructors();
            IEnumerator<string> instEnum = instructors.GetEnumerator();

            if (instEnum.MoveNext())
                System.Console.WriteLine(instEnum.Current);

            if (instEnum.MoveNext())
                System.Console.WriteLine(instEnum.Current);

            // while(instEnum.MoveNext())
            // {
            //     System.Console.WriteLine(instEnum.Current);
            // }


            foreach(string s in c.GetAdmins())
                System.Console.WriteLine(s);

            foreach(string s in c.GetInstructors())
                System.Console.WriteLine(s);


            foreach(string m in c)
            {
                System.Console.WriteLine(m);
            }
            

            foreach(string m in c.GetMembers1())
            {
                System.Console.WriteLine(m);
            }



            #region  Hide
            // System.Console.WriteLine(c.Instructor);

            // foreach(Student s in c.Students)            
            //     System.Console.WriteLine(s.Name);            

            // foreach(Student s in c.TAs)            
            //     System.Console.WriteLine(s.Name);
            // Array.Sort(students);
            
            // foreach(Student s in students)
            //     System.Console.WriteLine(s);
            #endregion
        }
    }
}
