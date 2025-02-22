using System;
using System.IO;
using System.Linq;

namespace C23
{
    class Student
    {
        private int _id; // backing field
        public int Id 
        { // full property
            get{
                if (_id < 0)
                    throw new InvalidOperationException("Invalid State, Id is negative");
                return _id;
            }
            set{
                if (value < 0)
                    throw new InvalidDataException("id must be positive");
                _id = value;
            }
        }

        public string Name { get; set; }
        public Student(int id, string name)
        {
            if (id < 0)
                throw new InvalidDataException("id must be positive");
            Name = name;
        }

    }

    class Program
    {

        public static void Main6(string[] args)
        {
            int id = int.Parse(Console.ReadLine());
            string name = Console.ReadLine();
            Student s = new Student(id, name);
            dynamic Amoozesh = null;;
            if (s != null)
                Amoozesh.Register(s);
        }

        // static void test(out int n) // out hamoon ref ee faghat zemanat mikone bayad initialize she
        // {
        //     if (5 + 4 / 2 > 12)
        //         n = 5;
        //     n = 9;
        // }

        static bool GetIntFromConsole(out int n, int from, int to, out bool notInRange)
        {
            notInRange = false;
            if (! int.TryParse(Console.ReadLine(), out n))
                return false;

            if (n < from || n > to)
                notInRange = true;

            System.Console.WriteLine("Got integer from console");
            return true;
        }

        static bool GetIntListFromConsole(int count, out int[] nums, int from, int to, bool[] rangeError)
        {
            nums = new int[count];
            bool all_success = true;
            for(int i=0; i<count; i++)
            {
                bool success= GetIntFromConsole(out nums[i], from, to, out rangeError[i]);
                all_success = all_success && success;
            }

            return all_success;
        }


        static int[] GetIntListFromConsole_Clean_Concise(int count, int from, int to) =>
            Enumerable.Range(1, count).Select(n => GetIntFromConsole(from, to)).ToArray();

        static int[] GetIntListFromConsole_Clean(int count, int from, int to)
        {
            int[] nums = new int[count];
            for(int i=0; i<count; i++)
            {
                nums[i] = GetIntFromConsole(from,to);
            }
            return nums;
        }

        static int GetIntFromConsole(int from=-1, int to=1)
        {
            int n = int.Parse(Console.ReadLine()); // age natoone mire khat 139
            if (n < from || n > to) // throw != catch
                throw new InvalidDataException($"int must be between {from} and {to}"); // age natoone mire khat 143

            System.Console.WriteLine("Got integer from console");
            return n;
        }

        static void Main5(string[] args)
        {
            // Handling Exeption
            try
            {
                int[] nums = GetIntListFromConsole_Clean_Concise(5, -100, 100);
                // Cleanup
            }
            catch(FormatException fe)
            {
                Console.WriteLine($"Don't use my program again! {fe.Message}");
                // Cleanup
            }
            catch(InvalidDataException ide)
            {
                Console.WriteLine($"Try Again! {ide.Message}");
                //Cleanup
            }
            catch(Exception e) // catches all exceptions => bad az in dige catch manayye nadare
            {
                if ( e is InvalidCastException)
                    Console.WriteLine("Miss casting");
            }
            finally // finally ro bad az try XOR catch ejra mikone
            {
                // Cleanup
            }            
        }
        static void Main4(string[] args)
        {
            while(true)
            {
                // Handling Exeption
                try
                {
                    int n = GetIntFromConsole(-9);
                    System.Console.WriteLine(n * n);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);                    
                }
                catch (InvalidDataException idx) // age in nabshe va bere khat 95 un handled exception mide vali inja handle shode ast (too joftesh payam ro minevise)
                {
                    Console.WriteLine(idx.Message);
                }
            }
        }

        static int GetIntFromConsoleCorrectly()
        {
            int n=0;
            while(true)
            {
                // Handling Exception
                try // age try va catch nazani barname unhandled exception mide
                {
                    n = int.Parse(Console.ReadLine()); // age ok bood mire 156 age exception dad mire 158
                    break;
                }
                catch(FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                    continue;
                }                
            }
            return n;
        }

        static void Main3(string[] args)
        {
            while(true)
            {
                // Handling Exception with try and catch
                try
                {
                    string s = Console.ReadLine(); // 5.0, aldsf
                    int n = int.Parse(s); /// age natoone exception mide vali chon handle shode ast mire khat 179 va barname motevaghef nemishe o unhandles exception nemide
                    System.Console.WriteLine(n * n);
                }
                catch (FormatException fe) // catch != throw
                {
                    Console.WriteLine(fe.Message);                    
                }
                catch
                {
                    Console.WriteLine("Exception wasnt FormatExeption");
                }
            }
        }
        static void Main2(string[] args)
        {
            while(true)
            {
                string s = Console.ReadLine(); // 5.0, aldsf
                int n;
                if (int.TryParse(s, out n))
                    Console.WriteLine(n * n);
                else 
                    Console.WriteLine("Try Again!");                
            }
        }
    }
}
