using System;
using System.Collections.Generic;

namespace L5
{
    public class MyDirectory : IFileSystem
    {
        public string Name{get;private set;}
        public List<IFileSystem> Items {get;private set;} = new List<IFileSystem>();

        public MyDirectory(string name)
        {
            this.Name = name;
        }
        internal void Add(params IFileSystem[] items)=>
            this.Items.AddRange(items);
        public void Delete()
        {
            foreach (var item in this.Items)
            {
                item.Delete();
            }
            this.changecolor($"Directory {this.Name} is Deleted.");
        }
        public void changecolor(string str)
        {
            var cr = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine(str);
            Console.ForegroundColor  = cr;
        }

        
        public void Move()
        {
            foreach (var item in this.Items)
            {
                item.Move();
            }
            this.changecolor($"MyDirectory {this.Name} is Moved.");
        }
    } 
}