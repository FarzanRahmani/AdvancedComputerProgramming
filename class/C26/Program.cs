using System;

namespace C26
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Account acc = new Account(() => {
                Console.WriteLine("Send SMS to account holder");
            }, 10);
        }
    }
}
