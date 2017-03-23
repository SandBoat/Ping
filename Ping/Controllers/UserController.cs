using BLL;
using DataSource;
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
                return Content("true");
            }
            return Content("false");
        }
    }
}