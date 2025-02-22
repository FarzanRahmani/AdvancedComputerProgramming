using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using L4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace L4Tests
{
    [TestClass]
    public class AdvancedExceptionTests
    {
        #region L4
        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void TestNumProperty()
        {
            var eh = new ExceptionHandler(throwException: true);
            eh.num = 10;
            Assert.AreEqual(eh.num, 10);
            eh.num = -1;
        }

        [TestMethod]
        public void TestIsThrowExceptionProperty()
        {
            ExceptionHandler eh = new ExceptionHandler(throwException: false);
            eh.num = 10;
            Assert.AreEqual(eh.num, 10);
            eh.num = -1;
            Assert.AreEqual(eh.num, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(OutOfMemoryException))]
        public void TestFinallyBlockException()
        {
            var eh = new ExceptionHandler(throwException: true);
            eh.ThrowOutOfMemoryException();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void TestFinallyBlockExceptionNoCatch()
        {
            var eh = new ExceptionHandler(throwException: true);
            try
            {
                eh.ThrowInvalidDataException();
                Assert.Fail("Method Did not throw");
            }
            catch (InvalidDataException e)
            {
                Assert.AreEqual(
                    "Invalid Data",
                    e.Message);
                throw;
            }
        }

        #endregion

        #region Nested
        [ExpectedException(typeof(NotImplementedException))]
        [TestMethod]
        public void TestRecursiveFunctions()
        {
            var eh = new ExceptionHandler(true);
            var expectedCallStack = new string[]
            {
                    "D()", "C()", "B()",
                    "A(Boolean catchException)", "RecursiveFunctions(Boolean catchException)"
            };

            try
            {
                eh.RecursiveFunctions(catchException: false);
                Assert.Fail("RecursiveFunctions must throw exception.");
            }
            catch (NotImplementedException e)
            {
                Assert.IsTrue(expectedCallStack.Select(arg => e.StackTrace.Contains(arg)).All(arg => arg));
                throw;
            }
        }
        #endregion
        [ExpectedException(typeof(NotImplementedException))]
        [TestMethod]
        public void TestRecursiveFunctionsDeleteSomePath()
        {
            var eh = new ExceptionHandler(true);
            var expectedCallStack = new string[]
            {
                "A(Boolean catchException)",
                "RecursiveFunctions(Boolean catchException)"
            };

            try
            {
                eh.RecursiveFunctions(catchException: true);
                Assert.Fail("RecursiveFunctions must throw exception.");
            }
            catch (NotImplementedException e)
            {
                Assert.IsTrue(expectedCallStack.Select(arg => e.StackTrace.Contains(arg)).All(arg => arg));
                Assert.IsFalse(e.StackTrace.Contains("D()"));
                Assert.IsFalse(e.StackTrace.Contains("B()"));
                Assert.IsFalse(e.StackTrace.Contains("C()"));
                throw;
            }
        }
        [ExpectedException(typeof(ObjectDisposedException))]
        [TestMethod]
        public void TestFinally()
        {
            var reader = File.Create(@".\test.txt");
            var expectedCallStack = new string[]
            {
                "ThrowNotImplementedException()",
                "UsingFinallyBlock(FileStream reader)"
            };
            try
            {
                var eh = new ExceptionHandler(true);
                eh.UsingFinallyBlock(reader);
                Assert.Fail("RecursiveFunctions must throw exception.");
            }
            catch (Exception e)
                when (e is NotImplementedException)
            {
                Assert.IsTrue(expectedCallStack.Select(arg => e.StackTrace.Contains(arg)).All(arg => arg));
                var count = 100;
                var arr = new byte[count];
                reader.Read(arr, 0, count);
            }
        }
    }
}