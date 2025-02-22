using System;
using System.Collections;
using System.Collections.Generic;

namespace C11
{
    public class Course : IEnumerable<string> // Enumarator esh string bar migardoone be jaye object
    {
        #region h
        public string Instructor;
        public string AssistnatInstructor;
        public Student[] Students;

        public Student[] TAs;
        public string Name {get; set;} // method ee moteghaye nist shabih moteghayer amal mokine 
        // chap be rast --> get           rast be chap --> set

        public Course(string instructorName,string assistnatinstructor, string name, Student[] students, Student[] TAs) // constructor khorooji nemikhad
        {
            this.Instructor = instructorName;
            this.AssistnatInstructor = assistnatinstructor;
            this.Name = name;
            this.Students = students;
            this.TAs = TAs;
        }

        public IEnumerable<string> GetInstructors() // ba in kar donbale ii az string ha kharej mishe ke karbordesh dar foreach ee
        {
            yield return this.Instructor;
            yield return this.AssistnatInstructor;
            // You use a yield return statement to return each element one at a time. The sequence returned from an iterator method can 
            // be consumed by using a foreach statement or LINQ query. Each iteration of the foreach loop calls the iterator method.
        }

        public IEnumerable<string> GetAdmins()
        {
            yield return this.Instructor;
            yield return this.AssistnatInstructor;
            foreach (Student s in this.TAs)
                yield return s.Name;
        }


        public IEnumerable<string> Members
        {
            get
            {
                foreach (Student s in this.Students)
                    yield return s.Name;

                foreach (Student s in this.TAs)
                    yield return s.Name;
                yield return this.Instructor; 
                yield return this.AssistnatInstructor;           
            }
        }

        #endregion

        public IEnumerator<string> GetEnumerator()
        {
            return new CourseEnumerator(this); // this --> course
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CourseEnumerator(this);
        }        

        #region  Hide
        public IEnumerable<string> GetMembers1()
        {
            List<string> members = new List<string>();
            members.Add(this.Instructor);
            foreach (Student s in this.Students)
                members.Add(s.Name);

            foreach (Student s in this.TAs)
                members.Add(s.Name);

            return members;
        }
        #endregion
    }

    public class CourseEnumerator : IEnumerator<string> // , IComparable<string>
    {
        private Course Course;
        // private string Current;
        public CourseEnumerator(Course c) // constructor
        {
            this.Course = c;
        }
        private int Pos = -1; // Sets the enumerator to its initial position, which is before the first element

        string IEnumerator<string>.Current 
        {
            get
            {
                if (Pos == 0)
                    return this.Course.Instructor;
                if (Pos == 1)
                    return this.Course.AssistnatInstructor;
                else if (Pos < this.Course.TAs.Length + 1 + 1)
                    return this.Course.TAs[Pos-1-1].Name;
                else  
                    return this.Course.Students[Pos-this.Course.TAs.Length-1-1].Name;
            }
        }

        public object Current => this.Current;
        // object IEnumerator.Current
        // {
        //     get
        //     {
        //         return this.Current;
        //     }
        // }
        
        public void Dispose()
        {}
        public bool MoveNext()
        {
            this.Pos++;
            return this.Pos < this.Course.TAs.Length + this.Course.Students.Length + 1 + 1;
        }
        public void Reset()
        {
            this.Pos = -1;
        }
    }
}