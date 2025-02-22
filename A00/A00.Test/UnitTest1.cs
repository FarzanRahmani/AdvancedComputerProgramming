using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace A00.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            bool frzn = A00.Program.IsGreater(5,1);
            Assert.AreEqual(frzn,true);
            frzn = A00.Program.IsGreater(10,20);
            Assert.IsFalse(frzn);
        }
    }
}
