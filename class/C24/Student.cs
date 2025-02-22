using System;
using System.IO;


public class Person
{
    public int NationalId;
    public int Age;

    public bool Voted;
    public bool Vote(string candidate)
    {
        this.Voted = true;
        return true;
    }
}

//    Derived class  : Base Class
public class Student : Person
{
    public string Name { get; set; }
    public int Id { get; private set; }
    public Student(string name, int id)
    {
        if (this.Age > 50)
            throw new InvalidOperationException();

        if (!this.Voted)
            throw new InvalidDataException();

        if (id < 0)
        {
            var ide = new InvalidStudentDataException(name, id, "Id must be positive");
            throw ide; // age to stact balaee hash catch bashe handle mishe va gar na unhandled exception mide
        }

        if (name == null)
            throw new NullReferenceException();

        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidDataException("Name can't be empty");

        Exception e;
        this.Name = name;
        this.Id = id;
    }
}

//                 Derived class  : Base Class
class InvalidStudentDataException : Exception
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Student StudentObject { get; set; }

    public InvalidStudentDataException(string name, int id, string msg) // constuctor base ro seda zadim ke message migire
        : base($"invalid data {msg}, name: {name} id:{id}") 
    {
        this.Id = id;
        this.Name = name;
    }

    public InvalidStudentDataException(Student s, string msg)
        : base($"invalid data {msg}, name: {s.Name} id:{s.Id}")
    {
        this.Id = s.Id;
        this.Name = s.Name;
        this.StudentObject = s;
    }
}