using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace C16
{
    class InOut<_Type>
    {
        public _Type In {get; set;}
        public _Type Out {get; set;}
    }

    class Program
    {
        static void Test(object obj) // voroodi hamishe object baraye Task va Thread
        {
            int x = (int) obj;
            for(int i=0; i<x; i++)
            {
                System.Console.WriteLine($"Start {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(500);
                System.Console.WriteLine($"End {Thread.CurrentThread.ManagedThreadId}");            
            }
        }

        static long Test2(object obj) // voroodi hamishe object , long --> Task<long>
        {
            Stopwatch sw = Stopwatch.StartNew();
            int x = (int) obj;
            for(int i=0; i<x; i++)
            {
                System.Console.WriteLine($"Start {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(500);
                System.Console.WriteLine($"End {Thread.CurrentThread.ManagedThreadId}");            
            }
            return sw.ElapsedMilliseconds;

        }

        static async Task<long> DoWorkAsync()
        {
            // long l1 = await new Task<long>( () => {
            long l1 = await Task.Run( () => {
                Stopwatch sw = Stopwatch.StartNew();
                System.Console.WriteLine("Boiling Water");
                return sw.ElapsedMilliseconds;
            });
            // long l2 = await new Task<long>( () => {
            long l2 = await Task.Run( () => {
                Stopwatch sw = Stopwatch.StartNew();
                System.Console.WriteLine("Add Beans");
                return sw.ElapsedMilliseconds ;
            });
            // long l3 = await new Task<long>( () => {
            long l3 = await Task.Run( () => {
                Stopwatch sw = Stopwatch.StartNew();
                System.Console.WriteLine("Add Meat");
                return sw.ElapsedMilliseconds;
            });
            return l1 + l2 + l3;
        }

        static void Main(string[] args)
        {
            Task<long> lt = DoWorkAsync();
            lt.Wait();
            System.Console.WriteLine(lt.Result);
        }
        static void Main3(string[] args)
        {
            // Task<long> t1 = new Task<long>( () => {
            Task<long> t1 = Task.Run( () => {
                Stopwatch sw = Stopwatch.StartNew();
                System.Console.WriteLine("Boiling Water");
                return sw.ElapsedMilliseconds;
            }).ContinueWith( (Task<long> t) => { // t1 --> t
                Stopwatch sw = Stopwatch.StartNew();
                System.Console.WriteLine("Add Beans");
                return sw.ElapsedMilliseconds + t.Result;
            }).ContinueWith( (t) => {
                Stopwatch sw = Stopwatch.StartNew();
                System.Console.WriteLine("Add Meat");
                return sw.ElapsedMilliseconds + t.Result;
            });
            // t1.Start(); inja vahgti t1 ro start mizzni akharin chizi ke to continue with hast start mikhore
            // int t = t1.ToString().Length;
            // dari roo ye chizi continue with miazni ke start nakhorde
            
            t1.Wait();
            System.Console.WriteLine(t1.Result);
        }

        static void Main4(string[] args)
        {
            Task t1 = Task.Delay(1000).ContinueWith((Task t) => System.Console.WriteLine("Eslamikhah Turn")); // t --> t1
            Task t2 = Task.Delay(500).ContinueWith((Task t) => System.Console.WriteLine("NaebZadeh Turn")); // t --> t2
            Task t3 = Task.Delay(100).ContinueWith((Task t) => System.Console.WriteLine("Rahmani Turn")); // t --> t3
            Task t4 = Task.Delay(400).ContinueWith((Task t) => System.Console.WriteLine("Vafaei Turn")); // t --> t4

            // Task.WaitAll(t1, t2, t3, t4);
            t1.Wait(); // be thread asli mige vaisa ta in task tamoom she
            // Thread.Sleep(2000);
        }


        static void Main5(string[] args)
        {
            System.Console.WriteLine("Test 1");

            Task t = Task.Delay(2500);// moadel
            Task mt = Task.Run(() => Thread.Sleep(2500));

            System.Console.WriteLine("Test 2");
            t.Wait();
            System.Console.WriteLine("Test Done");
            mt.Wait();
            System.Console.WriteLine("Hello");
        }


        static void Main6(string[] args)
        {
            List<Task> tasks = new List<Task>();
            for(int i=0; i<10; i++)
            {
                Task t = new Task((object obj) => {
                    int n = (int) obj;
                    System.Console.WriteLine($"Start {n} {Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(100);
                    System.Console.WriteLine($"End {n} {Thread.CurrentThread.ManagedThreadId}");
                }, i); // inja ke dare misaze class task ro meghdar ko nooni i ro mirize to ye motagheyr dakhele class
                t.Start();
                // Task.Delay(100).Wait(); // Thread.Sleep(100);                
                tasks.Add(t);
            }
            Thread.Sleep(100);
            System.Console.WriteLine("Done Creating Tasks.");
            Task.WaitAll(tasks.ToArray());
        }

        static void Main7(string[] args)
        {
            List<Task> tasks = new List<Task>();
            for(int i=0; i<10; i++)
            {
                // i --> pass by ref in closure class
                Task t = Task.Run(() => {
                    System.Console.WriteLine($"Start {i} {Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(100);
                    System.Console.WriteLine($"End {i} {Thread.CurrentThread.ManagedThreadId}");
                }); // Run ham misaze ham start mizane
                tasks.Add(t);
            }
            Task.WaitAll(tasks.ToArray()); // hama ro 10 nevesht ke
        }
        static void Main8(string[] args)
        {
            Task<long> t = new Task<long>(Test2, 6); // long --> noe khrooji        Func
            t.Start(); // 6 ro mizare too Test2 va start mikone
            t.Wait(); // vaimiste ta tamoom she
            System.Console.WriteLine(t.Result); // Task bar khalaf thread Result(khorooji) dare


            Task t1 = new Task(Test, 5); // khorooji nadare         Action
            t1.Start(); // 5 ro mizare too Test2 va start mikone
            t1.Wait();
        }

        static void MyThreadMethod<_Type>(object obj) // voroodi hamishe object
        {
            InOut<_Type> inout = obj as InOut<_Type>;
            Thread.Sleep(500); // hamin thread ke toshe dare rjrash mikone
            System.Console.WriteLine($"Working {Thread.CurrentThread.ManagedThreadId}");
            inout.Out = inout.In;
        }
        static void Main9(string[] args)
        {
            InOut<int> inout = new InOut<int>() {In = 5};
            Thread t = new Thread(MyThreadMethod<int>);
            t.IsBackground = false; // Forground esh kon chon age background ashe momkene ejra nashe ba tamoom shodane barname
            t.Start(inout); // inout --> voroodi MyThreadMethod
            while (!t.Join(50))
            {
                System.Console.WriteLine($"Waiting {Thread.CurrentThread.ManagedThreadId}");
            }
            System.Console.WriteLine(inout.Out);
        }
        static void Main10(string[] args)
        {
            using (HttpClient client = new HttpClient())
            {
                Task<string>[] results = new Task<string>[] {
                    client.GetStringAsync("http://www.irna.ir"),
                    client.GetStringAsync("http://www.isna.ir"),
                    client.GetStringAsync("http://www.iust.ac.ir")};
                
                Task.WaitAll(results); // vaisa hamash tamoom she

                foreach(Task<string> r in results)
                    System.Console.WriteLine(r.Result.Length);
            }
        }
    }
}
