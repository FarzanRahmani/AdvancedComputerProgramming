﻿using System;
using A7;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace A7.Tests
{

    [TestClass]
    public class OutOfMemoryExceptionTests
    {
        #region OutOfMemoryException
        [TestMethod]
        public void TestNoOutOfMemoryException()
        {
            ExceptionHandler eh = new ExceptionHandler(
                "10", false);
            eh.OutOfMemoryExceptionMethod();
            Assert.AreEqual(eh.ErrorMsg, null);
        }

        [TestMethod]
        [ExpectedException(typeof(OutOfMemoryException))]
        public void TestThrowOutOfMemoryException()
        {
            ExceptionHandler eh = new ExceptionHandler(int.MaxValue.ToString(), false);
            eh.OutOfMemoryExceptionMethod();
        }

        [TestMethod]
        public void TestCatchOutOfMemoryException()
        {
            ExceptionHandler eh = new ExceptionHandler(
                int.MaxValue.ToString(), false, true);
            eh.OutOfMemoryExceptionMethod();

            Assert.AreEqual(
                $"Caught exception {typeof(OutOfMemoryException)}",
                eh.ErrorMsg);
        }
        #endregion
    }
}