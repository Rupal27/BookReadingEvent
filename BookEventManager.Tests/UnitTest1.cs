using System;
using System.Web.Mvc;
using BookEventManager.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared_Library;

namespace BookEventManager.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            BookController test = new BookController();
            var result = test.ViewAction() as ViewResult;
            Assert.AreEqual("ViewEvent", result.ViewName);
        }
        [TestMethod]
        public void TestMethod2()
        {
            BookController test = new BookController();
            var result = test.CreateBookReadingEvent() as ViewResult;
            Assert.AreEqual("BookEvent", result.ViewName);
        }
       

    }
}
