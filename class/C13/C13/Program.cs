using System;
using System.Collections.Generic;

namespace C13
{
    public class Program
    {
        // C# va C --> strongly typed              python --> soltan
        delegate int binary_op(int a, int b); // delegate --> typedef C++   function pinter
        delegate bool predicate(int a, int b);

        static int[] combine(int[] a, int[] b, binary_op[] ops) =>
            combine(a, b, ops, always); // nemishod predicate p = always gozasht

        static int[] combine(int[] a, int[] b, binary_op[] ops, predicate p)
        {
            foreach(var op in ops) // var == binary_op  // var --> auto
            {
                a = combine(a, b, op, p);
            }
            return a;
        }

        static int[] combine(int[] a, int[] b, binary_op op, predicate p)
        {
            if (a == null || b == null || a.Length != b.Length)
                return null; // defensive programming

            int[] c = new int[a.Length];
            for(int i=0; i<a.Length; i++)
            {
                if (p(a[i], b[i]))
                    c[i] = op(a[i], b[i]);
                else
                    c[i] = -1;
            }
            return c;
        }

        // delegate binary_op
        static int add(int a, int b) => a + b; // static --> class
        static int sub(int a, int b) => a - b; // lambda function
        static int mul(int a, int b) => a * b;

        // delegate predicate
        static bool always(int a, int b) => true;
        static bool if_even(int a, int b) => a % 2 == 0;

        int div(int a, int b) => a / b;

        // Func --> function pointer amade ( delegate shode avalia --> voroodi dovomia --> khorooji)
        // public delegate TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2);
        public static void Sort<_Type>(_Type[] points,Func<_Type ,_Type , bool> com)
        {
            for (int i = 0; i < points.Length; i++)
                for (int j = i+1; j < points.Length; j++)
                {
                    if (com(points[i],points[j]))
                    {
                        _Type tem = points[i];
                        points[i] = points[j];
                        points[j] = tem;
                    }
                }
        }


        static void Main(string[] args)
        {
            int [] list1 = new int[]{2, 3, 4, 1, 4};
            int [] list2 = new int[]{0, -3, 1, 2, 4};
            // a * 3 + b * 2
            // ? a + b even

            var list3 = combine(list1, list2,
                (a, b) => a * 3 + b * 2, // khodesh noe voroodi va khorooji ro tashkhis mide
                (a, b) => (a + b) % 2 == 0 // lambda function
            );

            // var ops = new binary_op[] {
            //     (a,b)=>a+b, 
            //     (a,b)=>a*b, 
            //     (a,b)=>a-b
            // };


            // binary_op my_op = (a, b) => a * 3 + b * 2; // mesl int a = 5;
            // predicate p = (a, b) => (a + b) % 2 == 0;
            // var list4 = combine(list1, list2, my_op, p);

            // var list5 = combine(list1, list2,
            //     new binary_op[] {
            //         (a,b)=>a+b,
            //         (a,b)=>a*b,
            //         (a,b)=>a-b
            //     }
            // );

        }

        static void Main1(string[] args)
        {
            int [] list1 = new int[]{2, 3, 4, 1, 4};
            int [] list2 = new int[]{0, -3, 1, 2, 4};

            var ops = new binary_op[] {add, mul, sub};
            var opslist = new List<binary_op>(ops); // voroodi list bayad IEnumarable bashe mesl ops
            // Program p = new Program();
            // opslist.Add(p.div);
            opslist.Add(new Program().div);


            // list1 = combine(list1, list2, ops);
            list1 = combine(list1, list2, add, if_even);
        }
    }
}
