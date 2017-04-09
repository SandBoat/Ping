using BLL;
using DataSource;
using Ping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ping.Controllers
{
    [RoutePrefix("User")]
    public class UserController : Controller
    {
        UserService userService = new UserService();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        #region 登录
        // Get:Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // Post:Login
        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            User user = userService.Login(userName, password);
            if (user != null)
            {
                Session["userId"] = user.UserID;
                return Redirect("~/ZuChe/Release");
            }
            return View();
        }
        #endregion

        #region 注册
        // Get:Register
        public ActionResult Register()
        {
            return View();
        }

        // Post:Register
        [HttpPost]
        public ActionResult Register(RegisterModels register)
        {
            User user = new User();
            if (ModelState.IsValid)
            {
                if (register.Password.Equals(register.Password2))
                {
                    user.UserName = register.UserName;
                    user.Password = register.Password;
                    String resultMessage = userService.Register(user);

                    if (resultMessage.Equals("ok"))
                    {
                        return View("Login");
                    }
                    else
                    {
                        return Content("<script>alert('" + resultMessage + "')</script>");
                        //return View();
                    }
                }
            }
            return View();
        }
        #endregion

        #region 个人信息
        // Get:Login
        [Route("Info")]
        public ActionResult Info()
        {
            if (Session["userId"] == null) return Redirect("Login");
            int userId = int.Parse(Session["userId"].ToString());

            User user = userService.getUserById(userId);
            List<User_List> userRelease = userService.getUserList(userId);
            List<User_List> userFollow = userService.getUserFollow(userId);
            ViewData["myRelease"] = userRelease;
            ViewData["myFollow"] = userFollow;
            ViewData["userId"] = userId;

            return View();
        }
        #endregion
    }
}