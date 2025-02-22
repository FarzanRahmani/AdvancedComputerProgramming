using System;
namespace C11
{
    public class Student: IComparable<Student>
    {
        public Student(string name, int stdNum)
            : this(name, stdNum, 20)
        {}

        public Student(string name)
            : this(name, NewStdNum(), 20)
        {}

        public Student(string name, int stdNum, double GPA)
        {
            this.Name = name;
            this.StdId = stdNum;
            this.GPA = GPA;
        }

        public override string ToString()
        {
            return $"{this.Name}\t{this.StdId}\t{this.GPA}";
        }

        // public string Name
        // {
        //     get
        //     {
        //         return this._Name.ToUpper();
        //     }
        //     set
        //     {
        //         // string s = null; = ""; = "     "
        //         // if (s == null || s == "" || s.Trim() == ""
        //         // string s = "  .,  asdfa    ";
        //         // string w = s.Trim(new char[]{' ', ',', '.'}); // "asdfa"
        //         if (!string.IsNullOrWhiteSpace(value))
        //             this._Name = value;
        //     }
            
        // }

        // private string _Name;
        public string Name;
        public int StdId;
        public double GPA; 

        private static int LastStdNum = 99521000;
        private static int NewStdNum() => ++LastStdNum;

        public int CompareTo(Student other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}