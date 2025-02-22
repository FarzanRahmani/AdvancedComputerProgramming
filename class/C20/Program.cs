using System;
using System.Linq; // ***
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace C20
{
    class Student
    {
        public Student(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }

// Dictinary
        public override bool Equals(object obj)
        {
            Student other = obj as Student;
            if (other != null)
                return this.Name.Equals(other.Name) && this.Id.Equals(other.Id); // bar in asas check mikene na address
            return false;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Id.GetHashCode(); // ^ --> XOR  // Good : faster
            // return 0; // Bad : slower     
        }
// Dictinary

        public override string ToString()
        {
            return this.Name.ToString() + " " + this.Id.ToString();
        }

        public string Name {get; set;}
        public int Id {get; set;}

        public static Student ReadFromConsole()
        {
            System.Console.Write("Name? ");
            string name = Console.ReadLine();
            System.Console.Write("Id? "); // write nemire khat bad vali writeline mire
            int id = int.Parse(Console.ReadLine());
            return new Student(name, id);
        }
    }
    static class Ext // Extensions // static class --> hame chish static ee
    {
        public static void WriteToConsole<_Type>(this _Type[] nums) // *** this *** nums.WriteToConsole
        {
            System.Console.WriteLine(string.Join(",", nums));
        }

        public static void MyForEach<_Type>(this _Type[] values, Action<_Type> action)
        {
            foreach(var v in values)
                action(v);
        }
    }
    class Program
    {        
        static void Main3(string[] args)
        {
            // LINQ extension functions ro faraham karde baraye ma
            string w = "test";
            string w1 = w.ToUpper();
            int len = w1.Length;
            int mylen = w.ToUpper().Length;

            var item = 
            File.ReadLines(@"ChildMortality.csv")
                .Skip(2)
                .Select( (string s) => {
                    var toks = s.Split(',').Select(t => t.Trim(new char[]{'\"', ' '})).ToArray(); // " nemishe be trim dad chon baraye taeen string ee bayad \"
                    return new { // Anonymous Class --> Anonymous Types
                        Country = toks[0], 
                        Year = int.Parse(toks[1].Split(' ')[0]),
                        Both = double.Parse(toks[2].Split(' ')[0])
                    };
                })
                .Where(d => d.Country.StartsWith("Iran")) // filter mikone (shart ro check mikkone) // harchi be joz iran ro pak mikone az to Enumerable<'a>
                .Aggregate( (d1, d2) => d1.Both > d2.Both ? d1 : d2); // roye hame aza az aval ta akhar mizane yeki ro mide

            System.Console.WriteLine($"{item.Country} - {item.Year} - {item.Both}");
        }

        static void Main2(string[] args)
        {
            int[] nums = new int[]{2, 3, 5, 4, 7, 9};
            nums.WriteToConsole(); // Extension function
            Ext.WriteToConsole(nums);

            string[] names = new string[]{"ali", "maryam", "mozhdeh", "kianoosh"};
            names.WriteToConsole();
            int s = nums.MySum(); // mitoone to ye folder dige ham bashe


            names.MyForEach((n) => { // *this* --> voroodi aval ro mide
                Console.WriteLine($"name: {n}");
            });

            List<int> lnums = new List<int>();
            lnums.ForEach((n) => Console.WriteLine(n));
        }

        static void Main(string[] args)
        {
            // Dictionary : GetHashCode --> {..,..,..} --> Equals // dorost benevisi kodet sari tar mishe // har chi unique tar bashe sari tare    
            Dictionary<Student, double> grades = new Dictionary<Student, double>(); // key : student   value : double
            var s1 = new Student("ali", 99521123);
            var s2 = new Student("maryam", 99521231);
            grades[s1] = 18.5;
            grades[s2] = 19;

            System.Console.WriteLine($"{s1.Name}: {grades[s1]}");
            System.Console.WriteLine($"{s2.Name}: {grades[s2]}");

            // Stopwatch sw = Stopwatch.StartNew();
            // for(int i=0; i<10_100; i++)
            // {
            //     var ns = new Student((i/1000).ToString(), i);
            //     grades[ns] = i; // vaghti gethashcode student unique tar va behtar bashe sari tar ejra mishe
            // }
            // System.Console.WriteLine(sw.Elapsed.ToString());

            // sw.Restart();
            // Student snf = new Student("hossein", 999213412);
            // for(int i=0; i<1000; i++)
            //     if (grades.ContainsKey(snf))
            //         System.Console.WriteLine(snf); // vaghti gethashcode student unique tar va behtar bashe sari tar ejra mishe           
            // System.Console.WriteLine(sw.Elapsed.ToString());
            while (true)
            {
                var s = Student.ReadFromConsole(); 
                if (grades.ContainsKey(s)) // ta gethashcode va equals ro avaz nakoni kar nemikone chon to dari ye object dige behesh midi
                    System.Console.WriteLine($"{s.Name}: {grades[s]}"); // grades faghat s1 va s2 ro dare // Equals be tor pish farz address ro checck mikone
                else
                    System.Console.WriteLine("Not Found");
            }
        }
    }
}
