using System;
using System.IO;

namespace C24
{
    class Program
    {

        static void Main4(string[] args)
        {
            try
            {
                int id = int.Parse(Console.ReadLine());
                string name = Console.ReadLine();
                Student s = new Student(name, id);
            }
            catch(InvalidStudentDataException e)
            {
                Console.WriteLine(e.Message);
                if (e.Id < 0 || e.Name == "Ali")
                    throw;
            }
        }


        static void Main3(string[] args)
        {
            int x = int.MaxValue;
            System.Console.WriteLine(x);
            checked
            {
                x++; // overflowexception
            }
            // x++; // -int.MAxValue // bit akhar ke baraye alamat bood taghir kard
            System.Console.WriteLine(x);
        }

        static int FinallyTest()
        {
            try
            {
                int n = int.Parse("sd");
            }
            catch(FormatException fe)
            {
                if (!fe.Message.Contains("sxx"))
                    throw fe;
            }
            finally
            {
            }
            return 5;
        }

        static void TestA()
        {
            Console.WriteLine("In Test A - Before");
            try
            {
                FinallyTest();
            }
            finally // age be jaye try va finally faghat code benevisi vaghti be exception bekhore dakhel finally ro ejra nemiko
            {
                System.Console.WriteLine("in finally"); // chec exception bede che nade minevise
            }
            Console.WriteLine("In Test A - After"); // age exception bede neminevise hatta age handlesh koni vali age exception nade minevise
        }

        static void TestB()
        {
            Console.WriteLine("In Test B - Before");
            TestA();
            Console.WriteLine("In Test B - After"); // age exception bede neminevise hatta age handlesh koni vali age exception nade minevise
        }


        static void Main2(string[] args)
        {
            try
            {
                TestB();
            }
            catch(FormatException fe)
            {
                if (!fe.Message.Contains("asdf"))
                    // throw; // pas mide be ghabli(khat 47 59 71 81) va dar stack trace zakhire mishe
                    // throw fe; // dige khat 46 etealatesh zakhire nemishe
                    System.Console.WriteLine("OK");
            }

            // using (StreamReader reader = new StreamReader("file.txt"))
            // {}

            StreamReader reader = null;
            try
            {
                reader = new StreamReader("file.txt"); // mire 99 chon chenin file ee nist
                string w = reader.ReadToEnd();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally // garanty mikone ke dispose ejra she
            {
                if (reader != null)
                    reader.Dispose();
            }    
        }

        static void Main1(string[] args)
        {
            try
            {
                int id = int.Parse(Console.ReadLine()); // age exception bede mire to catch ha
                string name = Console.ReadLine();
                Student s = new Student(name, id);
            }
            catch(FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch(InvalidDataException ide) when (ide.Message.Contains("Name"))
            {
                System.Console.WriteLine("Invalid Name");
            }
            catch(InvalidDataException ide) when (ide.Message.Contains("Id"))
            {
                System.Console.WriteLine("Invalid Id");
            }
            catch(InvalidDataException ide) when (ide.Message.Contains("age"))
            {
                System.Console.WriteLine("invalid age");
            }
            catch(NullReferenceException nre)
            {   
                System.Console.WriteLine("nre");     
                System.Console.WriteLine(nre.Message);        
            }
            catch(Exception e) when (e is InvalidDataException || e is NullReferenceException)
            {
                System.Console.WriteLine("ide or nre");
            }
        }
    }
}
