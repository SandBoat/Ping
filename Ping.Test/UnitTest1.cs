using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using DataSource;

namespace Ping.Test
{
    [TestClass]
    public class UnitTest1
    {
        private UserHandler userHandler = new UserHandler();

        [TestMethod]
        public void TestUserHandler()
        {
            User u = new User();
            u.Password = "123";
            Assert.IsTrue(userHandler.Add(u));
        }
    }
}
