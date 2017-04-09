using DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ListHandler
    {
        #region 增
        public bool Add(List list)
        {
            using (var db = new PingPingEntities())
            {
                list.Statue = 1;
                db.List.Add(list);
                return db.SaveChanges() == 1 ? true : false;
            }
        }
        #endregion

        #region 查
        public List<List> GetAllList()
        {
            using (var db = new PingPingEntities())
            {
                return db.List.Where(o => o.Statue == 1).ToList();
            }
        }
        public List GetListById(int listId)
        {
            using (var db = new PingPingEntities())
            {
                return db.List.Find(listId);
            }
        }
        public List<List> GetListById(int[] listId)
        {
            using (var db = new PingPingEntities())
            {
                var list = from o in db.List
                           where listId.Contains(o.ListID)
                           select o;
                return list.ToList();
            }
        }
        public List<List> GetListByAdress(double start_x, double strart_y)
        {
            using (var db = new PingPingEntities())
            {
                var list = from o in db.List
                           where (double)o.StartPoint_x == start_x && (double)o.StartPoint_y == strart_y
                           select o;
                return list.ToList();
            }
        }
        public List<List> GetListByAdress(double start_x, double strart_y, double end_x, double end_y, DateTime date)
        {
            using (var db = new PingPingEntities())
            {
                var list = from o in db.List
                           where (double)o.StartPoint_x == start_x && (double)o.StartPoint_y == strart_y
                                && (double)o.EndPoint_x == end_x && (double)o.EndPoint_y == end_y
                                && o.Departure_Date == date
                           select o;
                return list.ToList();
            }
        }
        public List<List> GetListByAdress(double start_x, double strart_y, double end_x, double end_y, DateTime date, TimeSpan time)
        {
            using (var db = new PingPingEntities())
            {
                var list = from o in db.List
                           where (double)o.StartPoint_x == start_x && (double)o.StartPoint_y == strart_y
                                && (double)o.EndPoint_x == end_x && (double)o.EndPoint_y == end_y
                                && o.Departure_Date == date && o.Departure_Time == time
                           select o;
                return list.ToList();
            }
        }
        public List<List> GetListByAdress(double start_x, double strart_y, double end_x, double end_y, int scope)
        {
            using (var db = new PingPingEntities())
            {
                var list = from o in db.List
                           where Math.Abs((double)o.StartPoint_x - start_x) < scope / 10000.0 && Math.Abs((double)o.StartPoint_y - strart_y) < scope / 10000.0 && (double)o.EndPoint_x == end_x && (double)o.EndPoint_y == end_y
                           select o;
                return list.ToList();
            }
        }
        public List<List> GetListByDate(DateTime date)
        {
            using (var db = new PingPingEntities())
            {
                var list = from o in db.List
                           where o.Departure_Date == date.Date
                           select o;
                return list.ToList();
            }
        }
        public List<List> GetListByDateAndStartAdresss(double start_x, double strart_y, DateTime date)
        {
            using (var db = new PingPingEntities())
            {
                var list = from o in db.List
                           where o.Departure_Date == date.Date && (double)o.StartPoint_x == start_x && (double)o.StartPoint_y == strart_y
                           select o;
                return list.ToList();
            }
        }
        public List<List> GetListByDateAndEndAdress(double end_x, double end_y, DateTime date)
        {
            using (var db = new PingPingEntities())
            {
                var list = from o in db.List
                           where o.Departure_Date == date.Date && (double)o.EndPoint_x == end_x && (double)o.EndPoint_y == end_y
                           select o;
                return list.ToList();
            }
        }


        public List<List> GetTodayList()
        {
            using (var db = new PingPingEntities())
            {
                var list = from o in db.List
                           where o.Departure_Date == DateTime.Today
                           select o;
                return list.ToList();
            }
        }
        #endregion

        #region 改
        public bool Update(List list)
        {
            using (var db = new PingPingEntities())
            {
                var o = db.List.Find(list.ListID);
                o.StartAdress = list.StartAdress;
                o.StartPoint_x = list.StartPoint_x;
                o.StartPoint_y = list.StartPoint_y;
                o.EndAdress = list.EndAdress;
                o.EndPoint_x = list.EndPoint_x;
                o.EndPoint_y = list.EndPoint_y;
                o.Departure_Date = list.Departure_Date;
                o.Departure_Time = list.Departure_Time;
                o.Sex = list.Sex;
                o.Contacts = list.Contacts;
                o.detail = list.detail;
                return db.SaveChanges() == 1 ? true : false;
            }
        }
        #endregion

        #region 删
        #endregion
    }
}
