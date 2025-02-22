using System;
using System.Threading.Tasks;

namespace L2
{
    class Program
    {
        static void Main(string[] args)
        {
            Fighter f1 = new Fighter("Somaye",85);
            Fighter f2 = new Fighter("Farzan",70);
            while (true)
            {
                f2.Attack(f1);
                f1.Attack(f2);
                Console.ForegroundColor = ConsoleColor.Red;
                f1.PrintInfo();
                Console.ForegroundColor = ConsoleColor.Blue;
                f2.PrintInfo();

                // f1.GameOver += Dead;
                // f2.GameOver += Dead;

                // if (f1.Health <= 0 || f2.Health <=0)
                // {
                //     Dead(f1,f2);
                //     // break;
                //     Environment.Exit(0);
                // }  
                if (f1.Health <= 0)
                {
                    f1.GameOver += Dead;
                    f1.Start(f1,f2);
                    Environment.Exit(0);
                } 
                if (f2.Health <= 0)
                {
                    f2.GameOver += Dead;
                    f2.Start(f1,f2);
                    Environment.Exit(0);
                }       
                Task.Delay(300).Wait();
            }
        }

        public static void Dead(Fighter f1,Fighter f2)
        {
            // f1.PrintInfo();f2.PrintInfo();
            if(f1.Health <= 0)
                Console.WriteLine($"{f2.Name} is the Winner");
            else
                Console.WriteLine($"{f1.Name} is the Winner");
        }
    }
}
