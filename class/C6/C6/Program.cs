using System;

namespace C6
{
    class Program
    {
        static void swap(ref int x, ref int y) // ref = reference type --> khodesho mizare
        {
            // C#:ref int , cpp:int&
            int tmp = x;
            x = y;
            y = tmp;
        }

        static void swap(int x, int y) // value type --> copy migire meghdaresho
        {
            int tmp = x;
            x = y;
            y = tmp;
        }

        static void UpdateName(Person p, string newName) // class --> reference type --> khodesho mizare
        {
            p.Name = newName;
        }

        static void UpdateName(PersonV p, string newName) // struct --> value type --> copy migire
        // static void UpdateName(ref PersonV p, string newName)  ref = reference 
        {
            p.Name = newName; // ref = reference type --> khodesho mizare
        }

        static void Main(string[] args)
        {
            Person p = new Person {Name="Ali", Id=298324}; // **syntax**           
            UpdateName(p, "Hooshang");


            PersonV pv = new PersonV {Name = "Alexandra", Id=23423}; // **syntax** 
            UpdateName(pv, "Zahra"); // / struct --> value type --> copy migire (update nemishe)
            // UpdateName(ref pv, "Zahra");  ref = reference 
        }

        static void Main1(string[] args)
        {

            int a=5, b=7;
            swap(ref a, ref b); // khod a ro mizare x va khode b ro mizare y
            Console.WriteLine($"a: {a}, b: {b}");
            Console.WriteLine("a: " + a + " b: " + b);
            Console.WriteLine("a: {0}, b: {1}", a, b); // {0},{1},{2}--> shomare moteghayer 

            a=5; b=7;
            swap(a, b); // megdare a (5) ro copy mikone too  x va megdare b (6) ro copy mikone too  y
            Console.WriteLine("a: {0}, b: {1}", a, b);
        }
    }
}
