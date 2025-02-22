namespace cwork
{
    public class Person //name, natid, ToString()
    {
        public Person(string name, int nationalID)
        {
            Name = name;
            NationalID = nationalID;
        }

        public string Name { get; set; }
        public int NationalID { get; set; }
        public override string ToString()
        {
            return $"name:{Name} -- national ID:{NationalID}";
        }
    }
    //     Derived class  : Base Class
    public class Employee : Person // empid, salary, ToString()
    {
        public int EmployeeId { get; set; }
        public int Salary { get; set; }
        public Employee(string n,int ni , int ei,int s)
        : base(n,ni)
        {
            EmployeeId = ei;
            Salary = s;
        }
        public override string ToString()
        {
            return base.ToString() + $" -- employee Id: {EmployeeId} -- salary: {Salary}";
        }
    } // Ctrl+k+f --> moratab mikone

    //    Derived class  : Base Class
    public class Student : Person // stdid, gpa, ToString()
    {
        public Student(string name,int natid,int studentId, double gpa)
        : base (name,natid)
        {
            StudentId = studentId;
            GPA = gpa;
        }

        public int StudentId { get; set; }
        public double GPA {get;set;}
        public override string ToString()
        {
            return base.ToString() + $"-- StudentID : {StudentId} -- GPA : {GPA}";
        }
    }

    //             Derived class  : Base Class
    public class GradudateStudent : Student // thesis_title, ToString()
    {
        public string ThesisTitle { get; set; }
        public GradudateStudent(string name,int natid,int studentId, double gpa,string thesis_title)
        : base(name,natid,studentId,gpa)
        {
            ThesisTitle = thesis_title;
        }
        public override string ToString()
        {
            return base.ToString() + $"-- thesis title : {ThesisTitle}";
        }
    }

    //      Derived class  : Base Class
    public class Instructor: Employee // teacher_rating
    {
        public Instructor(string n,int ni , int ei,int s , double teacherRating)
        : base(n,ni,ei,s)
        {
            TeacherRating = teacherRating;
        }

        public double TeacherRating { get; set; }
        public override string ToString()
        {
            return base.ToString() + $"-- teacher rating : {TeacherRating}";
        }
    }

}