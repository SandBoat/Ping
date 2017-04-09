using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using DataSource;
using BLL;
using System.Collections.Generic;
using System.Linq;

namespace Ping.Test
{
    [TestClass]
    public class UnitTest1
    {
        private UserHandler userHandler = new UserHandler();
        private ListHandler listHandler = new ListHandler();
        private UserListHandler ulHandler = new UserListHandler();
        private CommonService comService = new CommonService();
        private MapService mapService = new MapService();

        [TestMethod]
        public void Testxx()
        {
            //User u = new User();
            //Assert.IsTrue(u.Password.Length == 0);

            //UserService us = new UserService();
            //us.Register(u);
            //us.Login(,"");
            Console.WriteLine(10 / 100.0);
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
            //li.Departure = DateTime.Now;
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
            if (ul != null)
            {
                Console.WriteLine(ul.User);
                Console.WriteLine(ul.Time);
                Console.WriteLine(ul.Type);
                Console.WriteLine(ul.Status);
            }
        }

        [TestMethod]
        public void TestMapService()
        {
            //List<List> lists = listHandler.GetAllList();
            //List<List> lists2 = lists.OrderBy(o => o.Departure_Date).ToList();
            //Console.WriteLine();
            string timeStr = "2017-05-05 13:21:23";
            DateTime dateTime = DateTime.ParseExact(timeStr, "yyyy-MM-dd HH:mm:ss", null);


            List list = new List();
            list.StartAdress = "西南财经大学(柳林校区)";
            list.StartPoint_x = (decimal)103.827675;
            list.StartPoint_y = (decimal)30.687832;
            list.EndAdress = "西南财经大学出版社";
            list.EndPoint_x = (decimal)104.023906;
            list.EndPoint_y = (decimal)30.673137;
            list.Departure_Date = dateTime.Date;
            list.Departure_Time = dateTime.TimeOfDay;
            list.Sex = 2;
            list.Contacts = "QQ:1225458|Tel:13212343214";
            list.detail = "";

            mapService.Release(list, 2);
        }

        [TestMethod]
        public void TestCommonService()
        {
            //double a1 = 37.480563;
            //double a2 = 121.467113;
            //double b1 = 37.480591;
            //double b2 = 121.467926;
            double a1 = 103.827675;
            double a2 = 30.687832;
            //double b1 = 103.830847;
            //double b2 = 30.684915;
            double b1 = 103.827675;
            double b2 = 30.687832;

            double c1 = 30.687832;
            double c2 = 103.827675;
            double d1 = 30.687832;
            double d2 = 103.827675;

            Console.WriteLine(comService.getDistanceFromXtoY(a1, a2, b1, b2));

            Console.WriteLine(comService.getDistanceFromXtoY(a1 + 0.01, a2, b1, b2));
            Console.WriteLine(comService.getDistanceFromXtoY(a1, a2 + 0.01, b1, b2));
            Console.WriteLine(comService.getDistanceFromXtoY(a1 + 0.01, a2 + 0.01, b1, b2));
            //Console.WriteLine(comService.getDistanceFromXtoY(a1, a2 - 0.01, b1, b2));
            //Console.WriteLine(comService.getDistanceFromXtoY(a1 - 0.01, a2, b1, b2));
            //Console.WriteLine(comService.getDistanceFromXtoY(a1 - 0.01, a2 - 0.01, b1, b2));

            Console.WriteLine(comService.getDistanceFromXtoY(c1 + 0.01, c2, d1, d2));
            Console.WriteLine(comService.getDistanceFromXtoY(c1, c2 + 0.01, d1, d2));
            Console.WriteLine(comService.getDistanceFromXtoY(c1 + 0.01, c2 + 0.01, d1, d2));

            Console.WriteLine(comService.getDistanceFromXtoY(0, 0.01, 0, 0));
            Console.WriteLine(comService.getDistanceFromXtoY(0.01, 0, 0, 0));
            Console.WriteLine(comService.getDistanceFromXtoY(0.01, 0.01, 0, 0));

        }

    }
}
