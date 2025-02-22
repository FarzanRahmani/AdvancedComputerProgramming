using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace C12.Tests
{
    [TestClass]
    public class UnitTest1
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
                        lines.Add(line);
                    lines.Reverse();
                    for (int i = 0; i < lines.Count; i++)
                        writer.WriteLine(lines[i]);
                    reader.Close();
                    writer.Close();
                }
        }
        [TestMethod]
        public void TestMethod1()
        {
            ReverseTextFile(@"..\..\..\..\C12\data.txt",@"..\..\..\..\C12\copydata.txt");
            
            List<string> linesReaded = new List<string>();
            List<string> linesExpected = new List<string>();
            // "E:\git\AP99002\class\C12\C12\copydata.txt"
            using (StreamReader readed = new StreamReader(@"..\..\..\..\C12\copydata.txt"))
            {
                string line;
                while (null != (line = readed.ReadLine()) )
                    linesReaded.Add(line);
            }
            // @"E:\git\AP99002\class\C12\C12\expected.txt"
            using (StreamReader readed = new StreamReader(@"..\..\..\..\C12\expected.txt"))
            {
                string line;
                while (null != (line = readed.ReadLine()) )
                    linesExpected.Add(line);
            }
            for (int i = 0; i < linesReaded.Count; i++)
            {
                Assert.AreEqual(linesReaded[i],linesExpected[i]);
            }

        }
    }
}
