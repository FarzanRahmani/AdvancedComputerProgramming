using System;
using System.Collections.Generic;

namespace C14
{
    public class Program
    {
        #region  Hide
        static int add(int a, int b) => a + b;
        static _T[] Perform<_T>(_T[] a, _T[] b, Func<_T,_T,_T> op) // Func --> delegate amade ba khorroji
        {
            _T[] c = new _T[a.Length];
            for(int i=0; i<a.Length; i++)
                c[i] = op(a[i], b[i]);
            return c;
        }

        static void do1(int a)
        {}

        static Random rnd = new Random();

        // Func<int>
        static int get_random()
        {
            return rnd.Next();
        }

        static void PrintRndNums(int count, Func<int> rndGen)
        {
            for(int i=0; i<count; i++)
            {
                int rnd = rndGen(); // faghat khrooji bedoone voroodi
                System.Console.WriteLine(rnd);
            }                
        }

        static void Do(int[] nums, Action<int> action)
        {
            foreach(var n in nums)
                action(n); // Action khrooji nadare
        }

        // delegate void MyAction(int a, int b);
        static void Print(int i) 
        {
            System.Console.WriteLine(i); // Action<int>
        } 
        #endregion        
        
        static void Test()
        {
            System.Console.WriteLine("In Test");
        }

        // delegate int MyDelegate(int a, int b);
        // static int myop(int a, int b) => a + b;

        public static void TestAction(int[] nums, 
            Func<int, int>[] ops,
            Func<bool>[] iffs,
            Action<int>[] dofs)
        {
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] % 4 == 0)
                    ops[j] = (x) => x + 5;
                else if (nums[j] % 4 == 1)
                    ops[j] = (a) => a * 5;
                else if (nums[j] % 4 == 2)
                    ops[j] = (a) => a - 5;
                else
                    ops[j] = (b) => b / 5;

                iffs[j] = () => true;

                if (nums[j] % 2 == 0)
                {
                    dofs[j] = (x) => {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(x);
                    };
                }
                else
                {
                    dofs[j] = (y) => {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(y);
                    };
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = ops[i](nums[i]);
                if (iffs[i]())
                {
                    dofs[i](nums[i]);
                }
            }

            // update nums[i] with op and if (iff is true for nums[i]) action dof nums[i]
            // if nums[i] % 4 = 0 , + 5
            // if nums[i] % 4 = 1 , * 5
            // if nums[i] % 4 = 2 , - 5
            // if nums[i] % 4 = 3 , / 5
            // if nums[i] % 2 == 0, cw, red
            // if nums[i] % 2 == 1, cw, blue
            //Console.ForegroundColor = ConsoleColor.Red
        }

        static void Main(string[] args)
        {
            // List<Func<bool>> iffList = new List<Func<bool>>();
            // int iff_counter = 0;
            // for (int i=0; i<10; i++)
            // {
            //     Func<bool> iffa = () => {
            //         bool returnValue = iff_counter % 2 == 0;
            //         iff_counter++;
            //         return returnValue;
            //     };
            // }
            // TestAction(, , iffList, ..)

            int[] f = new int[] {1,2,3,4};
            Func<int , int> [] functions = new Func<int, int> [f.Length];
            Func<bool> [] ifFunctions = new Func<bool> [f.Length];
            Action<int> [] actionFunctions = new Action<int> [f.Length];
            TestAction(f,functions,ifFunctions,actionFunctions);


            // // List<MyDelegate> testList = new List<MyDelegate>();
            // // testList.Add(myop);

            // // List<Func<int,bool>> funcs = new List<Func<int,bool>>();

            List<Action> funcs = new List<Action>(); // Action --> tabe ii ke voroodi va khrooji nadare
            funcs.Add(Test);
            for(int i=0; i<10; i++)
            {
                // vaghti voroodi nadare () bezar
                // tabe ra seda nemizanim faghat tarif mikonim
                // moteghayera ro pass by ref mikone ba class ii be name closure
                Action a = () => 
                {
                    System.Console.WriteLine(i);
                    i++;
                };
                funcs.Add(a);
                a();
            }

            foreach(var fn in funcs)
                fn(); // i dar hamashoon moshtarake 
        }

        static void Main1(string[] args)
        {
            int[] l1 = new int[] {1,2,3,4};
            int[] l2 = new int[] {3,4,1,2};
            int[] l3 = Perform<int>(l1, l2, (k,s) => k+s);

            
            // function pointer
            // Func --> delegate amade ba khorroji
            // Action --> delegate amade badoone khrooji (void)
            int c = 10;
            // moteghayeri ke mesl tabe raftar mikone
            Action<int> myAction = (a) => {
                for(int i=0; i<a; i++)
                    System.Console.WriteLine(a+c); // c ro mishnase chon moteghayera dar class i be name closure pass by ref mishan
                System.Console.WriteLine("Done");
            }; // lambda expression

            myAction(5);
            Do(l1, myAction);

            Do(l1, (a) => {
                for(int i=0; i<a; i++)
                    System.Console.WriteLine(a);
                System.Console.WriteLine("Done");
            });
            // Do(l1, Print);

            Console.WriteLine("Hello World!");
        }
    }
}
