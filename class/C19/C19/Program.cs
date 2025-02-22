using System;
using System.Collections.Generic;

namespace C19
{
    class Program
    {

        static void Main2(string[] args)
        { 
            // Collections
            int[] test1 = new int[5];
            List<string> l = new List<string>();
            l.Add("adf");
            l.RemoveAt(0);

            Queue<string> q = new Queue<string>(); // saf
            q.Enqueue("ali"); // bezar too saf
            q.Enqueue("zahra");
            q.Enqueue("hossein");
            while (q.Count > 0)
            {
                string next = q.Dequeue(); // az aval nobat bede behesh kharej kon q.Count--
                System.Console.WriteLine(next);                
            }

            Stack<string> st = new Stack<string>(); // mesl ketab roye ham chidan akharin chizo aval bar midari
            st.Push("Ali");
            st.Push("Farzan");
            st.Push("Somaye");
            string somaye = st.Pop();
            string farzan = st.Pop();
            string ali = st.Pop();

            foreach(var v in q)
                System.Console.WriteLine("test");

            dynamic x = "sdf"; // har chi moitone bashe moghe compile eerad nemigire vale error cashe crash mishe
            x.ILoveYou();

            Dictionary<string, int> phonebook = new Dictionary<string, int>(); // key --> value
            phonebook.Add("ali", 12344123);
            phonebook["ali"] = 12341234;
            if (phonebook.ContainsKey("hossein"))
                System.Console.WriteLine(phonebook["hossein"]);

            
        }


        static void Test(double d)
        {}

        static void Test2(Complex c)
        {}

        static void Main(string[] args)
        {
            Complex c1 = new Complex(1, 2);
            Complex c2 = new Complex(1, 3);
            Complex c3 = c1 + c2;

            Complex c4 = c1 + 5.5;

            Complex c5 = c1++;
            Complex c6 = 5.4; //implicit operator Complex(double from)

            Complex c7 = "5i+2.5"; //implicit operator Complex(string from)

            double w = (double) c7;  //explicit operator double(complex from)


            Test( (double) c7);
            Test2("5i+2");//implicit operator Complex(string from)

            Object obj = c7;
            Complex c8 = (Complex) obj;

            c4[0] = 5;
            // c4.Img = 5.5;
            c4["img"] = 5.5;
            double dw = c4["img"];

        }
    }
}
