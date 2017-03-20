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
                db.List.Add(list);
                return db.SaveChanges() == 1 ? true : false;
            }
        }
        #endregion

        #region 查
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
        #endregion

        #region 改
        public bool Update(List list)
        {
            using (var db = new PingPingEntities())
            {
                var o = db.List.Find(list.ListID);
                o.StartPoint = list.StartPoint;
                o.EndPoint = list.EndPoint;
                o.Departure = list.Departure;
                return db.SaveChanges() == 1 ? true : false;
            }
        }
        #endregion

        #region 删
        #endregion
    }
}
