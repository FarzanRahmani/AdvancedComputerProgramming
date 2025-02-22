using System;
using System.Diagnostics;

namespace E1
{
    class Program
    {
        static void Main(string[] args)
        {
            // MakeSmallTestCase();
            // MakeLargeTestCase();
        }

        // private static void MakeLargeTestCase()
        // {
        //     Stopwatch sw = Stopwatch.StartNew();
        //     var m1 = Matrix<IntWithOp>.RandomMatrix(500, 400);
        //     m1.SaveToFile("m1.txt");
        //     var m2 = Matrix<IntWithOp>.RandomMatrix(400, 500);
        //     m2.SaveToFile("m2.txt");
        //     var m3 = m1.MultiplyBy(m2);
        //     m3.SaveToFile("m3.txt");
        //     //var m3 = m1 * m2;
        //     Console.WriteLine(sw.Elapsed);
        //     //sw.Restart();
        //     //var m3 = m1.MultiplyBy_ParallelFor(m2);
        //     //Console.WriteLine(sw.Elapsed);
        //     //sw.Restart();
        //     //m3 = m1.MultiplyBy_Thread(m2);
        //     //Console.WriteLine(sw.Elapsed);

        // }

        // static void MakeSmallTestCase()
        // {
        //     var m1 = Matrix<IntWithOp>.RandomMatrix(3,2);
        //     var m2 = Matrix<IntWithOp>.RandomMatrix(3,2);
        //     var m3 = m1 + m2;
        //     m1.SaveToFile("test_case1_lhs.txt");
        //     m2.SaveToFile("test_case1_rhs.txt");
        //     m3.SaveToFile("Test_case1_out.txt");

        //     m1 = Matrix<IntWithOp>.RandomMatrix(3, 2);
        //     m2 = Matrix<IntWithOp>.RandomMatrix(2, 3);
        //     m3 = m1 * m2;
        //     m1.SaveToFile("test_case2_lhs.txt");
        //     m2.SaveToFile("test_case2_rhs.txt");
        //     m3.SaveToFile("Test_case2_out.txt");


        //     var m4 = Matrix<DoubleWithOp>.RandomMatrix(5, 2);
        //     var m5 = Matrix<DoubleWithOp>.RandomMatrix(5, 2);
        //     var m6 = m4 + m5;
        //     m4.SaveToFile("test_case3_lhs.txt");
        //     m5.SaveToFile("test_case3_rhs.txt");
        //     m6.SaveToFile("Test_case3_out.txt");


        //     m4 = Matrix<DoubleWithOp>.RandomMatrix(2, 5);
        //     m5 = Matrix<DoubleWithOp>.RandomMatrix(5, 2);
        //     m6 = m4 * m5;
        //     m4.SaveToFile("test_case4_lhs.txt");
        //     m5.SaveToFile("test_case4_rhs.txt");
        //     m6.SaveToFile("Test_case4_out.txt");
        // }
    }
}
