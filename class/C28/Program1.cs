using System;
using System.Text.RegularExpressions;

namespace C28
{
    abstract class Person
    {
        string Name;
        public abstract void PrintName();
    }
    class Student: Person
    {
        double GPA;
        public sealed override void PrintName() { System.Console.WriteLine(1);}
        // The method that is defined in a parent class, if that method cannot be overridden under a child class,
        //  we call it a sealed method. By default, every method is a sealed method because overriding is not 
        //  possible unless the method is not declared as virtual in the parent class.
    }

    sealed class GraduateStudent: Student // sealed --> nemishe azash be erth bord 
    {
        // public override PrintName(){System.Console.WriteLine(2);}
    }

    // class test : GraduateStudent {}

    class Program1
    {
        static void Main1(string[] args)
        {
            // Ctrl + f => search
            string w = "ali's email is ali@en.yahoo.com and he lives in Tehran and his mother's email is maryam@gmail.com";
            Regex regex = new Regex(@"[A-Za-z_1-9]+@([a-z]+\.)+[a-z]+"); // [A-Za-z_1-9] : shayad _ ham dashte bashe
            // [A-Z] --> from A to Z  [1-9] --> from 1 to 9  
            // + -> had aghal yeki
            // * -> har chand ta 
            // . --> tamam character(or class) ha
            // \. --> khod noghte
            foreach(Match match in regex.Matches(w))
            {
                System.Console.WriteLine(match.Value);
            }
            GraduateStudent t = new GraduateStudent();
            t.PrintName();

        }
    }
}
