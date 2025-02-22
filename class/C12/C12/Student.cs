using System.Collections.Generic;
using System.IO;

interface IPerson
{
    int NationalId {get; set;} // property
}

public class Student: IPerson
{
    public string Name {get; private set;} // default getter setter (property)

    public readonly bool IsFemale; // readonly initializing is just in constructor

    public const int MinId = 99521000; // kolan nemishe behesh dast zad va nayad hatman meghdar behesh dad const = constatnt

    private int _Id; // field or member variable
    public int Id  
    { // property
        get
        {
            return _Id;
        }

        set
        {
            if (value > MinId) // value --> keyword (voroodi set)
                this._Id = value;
        }
    }
    private double _GPA;
    public double GPA
    {
        get
        {
            return this._GPA;
        }

        set
        {
            if (value <= 20 && value >= 0)
            {
                this._GPA = value;

                if (value < 10) // value --> keyword
                    this.IsFailing = true;
            }
            else
                throw new InvalidDataException(); // Error
        }
    }

        public bool SetGPA(double gpa)
    {
        if (gpa <= 20 && gpa >= 0)
        {
            this._GPA = gpa;

            if (gpa < 10)
                this.IsFailing = true;

            return true;
        }

        return false;

    }

    public double GetGPA()
    {
        return this._GPA;
        // double sum = 0;
        // foreach(double g in this.Grades)
        //     sum += g;

        // return sum / this.Grades.Count;
    }

    private List<double> Grades = new List<double>();

    private bool IsFailing;

    public Student(string name, int id, double gpa, bool isFemale=true) // constructor
    {
        this.Name = name; // setter
        this.Id = id; // setter
        this.SetGPA(gpa); // setter
        this.IsFemale = isFemale; // readonly hust in constructor
    }

    private static int LastStdNum; // static --> class (na object)

    private static int NewStdNum
    {
        get => ++LastStdNum; // static function --> static variables
    }

    public static void CreateRandomStudent()
    { // method
        if (MinId > 10)
            System.Console.WriteLine();
    }

    public int NationalId { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

}