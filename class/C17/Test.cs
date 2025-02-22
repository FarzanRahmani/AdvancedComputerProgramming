using System;
using System.Net.Http;

class Test
{
    public static void Test1()
    {
        using (HttpClient client = new HttpClient())
        {
            var result = client.GetAsync("http://www.irna.ir/");
            result.Wait();
            Console.WriteLine(result.Result.StatusCode);
        }

    }
}