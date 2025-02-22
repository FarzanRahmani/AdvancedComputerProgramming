using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace L8
{
    class Program
    {
        // static async Task<string> MakeAbgooshtAsync(){}

        // static Task<string> MakeAbgooshtAsync(){}

        static void MakeAbgoosht()
        {
            Task<string> t = new Task<string>( () => {
                System.Console.WriteLine($"Boiling Water - Thread {Thread.CurrentThread.ManagedThreadId}");
                Task.Delay(300).Wait(); // Task jadid misazim hamin ja tamomesh mikonim (mesl sleep)
                return "Hot Water";
            });
            Task<string> remaining_work = t.ContinueWith( (Task<string> w) => {
                System.Console.WriteLine($"Adding Beans- Thread {Thread.CurrentThread.ManagedThreadId} ");
                Task.Delay(500).Wait(); // Task jadid misazim hamin ja tamomesh mikonim (mesl sleep)
                return w.Result + " + Beans";
            }).ContinueWith( (w) => {
                System.Console.WriteLine($"Adding Meat - Thread {Thread.CurrentThread.ManagedThreadId}");
                Task.Delay(1000).Wait();
                return w.Result + " + Meat = Abgoosht"; // w.Result == "Hot Water" + " + Beans"
            });
            t.Start();
            remaining_work.Wait();
            System.Console.WriteLine(remaining_work.Result);
        }
        

        static Task<string> MakeAbgooshtAsync() // async --> barname inja moatal nashe bere to main ejra she
        {
            Task<string> t = new Task<string>( () => {
                System.Console.WriteLine($"Boiling Water - Thread {Thread.CurrentThread.ManagedThreadId}");
                Task.Delay(300).Wait();
                return "Hot Water";
            }); // mesl tabe ii ke tarid shode seda zade nashode
            var remaining_work = t.ContinueWith( (w) => {
                System.Console.WriteLine($"Adding Beans- Thread {Thread.CurrentThread.ManagedThreadId} ");
                Task.Delay(500).Wait(); 
                return w.Result + " + Beans";
            }).ContinueWith( (w) => {
                System.Console.WriteLine($"Adding Meat - Thread {Thread.CurrentThread.ManagedThreadId}");
                Task.Delay(1000).Wait();
                return w.Result + " + Meat = Abgoosht";
            });
            t.Start();
            return remaining_work;
        }        

        static async Task<string> MakeAbgooshtAsync2()
        {
            Task<string> t1 = new Task<string>( () => {
                System.Console.WriteLine($"Boiling Water - Thread {Thread.CurrentThread.ManagedThreadId}");
                Task.Delay(300).Wait();
                return "Hot Water";
            });
            t1.Start();
            string t1_result = await t1;
            // string t_result = t1.Result; Result --> wait ros seda mizane
            // +++ in be jaye inke dar edame in bere do ta thread mikone yeki edame in yeki edame main
            // yani baname toye in gir nemikone va karbar moatal emishe

            var t2 = new Task<string>( () => {
                System.Console.WriteLine($"Adding Beans- Thread {Thread.CurrentThread.ManagedThreadId} ");
                Task.Delay(500).Wait(); 
                return t1_result + " + Beans";
            });
            t2.Start();
            string t2_result = await t2;
            // string t2_result = t2.Result; + barname ro dar main edame bedim va nahamzamn(async) dar in 

            var t3 = new Task<string>( () => {
                System.Console.WriteLine($"Adding Meat - Thread {Thread.CurrentThread.ManagedThreadId}");
                Task.Delay(1000).Wait();
                return t2_result + " + Meat = Abgoosht";
            });
            t3.Start();
            string t3_result = await t3;

            return t3_result;
        }        


        static async Task<int> DownloadAsync(string[] urls) // async --> barname inja moatal nashe bere to main ejra she
        {
            int sumLen = 0;
            using (HttpClient client = new HttpClient())
            {
                foreach(var requesturl in urls)
                {
                    sumLen += (await client.GetStringAsync(requesturl)).Length; // await = wait + result + new thread
                }
            }
            return sumLen;
        }

        static async Task<int> DownloadParallel(string[] urls)
        {
            Task<int>[] tasks = new Task<int>[urls.Length];
            for(int i=0; i<urls.Length; i++)
            {
                tasks[i] = new Task<int>((object o) => {
                    string RequestUrl = o as string; // 
                    using (HttpClient client = new HttpClient()) // new syntax
                        return client.GetStringAsync(RequestUrl).Result.Length;
                }, urls[i]); // urls[i] --> o ya RequestUrl ast ke vaghti start mizani dade mishe
                tasks[i].Start();
            }

            int[] results = await Task.WhenAll(tasks); // Task.WhenAll ye arraye ye jadid as in araye ha misaze
            
            int sumLen = 0;
            foreach(int r in results)
                sumLen += r;
            return sumLen;
        }

        static int DownloadParallel3(string[] RequsetUrls)
        {
            int sumLen = 0;
            Parallel.ForEach(RequsetUrls, (url) => {
                using (HttpClient client = new HttpClient())
                    sumLen += client.GetStringAsync(url).Result.Length;
            });
            return sumLen;
        }


        static void Main(string[] args)
        {
            int f = DownloadParallel3(new string[] {"http://www.irna.ir","http://www.isna.ir","http://www.iust.ac.ir"});
            Console.WriteLine(f);
            Task<string> x = MakeAbgooshtAsync2(); // Task<string> --> Task ii ke result esh string ast
            for (int i=0; i<10; i++)
            {
                System.Console.WriteLine(i);
                Task.Delay(100).Wait();
            }
            x.Wait();        
            System.Console.WriteLine(x.Result);
        }
    }
}
