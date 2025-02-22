using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace C15
{
    class ThreadParam
    {
        public int output; // baraye in ke tabe thead khorooji nadare
    }
    class Program
    {
        static object sync_lock1 = new object();
        static void Test(object obj) // mitoonest voroodi ham nadashte bashe
        {
            ThreadParam p = obj as ThreadParam; // cast
            System.Console.WriteLine($"Begin Test - {Thread.CurrentThread.ManagedThreadId}"); // number thread dar hal ejra ro minevise
            for(int i=0; i<10; i++) // i<p.output
            {
                Thread.Sleep(20); // be in thread mige 20 ms vaisa bad edamasho ejra kon
                //The Thread.Sleep() method blocks the current thread for the specified number of milliseconds. In other words, we can say that it suspends the current thread for a specified time.
                lock(sync_lock1) // baraye in ke fahgat yek thread inja ro ejra kone
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    System.Console.WriteLine($"Doing - {Thread.CurrentThread.ManagedThreadId}");
                    Console.ForegroundColor = ConsoleColor.White;
                } // garanti mikone Doing zard beshe
            }
            p.output = 234;
            System.Console.WriteLine($"End Test - {Thread.CurrentThread.ManagedThreadId}");
        }

        static bool JoinAll(Thread[] threads, int timeout)
        {
            foreach(var t in threads)
                if (! t.Join(timeout))
                    return false;
            return true;
        }

        static async Task<int> DownloadAsync() // async --> await
        {
            Stopwatch sw = Stopwatch.StartNew();
            using HttpClient client = new HttpClient();
            string t1 = await client.GetStringAsync(@"http://www.iust.ac.ir");
            string t2 = await client.GetStringAsync(@"http://www.isna.ir");
            string t3 = await client.GetStringAsync(@"http://www.irna.ir");

            System.Console.WriteLine($"{t1.Substring(0, 50)} ... {t1.Length}");
            System.Console.WriteLine($"{t2.Substring(0, 50)} ... {t2.Length}");
            System.Console.WriteLine($"{t3.Substring(0, 50)} ... {t3.Length}");
            return t1.Length + t2.Length + t3.Length; // khodesh int --> Task<int>
        }


        static void Main(string[] args)
        {
            Task<int> t = DownloadAsync();
            System.Console.WriteLine(t.Result);
        }


        static void Main1(string[] args)
        {
            using (HttpClient client = new HttpClient())
            {
                Stopwatch sw = Stopwatch.StartNew();
                // Represents an asynchronous operation that can return a value.
                Task<string> t1 = client.GetStringAsync(@"http://www.iust.ac.ir");
                Task<string> t2 = client.GetStringAsync(@"http://www.isna.ir");
                Task<string> t3 = client.GetStringAsync(@"http://www.irna.ir");

                Task.WaitAll(t1, t2, t3);// Waits for all of the provided Task objects to complete execution.

                System.Console.WriteLine($"{t1.Result.Substring(0, 50)} ... {t1.Result.Length}");
                System.Console.WriteLine($"{t2.Result.Substring(0, 50)} ... {t2.Result.Length}"); // substring --> slice string
                System.Console.WriteLine($"{t3.Result.Substring(0, 50)} ... {t3.Result.Length}");

                System.Console.WriteLine(sw.Elapsed.ToString());
            } // Dispose client
            // nesbat be Main2 sari tare chon ba ham wait ro anjam mide
        }

        static void Main2(string[] args)
        {
            using (HttpClient client = new HttpClient())
            {
                Stopwatch sw = Stopwatch.StartNew();
                string t1 = client.GetStringAsync(@"http://www.iust.ac.ir").Result; // @ --> r python
                string t2 = client.GetStringAsync(@"http://www.isna.ir").Result;
                string t3 = client.GetStringAsync(@"http://www.irna.ir").Result;

                System.Console.WriteLine($"{t1.Substring(0, 50)} ... {t1.Length}");
                System.Console.WriteLine($"{t2.Substring(0, 50)} ... {t2.Length}");
                System.Console.WriteLine($"{t3.Substring(0, 50)} ... {t3.Length}");

                System.Console.WriteLine(sw.Elapsed.ToString());
            } // Dispose
        }


        // Main 3 va 4 bararye khorooji dadane 
        static void Main3(string[] args)
        {
            int w=0;
            Thread t = new Thread(() => { // lambda
                for(int i=0; i<5; i++)
                {
                    System.Console.WriteLine("test");
                }
                w = 5; // class closure w ro pass by ref mikone
            });

            System.Console.WriteLine(w); // 0 minevise
            t.Start();
            System.Console.WriteLine(w); // 0 minevise
            System.Console.WriteLine(Thread.CurrentThread.ManagedThreadId); // 1 --> main
            Thread.Sleep(50);
            System.Console.WriteLine(w); // 5 minevise
            t.Join();
            System.Console.WriteLine(w); // 5 minevise
        }

        static void Main4(string[] args)
        {
            ThreadParam p = new ThreadParam() {output=5}; // pass by ref
            Thread t = new Thread(Test);
            t.Start(p); // p ro mide be Test
            System.Console.WriteLine(p.output);
        }

        static void Main5(string[] args)
        {
            Thread t = new Thread(Test); // Test : khoroojish void ee voroodish ham mitoone () ham mitoone (object)
            t.Start();// run mikone
            t.Join(); // vaimiste ta tamooshe
            t.Join(100); // 100 sanie vaimiste age tamoom shod true mide nashod false mide
            // The Thread.Join() method is used to call a thread and blocks the calling thread until a thread terminates i.e Join method waits for finishing other threads by calling its join method.


            Thread[] threads = new Thread[10];
            for(int i=0;i <10; i++)
            {
                threads[i] = new Thread(Test);
                threads[i].Start(); // run esh mikone
            }

            while (! JoinAll(threads, 10))
                lock(sync_lock1) // C# Lock keyword ensures that one thread is executing a piece of code at one time.
                {
                    System.Console.WriteLine($"Waiting  - {Thread.CurrentThread.ManagedThreadId}");
                }
        
            Thread t1;
            for (int i = 0; i< 10;  i++)
            {
                t1 = new Thread(Test); // dar akhar 10 ta thread darim ke ejra mishe vali ma behesh dastresi nadarim
                t1.Start(); 
            }
        }
    }
}
