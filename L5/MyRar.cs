using System;
namespace L5
{
    internal class MyRar : IFileSystem
    {
        public string Name{get; private set;}

        public MyRar(string name)
        {
            this.Name = name;
        }
        public void Delete()=>
            System.Console.WriteLine($"RAR {this.Name} is Deleted.");
        public void Move()=>
            System.Console.WriteLine($"RAR {this.Name} is Moved.");
    }
}