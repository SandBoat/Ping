using DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 用户信息类数据处理层
    /// </summary>
    public class UserHandler
    {
        #region 增
        public bool Add(User user)
        {
            using (var db = new PingPingEntities())
            {
                user.RegisterTime = DateTime.Now;
                user.Status = 1;
                db.User.Add(user);
                return db.SaveChanges() == 1 ? true : false;
            }
        }
        #endregion

        #region 查
        public User GetUser(string userName, string password)
        {
            using (var db = new PingPingEntities())
            {
                var u = from o in db.User
                        where o.UserName == userName && o.Password == password && o.Status == 1
                        select o;
                return u.Count() == 0 ? null : u.First();
                //return db.User.Where(o => o.UserName == userName && o.Password == password && o.Status == 1).FirstOrDefault();
            }
        }
        public User GetUserByUserName(string uname)
        {
            using (var db = new PingPingEntities())
            {
                return db.User.Find(uname);
            }
        }
        public User GetUserById(int uid)
        {
            using (var db = new PingPingEntities())
            {
                return db.User.Find(uid);
            }
        }
        public List<User> GetUserAll()
        {
            using (var db = new PingPingEntities())
            {
                var userList = from o in db.User
                               where o.Status == 1
                               select o;
                return userList.ToList();
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


