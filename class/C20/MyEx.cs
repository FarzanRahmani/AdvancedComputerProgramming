using System;
namespace C20
{
    static class MyWxt
    {
        public static void WriteToConsole(this int[] nums)
        {
            foreach(var n in nums)
                Console.WriteLine(n);
        }

        public static int MySum(this int[] nums)
        {
            int sum = 0;
            foreach(var n in nums)
                sum+= n;
            return sum;
        }
    }
}