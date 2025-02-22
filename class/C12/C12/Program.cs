using System;
using System.Collections.Generic;
using System.IO;

namespace C12
{
    class KeepTime: IDisposable
    {
        public KeepTime(string name)
        {
            Name = name;
            this.Start();
        }

        public string Name { get; }

        private DateTime StartTime; // zaman alan
        private TimeSpan _ElapsedTime; // separi shode span:modat moayan
        public TimeSpan ElapsedTime { get =>_ElapsedTime;}

        public void Start()
        {
            this.StartTime = DateTime.Now;
        }

        public void Stop()
        {
            this._ElapsedTime = new TimeSpan(DateTime.Now.Ticks - StartTime.Ticks); // Ticks shabihe sanie vali kheili kochic tare
        }

        public void PrintInfo()
        {
            System.Console.WriteLine($"Task: {this.Name} took {this.ElapsedTime.TotalMilliseconds} ms");
        }

        public void Dispose() // vaghti az using kharej she miad inja
        {
            this.Stop();
            this.PrintInfo();
        }
    }

    public static class Program
    {
        public static void ReverseTextFile(string inFile, string outFile)
        {
            using (StreamReader reader = new StreamReader(inFile))
                using (StreamWriter writer = new StreamWriter(outFile))
                {
                    string line;
                    List<string> lines = new List<string>();
                    // string[] lines = new string[200];
                    while (null != (line = reader.ReadLine()) )
                    {
                        lines.Add(line);
                        // lines.
                    }
                    lines.Reverse();
                    for (int i = 0; i < lines.Count; i++)
                    {
                        writer.WriteLine(lines[i]);
                    }
                    reader.Close();
                    writer.Close();
                }
        }

        static void Main(string[] args)
        {
            ReverseTextFile(@"data.txt",@"copydata.txt");
            // using (KeepTime timer = new KeepTime("Nested Loop")) // using --> interface IDisposable dashte bashe
            // {
            //     double d = 1.9;
            //     for(int i=0; i<10000; i++)
            //         for(int j=0; j<10000; j++)
            //         {
            //             d = d * d;
            //             if (d > 900)
            //                 break;
            //         }
            // }
            // bad az in ke az in block using kharej she tabe Dispose ejra mishe


            // using (StreamReader reader = new StreamReader(@"E:\git\AP99002\class\C12\C12\data.txt")) // @ --> r python (\ charcter dastoori mahsoob emishe)
            //     using (StreamWriter writer = new StreamWriter(@"E:\git\AP99002\class\C12\C12\copydata.txt"))
            //     {
            //         string line;
            //         while (null != (line = reader.ReadLine()))
            //         {
            //             if (line.Length < 10)
            //                 writer.WriteLine(line);
            //             else
            //                 return;
            //         }
            //     }
            

            // foreach(string s in args)
            // {}

        }
        // static void ReverseTextFile(string inFile, string outFile)
        // {
        //     string[] lines = File.ReadAllLines(inFile);
        //     File.WriteAllLines(outFile, lines);
        // }

        // static void Main2(string[] args)
        // {
            

        //     Student s = new Student("Zhaleh", 995212212, 15.5);
        //     double gpa = 22;
        //     if (!s.SetGPA(gpa))
        //         System.Console.WriteLine($"Error invalid GPA {gpa}");

        //     double d = s.GPA; // getter e property
        //     s.GPA = 19.9; // setter e property
        //     s.Id = 989898; // setter e property
        //     System.Console.WriteLine(s.Id); // getter e property
        //     System.Console.WriteLine(s.Name); // getter e property
            
        //     // s.Name = "hossein";
        //     // using (s)
        //     // {
                
        //     // }
        // }
    }
}
