using DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserListHandler
    {
        #region 增
        public bool Add(User_List ul)
        {
            using (var db = new PingPingEntities())
            {
                ul.Time = DateTime.Now;
                ul.Status = 1;
                db.User_List.Add(ul);
                return db.SaveChanges() == 1 ? true : false;
            }
        }
        #endregion

        #region 查
        public User_List GetUserListById(int uid, int lid)
        {
            using (var db = new PingPingEntities())
            {
                var ul = from o in db.User_List
                         where o.UserID == uid && o.ListID == lid
                         select o;
                return ul.Count() == 0 ? null : ul.First();
            }
        }

        public int GetUserIdByListId(int lid)
        {
            using (var db = new PingPingEntities())
            {
                var ul = from o in db.User_List
                         where o.ListID == lid && o.Status == 1
                         select o;
                return ul.FirstOrDefault().UserID;
            }
        }

        public List<User_List> GetUserListByUserId(int uid)
        {
            using (var db = new PingPingEntities())
            {
                var ul = from o in db.User_List
                         where o.UserID == uid
                         select o;
                return ul.ToList();
            }
        }
        public List<User_List> GetUserListAndListByUserId(int uid)
        {
            using (var db = new PingPingEntities())
            {
                var ul = from o in db.User_List.Include("List")
                         where o.UserID == uid && o.Status == 1
                         select o;
                return ul.Count() == 0 ? null : ul.ToList();
            }
        }
        public List<User_List> GetUserListAndListByUserId(int uid, int type)
        {
            using (var db = new PingPingEntities())
            {
                var ul = from o in db.User_List.Include("List")
                         where o.UserID == uid && o.Type == type && o.Status == 1
                         select o;
                return ul.Count() == 0 ? null : ul.ToList();
            }
        }
        #endregion

        #region 改
        public bool Update(User_List ul)
        {
            using (var db = new PingPingEntities())
            {
                var ulNew = db.User_List.Where(o => o.UserID == ul.UserID && o.ListID == ul.ListID).FirstOrDefault();
                ulNew.Type = ul.Type;
                return db.SaveChanges() == 1 ? true : false;
            }
        }
        #endregion

        #region 删
        public bool Delete(int uid, int lid)
        {
            using (var db = new PingPingEntities())
            {
                var u = db.User_List.Where(o => o.UserID == uid && o.ListID == lid).FirstOrDefault();
                if (u != null)
                {
                    u.Status = 0;
                }
                return db.SaveChanges() == 1 ? true : false;
            }
        }
        #endregion
    }
}
