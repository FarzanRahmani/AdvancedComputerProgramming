using System;
using System.Collections.Generic;

namespace C19
{
    class Program2
    {

        static void Main2(string[] args)
        {
            int[] test1 = new int[5];
            List<string> l = new List<string>();
            l.Add("adf");
            l.RemoveAt(0);

            Queue<string> q = new Queue<string>();
            q.Enqueue("ali");
            q.Enqueue("zahra");
            q.Enqueue("hossein");
            while (q.Count > 0)
            {
                string next = q.Dequeue();
                System.Console.WriteLine(next);                
            }

            foreach(var v in q)
                System.Console.WriteLine("test");

            dynamic x = "sdf";
            x.ILoveYou();

            Dictionary<string, int> phonebook = new Dictionary<string, int>();
            phonebook.Add("ali", 12344123);
            phonebook["ali"] = 12341234;
            if (phonebook.ContainsKey("hossein"))
                System.Console.WriteLine(phonebook["hossein"]);

            
        }


        static void Test(double d)
        {}

        static void Test2(Complex c)
        {}

        static void Main3(string[] args)
        {
            Complex c1 = new Complex(1, 2);
            Complex c2 = new Complex(1, 3);
            Complex c3 = c1 + c2;

            Complex c4 = c1 + 5.5;

            Complex c5 = c1++;
            Complex c6 = 5.4;

            Complex c7 = "5i+2.5";

            double w = (double) c7; 

            Test( (double) c7);
            Test2("5i+2");

            Object obj = c7;
            Complex c8 = (Complex) obj;

            c4[0] = 5;
            // c4.Img = 5.5;
            c4["img"] = 5.5;
            double dw = c4["img"];

        }
    }
}
