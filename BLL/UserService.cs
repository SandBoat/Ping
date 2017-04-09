using DAL;
using DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 用户逻辑层
    /// </summary>
    public class UserService
    {
        private UserHandler userHandler = new UserHandler();
        private UserListHandler userListHandler = new UserListHandler();

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User Login(string userName, string password)
        {
            User user = userHandler.GetUser(userName, password);
            return user != null ? user : null;
        }

        /// <summary>
        /// 验证用户名是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool IsUserNanmeExists(String userName)
        {
            return userHandler.GetUserByUserName(userName) != null;
        }

        /// <summary>
        /// 验证用户信息是否合法
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string IsUserRight(User user)
        {
            if (user.UserName.Length == 0 && user.UserName.Length >= 50)
            {
                return "userName";
            }
            if (user.Password.Length == 0 && user.Password.Length >= 50)
            {
                return "password";
            }
            return "right";
        }

        /// <summary>
        /// 注册验证
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>
        ///     error：xx  没有通过验证
        ///     ok  通过验证
        /// </returns>
        public string Register(User user)
        {
            if (!IsUserRight(user).Equals("right"))
            {
                return "error:" + IsUserRight(user);
            }
            if (IsUserNanmeExists(user.UserName))
            {
                return "error:用户名已存在";
            }
            if (userHandler.Add(user))
            {
                return "ok";
            }
            return "error:";
        }

        /// <summary>
        /// 禁用用户
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>
        ///     error：xx  没有通过验证
        ///     ok  通过验证
        /// </returns>
        public bool DeleteUser(int uid)
        {
            return userHandler.Delete(uid);
        }

        public List<User_List> getUserList(int userId)
        {
            return userListHandler.GetUserListAndListByUserId(userId);
        }
        public List<User_List> getUserRelease(int userId)
        {
            return userListHandler.GetUserListAndListByUserId(userId, 1);
        }
        public List<User_List> getUserFollow(int userId)
        {
            return userListHandler.GetUserListAndListByUserId(userId, 2);
        }

        public User getUserById(int userId)
        {
            return userHandler.GetUserById(userId);
        }
    }
}
