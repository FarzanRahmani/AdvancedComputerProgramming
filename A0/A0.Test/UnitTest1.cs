using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace A0.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int max = A0.Program.Max(1,5);
            Assert.AreEqual(max,5);
            max = A0.Program.Max(4,-1);
            Assert.AreEqual(max,4);
            Assert.AreEqual(A0.Program.Max(5,14),14);
        }
    }
}
