using System;
// csproj hameye file haye dakhele in directory ro be ham rabt mide dige niazi be import nist
class Student // reference type --> heap (hamoon jaii ke malloc mishe)
{
// dar C# bayad joloye har chizi public va private nevesht -- cpp: public:
    public Student(string name, int id) // constructor
    {
        this.Name = name; // cpp: this->Name
        this.StdId = id; // cpp: this->Id
    }


    public string getName() // object
    {
        return this.Name;
    }

    public int getId() // object
    {
        return this.StdId;
    }

    public static int NewStudentId() // static --> class
    {
        return ++s_LastStudentId;
    }
    

    private static int s_LastStudentId = 99521000; // static --> class
    // gherti bazi cpp ro nadare baraye initialize ee static
    private string Name; // object
    private int StdId; // object
} // ; nemikhad mesle cpp


struct StudentV // value type --> stack (mesl int,double,primitive)
{
    public StudentV(string name, int id)
    {
        this.Name = name;
        this.StdId = id;
    }

    public string getName()
    {
        return this.Name;
    }

    public int getId()
    {
        return this.StdId;
    }
    
    private string Name;
    private int StdId;
} // ; nemikhad mesle cpp