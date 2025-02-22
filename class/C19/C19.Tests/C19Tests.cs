using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace C19.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MultiplyopByComplex()
        {
            Complex c1 = new Complex(2,2);
            Complex c2 = new Complex(1,3);
            Complex cr =c1 * c2;
            Assert.AreEqual(8,cr[0]);
            Assert.AreEqual(4,cr[1]);
        }

        [TestMethod]
        public void MultiplyopByDouble()
        {
            Complex c1 = new Complex(2,1);
            Complex cr = c1 * 6;
            Assert.AreEqual(12,cr[0]);
            Assert.AreEqual(6,cr[1]);
        }

        [TestMethod]
        public void SumopByComplex()
        {
            Complex c1 = new Complex(2,2);
            Complex c2 = new Complex(1,3);
            Complex cr =c1 + c2;
            Assert.AreEqual(3,cr[0]);
            Assert.AreEqual(5,cr[1]);
        }

        [TestMethod]
        public void SumopByDouble()
        {
            Complex c1 = new Complex(2,1);
            Complex cr = c1 + 7;
            Assert.AreEqual(2,cr[0]);
            Assert.AreEqual(8,cr[1]);
        }

        [TestMethod]
        public void Equalsmethod()
        {
            Complex c1 = new Complex(2,2);
            Complex c2 = new Complex(1,3);
            Complex c3 = new Complex(2,2);
            Assert.AreEqual(true,c1.Equals(c3));
            Assert.AreNotEqual(true, c1.Equals(c2));
            Assert.IsTrue(c1.Equals("2i+2"));
            Assert.IsTrue(c2.Equals("1i+3"));
            Assert.IsFalse(c2.Equals("20i+97"));
        }

        [TestMethod]
        public void EqualityOps()
        {
            Complex c1 = new Complex(2,2);
            Complex c2 = new Complex(1,3);
            Complex c3 = new Complex(2,2);
            Assert.IsTrue(c1==c3);
            Assert.IsFalse(c2==c3);
            Assert.IsTrue(c1!=c2);
            Assert.IsFalse(c1!=c3);
        }

        [TestMethod]
        public void ToStringMethod(){
            Complex c = new Complex(1,3);
            Assert.AreEqual("1i+3",c.ToString());
            Complex c1 = new Complex(-9,78);
            Assert.AreEqual("-9i+78",c1.ToString());
        }

        [TestMethod]
        public void ExplicitOpComplexToString()
        {
            string cstring = (string) new Complex(1,3);
            Assert.AreEqual("1i+3",cstring);
        }

        [TestMethod]
        public void ExplicitOpComplex()
        {
            Complex c = (Complex) "1i+3";
            Assert.AreEqual(1,c[0]);
            Assert.AreEqual(3,c[1]);
        }

        [TestMethod]
        public void ImplicitOpStringToCopmplex()
        {
            Complex cFromS = "5i+9";
            Assert.AreEqual(new Complex(5,9),cFromS);
        }

        [TestMethod]
        public void ToStringTest()
        {
            string cstring = (new Complex(1,3)).ToString();
            Assert.AreEqual("1i+3",cstring);
        }

        [TestMethod]
        public void ExplicitOpComplexToDouble()
        {
            double d = (double) new Complex(1,3);
            Assert.AreEqual(3,d);
        }

        [TestMethod]
        public void ImplicitOpDoubleToComplex()
        {
            Complex c = 5.6;
            Assert.IsTrue(c == new Complex(0,5.6));
        }
    }
}
