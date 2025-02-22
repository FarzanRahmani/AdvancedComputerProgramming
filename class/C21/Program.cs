using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace C21
{
    static class MyExt
    {

        public static int MyCount<Type>(this IEnumerable<Type> input)
        {
            int c = 0;
            foreach(var e in input)
                c++;
            return c;
        }

        public static Type[] MyToArray<Type>(this IEnumerable<Type> input)
        {
            List<Type> values = new List<Type>(); // List chon be sizesh niaz nadare gozashtim
            foreach(var e in input)
                values.Add(e);
            return values.ToArray();
        }

        public static IEnumerable<Type> Skip3<Type>(this IEnumerable<Type> input, int count)
        {
            var e = input.GetEnumerator();
            for(int i=0; i<count; i++)
                e.MoveNext();
            
            while (e.MoveNext())
                yield return e.Current;
        }
        public static IEnumerable<Type> Skip2<Type>(this IEnumerable<Type> input, int count)
        {
            int i = 0;
            foreach(var e in input)
            {
                if (i >= count)
                    yield return e;
                i++;
            }
        }


        public static int ConvertToInt(string input)
        {
            return int.Parse(input);
        }

        public static IEnumerable<TypeOut> MySelector<TypeIn, TypeOut>(this IEnumerable<TypeIn> input, Func<TypeIn, TypeOut> selector)
        {
            foreach(var e in input)
                yield return selector(e);
        }

        public static Type MyAggregate<Type>(this IEnumerable<Type> input, Func<Type, Type, Type> aggregator)
        {
            if (input == null) 
            {
                Console.WriteLine("Input is null");
                return default(Type);
            }
            if (aggregator == null) 
            {
                Console.WriteLine("aggregator is null");
                return default(Type);
            }
            using (IEnumerator<Type> e = input.GetEnumerator()) {
                if (!e.MoveNext())
                {
                Console.WriteLine("Input is empty");
                return default(Type);
                }
                Type result = e.Current; // avalin onsor
                while (e.MoveNext())
                    result = aggregator(result, e.Current);
                return result;
            }
            ///
            IEnumerator<Type> E = input.GetEnumerator();
            E.MoveNext();
            Type first = E.Current;
            int x = 0;
            foreach(Type i in input)
                {
                if(x > 0)
                    first = aggregator(first, i);
                x++;
                }
            E.Dispose();
            return first;
            ///

            ////
            Type t = default(Type);
            foreach(Type i in input)
                t = aggregator(t, i);
            return t;
            ////
        }

        // TODO: Implement MyWhere like Where
        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> Source,Func<T,bool> predicate)
        {
            if (Source == null) 
                Console.WriteLine("Input is null");

            if (predicate == null) 
                Console.WriteLine("aggregator is null"); 

            foreach(var t in Source)
                if (predicate(t))
                    yield return t;
        }
    }

    class Data // != anonymous class
    {
        public int Year;
        public string Country;
        public double Percentage;
    }
    class Program
    {   
        public static void PrintToConsole( (int x, string y) input)             
        {
            System.Console.WriteLine($"{input.x} ==> {input.y}");
        }

        static void Main4(string[] args)
        {
            // var item = 
            File.ReadLines(@"ChildMortality.csv")
                .Skip(2)
                .Select(s => {
                    var toks = s.Split(',') // string[]
                    .Select(t => t.Trim(new char[]{'\"', ' '})) // IEnumarable<string>
                    .ToArray(); // string[]
                    return new { // anonymous class
                        Country = toks[0], 
                        Year = int.Parse(toks[1].Split(' ')[0]),
                        Both = double.Parse(toks[2].Split(' ')[0])
                    };
                }) // IEnumarable<Anonymous class>
                .GroupBy(d => d.Country) // grooh bandi mikone ba ye common key ke bein bazi ha moshtarake // onaee ke country shon moshtarake too ye grooh mizare
                // .Select(g => (country: g.Key, both: g.Select(d => d.Both).Max())) 
                // .Select(g => new {country= g.Key, both= g.Select(d => d.Both).Max()}) // TODO Average. No test. 
                .Select(g => (country: g.Key, both: g.Select(d => d.Both).Average())) // tuple
                // .Select(g => new {country= g.Key, both= g.Select(d => d.Both).Average()}) // anonymous class 
                .OrderBy(d => d.both) //OrderByDescending
                .Take(10) // bar aks skip
                .ToList()
                .ForEach(d => System.Console.WriteLine($"{d.country} {d.both}"));
        }

        static void Main2(string[] args)
        {
            int x = Enumerable.Range(1, 10).MyAggregate( (x,y) => x+y );  // select : Enumarable<T> --> T
            System.Console.WriteLine(x);
            Random random= new Random();
            int y = Enumerable.Range(1, 10).Select(x => random.Next()).Aggregate( (x,y) => x>y ? x : y);
            System.Console.WriteLine(y);
        }

        static void Main1(string[] args)
        {
            var result = Enumerable.Range(1, 20).Select(n => n*n).Select(n => n.ToString()); // select : Enumarable<TSource> --> Enumarable<TResult>
            File.WriteAllLines("out.txt", result);
            IEnumerator<string> q = result.GetEnumerator();
            string test = q.Current; // null   age int bood 0 mizasht 

            var result1 = File.ReadAllLines("out.txt").MySelector(MyExt.ConvertToInt).ToArray();
            foreach(var r in result1)
                System.Console.WriteLine(Math.Sqrt(r));

            
            PrintToConsole((123, "asdf"));
            var t = (5, "dsfds"); // struct --> value type
            // (int , string) t = (5, "dsfds");
            PrintToConsole(t);

            // ValueTuple<string, int, int, int, int, int> xw = new ValueTuple<string, int, int, int, int, int>();

            ValueTuple<string, int> vt = new ValueTuple<string, int>("test", 5);

            // faghat ba var tarif mishe
            var d = new {Count=5, Sum=15, Division=2}; // Anonymous Type // class : reference type
            int w = d.Count + d.Sum - d.Division;
            // d.Count = 20; read only va faghat getter dare na setter

            (int Count, int Sum, int Division, string ) wt = (4, 7, 12, "test");
            int x = wt.Count + wt.Sum + wt.Division;
            // var wt1 = (Count:2, Sum:5, Division : 9, s : "poi" );

            int n1;
            string s2;
            (n1, _, _, s2) = wt;
            int a = 5;
            int b = 6;
            (a, b) = (b, a); //swap

            ValueTuple<int,int> ttt = new ValueTuple<int, int>(b, a);
            (a, b) = ttt;
        }
    }
}
