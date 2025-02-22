using System;
namespace L5
{
    internal class MyFile : IFileSystem
    {
        public string Name{get;private set;}

        public MyFile(string name)
        {
            this.Name = name;
        }
        public void Delete()=>
            System.Console.WriteLine($"file {this.Name} is Deleted.");
        public void Move()=>
            System.Console.WriteLine($"file {this.Name} is Moved.");
    }
}