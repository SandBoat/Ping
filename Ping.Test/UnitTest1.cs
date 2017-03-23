using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using DataSource;
using BLL;

namespace Ping.Test
{
    [TestClass]
    public class UnitTest1
    {
        private UserHandler userHandler = new UserHandler();
        private ListHandler listHandler = new ListHandler();
        private UserListHandler ulHandler = new UserListHandler();

        [TestMethod]
        public void Testxx()
        {
            User u = new User();
            //Assert.IsTrue(u.Password.Length == 0);

            UserService us = new UserService();
            us.Register(u);
            //us.Login(,"");
        }

        [TestMethod]
        public void TestUserHandler()
        {
            //User u = new User();
            //u.UserName = "1";
            //u.Password = "123";
            //Assert.IsTrue(userHandler.Add(u));

            User u = userHandler.GetUser("1", "123");
            Console.ReadLine();
        }

        [TestMethod]
        public void TestListHandler()
        {
            DataSource.List li = new List();
            //li.StartPoint = "test_sp2";
            //li.EndPoint = "test_ep2";
            li.Departure = DateTime.Now;
            Assert.IsTrue(listHandler.Add(li));
        }

        [TestMethod]
        public void TestUserListHandler()
        {

            User_List ul = new User_List();
            //ul.UserID = 1;
            //ul.ListID = 1;
            //ul.Type = 1;
            //Assert.IsTrue(ulHandler.Add(ul));

            ul = ulHandler.GetUserListById(1, 1);
            if(ul != null)
            {
                Console.WriteLine(ul.User);
                Console.WriteLine(ul.Time);
                Console.WriteLine(ul.Type);
                Console.WriteLine(ul.Status);
            }
        }
    }
}
