using System;

namespace L5
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Part1
            var File1 = new MyFile("file1");
            var File2 = new MyFile("file2");
            var Directory1 = new MyDirectory("dir1");
            var Rar1 = new MyRar("Rar1");
            Directory1.Add(File1, File2, Rar1);
            #endregion

            #region Part2
            var File3 = new MyFile("file3");
            var File4 = new MyFile("file4");
            var File6 = new MyFile("file6");
            var Rar2 = new MyRar("Rar2");
            var Directory2 = new MyDirectory("dir2");
            Directory2.Add(File3, File4, File6, Rar2);
            #endregion

            #region Part3
            var Directory3 = new MyDirectory("dir3");
            var File5 = new MyFile("file5");
            var Rar3 = new MyRar("Rar3");
            Directory3.Add(File5, Directory1, Directory2, Rar3);
            #endregion

            #region Delete
            File1.Delete();
            Console.WriteLine("#####################");
            Directory1.Delete();
            Console.WriteLine("#####################");
            Directory3.Delete();
            Console.WriteLine("#####################");
            #endregion

            #region Move
            File1.Move();
            Console.WriteLine("#####################");
            Directory1.Move();
            Console.WriteLine("#####################");
            Directory3.Move();
            #endregion
        }
    }
}
