using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace C14.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] actual = new int[] {1,2,3,4};
            Func<int , int> [] functions = new Func<int, int> [actual.Length];
            Func<bool> [] ifFunctions = new Func<bool> [actual.Length];
            Action<int> [] actionFunctions = new Action<int> [actual.Length];
            Program.TestAction(actual,functions,ifFunctions,actionFunctions);
            int[] expected = new int[] {5,-3,0,9};
            for (int i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(expected[i],actual[i]);
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            int[] actual = new int[] {5,6,7,8,9,10,11,12};
            Func<int , int> [] functions = new Func<int, int> [actual.Length];
            Func<bool> [] ifFunctions = new Func<bool> [actual.Length];
            Action<int> [] actionFunctions = new Action<int> [actual.Length];
            Program.TestAction(actual,functions,ifFunctions,actionFunctions);
            int[] expected = new int[] {25,1,1,13,45,5,2,17};
            for (int i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(expected[i],actual[i]);
            }
        }

        [TestMethod]
        public void TestMethod3()
        {
            int[] actual = new int[] {-99,57,0,-38,46,-999,456789};
            Func<int , int> [] functions = new Func<int, int> [actual.Length];
            Func<bool> [] ifFunctions = new Func<bool> [actual.Length];
            Action<int> [] actionFunctions = new Action<int> [actual.Length];
            Program.TestAction(actual,functions,ifFunctions,actionFunctions);
            int[] expected = new int[] {-19,285,5,-7,41,-199,2283945};
            for (int i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(expected[i],actual[i]);
            }
        }
    }
}
