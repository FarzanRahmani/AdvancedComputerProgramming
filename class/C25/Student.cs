abstract class Person : object // dar vaghe tamam class ha ino joloshon daran
{
    // baraye tarif property ya method abstract bayad class ham abstract bashe
    // Person p = new Person();Cannot create an instance of the abstract type
    public int NatId {get; private set;}
    object o;
    public string Name {get; private set;}

    public bool IsFemale {get; private set;}
    public Person(string name, int natid, bool isFemale)
    {
        this.Name = name;
        this.NatId = natid;
        this.IsFemale = isFemale;
    }

    public abstract void PrintName(); // bayad dar derived class override  (niazi be baz nevisi dare chon tarif nashode)

    public virtual void PrintName1() // niazi be baz nevisi nadare vali age khasti baz nevisi koni override kon mishe override nakard vali manteghi tare override
    {
        if (IsFemale)
            System.Console.WriteLine($"Mrs. {this.Name}");
        else
            System.Console.WriteLine($"Mr. {this.Name}");
    }    

    public void PrintName2(){}

}

class Student: Person
{
    public int StdId {get; private set;}
    public double GPA {get; set;}
    public Student(string name, int natid, int stdid, bool isFemale)
        :base(name, natid, isFemale)
    {
        this.StdId = stdid;
    }
    public override void PrintName()
    {
        if (IsFemale)
            System.Console.WriteLine($"Mrs. Engineer {this.Name} {this.StdId}");
        else
            System.Console.WriteLine($"Mr. Engineer {this.Name} {this.StdId}");
    }    

    public override void PrintName1() // niazi be baz nevisi nadare vali age khasti baz nevisi koni override kon
    {
        if (IsFemale)
            System.Console.WriteLine($"Mrs. {this.Name} -- {this.GPA}");
        else
            System.Console.WriteLine($"Mr. {this.Name} -- {this.GPA}");
    }    
    // public new void PrintName1()
    // {
    //     if (IsFemale)
    //         System.Console.WriteLine($"Mrs. {this.Name} -- {this.GPA}");
    //     else
    //         System.Console.WriteLine($"Mr. {this.Name} -- {this.GPA}");
    // }    

    // public void PrintName2(){}
    // public new void PrintName2(){}
    // public override void PrintName2(){} // nemishe
}

// class BachelorStudent: Student
// {
//     public BachelorStudent(string name, int natid, int stdid, bool isFemale)
//         :base(name, natid, stdid, isFemale)
//         {}
    
//     public override void PrintName()
//     {
//         base.PrintName();
//         System.Console.WriteLine("Printing from BachelorStudent");
//     }
// }


class Employee: Person
{
    public double Salary {get; private set;}
    public Employee(string name, int natid, bool isFemale, double salary)
        :base(name, natid, isFemale)
    {
        this.Salary = salary;
    }
    public override void PrintName()
    {
        if (IsFemale)
            System.Console.WriteLine($"Mrs. Employee {this.Name}");
        else
            System.Console.WriteLine($"Mr. Employee {this.Name}");
    }    
}
