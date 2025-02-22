
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace E2.Tests
{
    [TestClass()]
    public class Q3ThreadTests
    {
        [TestMethod()]
        public void Q3ThreadMultiThreadTest()
        {
            for(int i=0; i<1000; i++)
            {
                Q3Thread.ResetInstanceToNull();

                long x = 0;
                int testSize = 50;
                Thread[] threads = new Thread[testSize];
                for(int j=0; j<testSize; j++)
                    threads[j] = new Thread( () => x += Q3Thread.Instance().GetSomeRandomNumber());

                for(int j=0; j<testSize; j++)
                    threads[j].Start();
                
                Assert.AreEqual(1, Q3Thread.InstanceCount);
            }
            
        }

    }
}
