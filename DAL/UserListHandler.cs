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
                //return db.User_List.Find(uid, lid);
                var ul = from o in db.User_List.Include("User").Include("List")
                         where o.UserID == uid && o.ListID == lid
                         select o;
                return ul.Count() == 0 ? null : ul.First();
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
        #endregion

        #region 改
        public bool Update(User user)
        {
            using (var db = new PingPingEntities())
            {
                var u = db.User.Find(user.UserID);
                u.Password = user.Password;
                u.Sex = user.Sex;
                u.Tel = user.Tel;
                return db.SaveChanges() == 1 ? true : false;
            }
        }
        #endregion

        #region 删
        public bool Delete(int uid)
        {
            using (var db = new PingPingEntities())
            {
                var u = db.User.Find(uid);
                u.Status = 0;
                return db.SaveChanges() == 1 ? true : false;
            }
        }
        #endregion
    }
}
