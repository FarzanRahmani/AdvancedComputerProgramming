using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace C18
{
    class Program
    {

        static async Task<string> Test2()
        {
            System.Console.WriteLine("Starting to do work");
            using HttpClient client= new HttpClient();
            int w = 15;
            string result = await client.GetStringAsync("http://www.iran.ir"); // Task jadid misza bad be main bar migarde (shabih Continuewith ke start esh biroon mikhore(dakhelam mishe ha))
            string result1 = await client.GetStringAsync("http://www.isna.ir"); // await Result + wait + Task jadid 
            string result2 = await client.GetStringAsync("http://www.ifqa.ir");

            ThreadPool.QueueUserWorkItem( (obj) => {
                System.Console.WriteLine("Test1");
                Thread.Sleep(500);
            });// seir pishraft Thread --> ThreadPool --> Task

            return result + result1 + result2 + w;
        }

        static async Task<string> Test1()
        {
            System.Console.WriteLine("Starting to do work");
            using HttpClient client= new HttpClient();
            string result = await client.GetStringAsync("http://www.iran.ir");
            string[] urls = GetUrls(result);
            foreach(var url in urls)
            {
                string content = await client.GetStringAsync(url);
                if (Process(content))
                    return content;
            }
            return null;
        }

        private static bool Process(string content)
        {
            throw new NotImplementedException();
        }

        private static string[] GetUrls(string result)
        {
            throw new NotImplementedException();
        }

        static void Main1(string[] args)
        {
            System.Timers.Timer timer= new System.Timers.Timer(10);
            timer.AutoReset = false;
            timer.Elapsed += (s,ea) => System.Console.WriteLine("test1");
            timer.Elapsed += (s,ea) => System.Console.WriteLine("test2");
            timer.Elapsed += (s,ea) => System.Console.WriteLine("test3");
            timer.Start();

            for(int i=0; i<3000; i++)
            {
                System.Console.WriteLine(i);
            }

            bool timerFinished = false;
            timer.Disposed += (s,ea) => timerFinished = true;

            while (!timerFinished)
                Task.Delay(10).Wait();
            
            Console.WriteLine("Hello World!");
        }
    }
}
