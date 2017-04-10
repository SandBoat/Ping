using DataSource;
using BLL;
using Ping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Models;

namespace Ping.Controllers
{
    [RoutePrefix("ZuChe")]
    public class ZuCheController : Controller
    {
        private MapService mapService = new MapService();

        #region 搜索
        // Get:Search
        public ActionResult Search()
        {
            return View();
        }

        // Get:Info
        public ActionResult Info()
        {
            return Redirect("~/ZuChe/Search");
        }

        // Post:Info
        [HttpPost]
        public ActionResult Info(SearchModels searchModel)
        {
            List<List> mapLists = mapService.SearchOrderByTime(searchModel.Start_x, searchModel.Start_y
                 , searchModel.End_x, searchModel.End_y
                 , searchModel.Departure.Date, searchModel.Departure.TimeOfDay);

            ViewData["mapLists"] = mapLists;
            ViewData["start_x"] = searchModel.Start_x;
            ViewData["start_y"] = searchModel.Start_y;
            ViewData["end_x"] = searchModel.End_x;
            ViewData["end_y"] = searchModel.End_y;
            ViewData["date"] = searchModel.Departure.Date;

            return View();
        }

        // Get:Detail/listId
        [Route("Detail/{id:int}")]
        public ActionResult Detail(int id)
        {
            if (id > 0)
            {
                List list = mapService.Search(id);
                if (list != null)
                {
                    ViewData["RelesseUserID"] = mapService.SearchReleaseIdByListId(list.ListID);
                    ViewData["userListType"] = -1;
                    if (Session["userId"] != null)
                    {
                        int userId = int.Parse(Session["userId"].ToString());
                        User_List ul = mapService.SearchUserListByListId(userId, id);
                        if (ul != null) ViewData["userListType"] = (int)ul.Type;
                    }
                    return View(list);
                }
            }
            return Redirect("~/ZuChe/Search");
        }

        //Ajax：搜索临近起点 
        //[HttpPost]
        [Route("SearchNearStartAdress/{start_x:double,start_y:double,end_x:double,end_y:double,scope:int}")]
        public String SearchNearStartAdress(double start_x, double start_y, double end_x, double end_y, int scope, DateTime date)
        {
            List<SearchResultModels> SRMs = mapService.SearchNearSA(start_x, start_y, end_x, end_y, scope, date);
            string s = string.Join("|", SRMs.Select(o => o.StartAdress).ToArray());
            return s;
        }
        //Ajax：搜索临近终点 
        //[HttpPost]
        [Route("SearchNearEndAdress/{start_x:double,start_y:double,end_x:double,end_y:double,scope:int}")]
        public String SearchNearEndAdress(double start_x, double start_y, double end_x, double end_y, int scope, DateTime date)
        {
            List<SearchResultModels> SRMs = mapService.SearchNearEA(start_x, start_y, end_x, end_y, scope, date);
            string s = string.Join("|", SRMs.Select(o => o.EndAdress).ToArray());
            return s;
        }
        #endregion

        #region 关注
        //Ajax:关注
        [HttpPost]
        [Route("Follow/{listId:int}")]
        public String Follow(int listId)
        {
            if (Session["userId"] == null) return "login";
            int userId = int.Parse(Session["userId"].ToString());

            if (mapService.Follow(userId, listId))
            {
                return "ok";
            }
            return "false";
        }

        //Ajax:取消关注
        [HttpPost]
        [Route("Follow/{listId:int}")]
        public String UnFollow(int listId)
        {
            if (Session["userId"] == null) return "login";
            int userId = int.Parse(Session["userId"].ToString());

            if (mapService.UnFollow(userId, listId))
            {
                return "ok";
            }
            return "false";
        }

        #endregion

        #region 发布
        // Get:Release
        public ActionResult Release()
        {
            if (Session["userId"] == null) return Redirect("~/User/Login");

            return View();
        }

        // Post:Release
        [HttpPost]
        public ActionResult Release(ReleaseModels releaseModel)
        {
            if (Session["userId"] == null) return Redirect("~/User/Login");
            int userId = int.Parse(Session["userId"].ToString());

            List list = new List();
            if (ModelState.IsValid)
            {
                list.StartAdress = releaseModel.StartAdress.Trim();
                list.StartPoint_x = (decimal)releaseModel.Start_x;
                list.StartPoint_y = (decimal)releaseModel.Start_y;
                list.EndAdress = releaseModel.EndAdress.Trim();
                list.EndPoint_x = (decimal)releaseModel.End_x;
                list.EndPoint_y = (decimal)releaseModel.End_y;
                list.Departure_Date = releaseModel.Departure.Date;
                list.Departure_Time = releaseModel.Departure.TimeOfDay;
                list.Sex = releaseModel.Sex.Equals("男") ? (byte)1 : releaseModel.Sex.Equals("女") ? (byte)2 : (byte)0;
                list.Contacts = releaseModel.Contacts;
                list.detail = releaseModel.detail;
                if (mapService.Release(list, userId))
                {
                    return Redirect("~/User/Info");
                }
                else {
                    return View(releaseModel);
                }
            }
            ModelState.AddModelError("", "信息填写不完整");
            return View(releaseModel);
        }
        #endregion
    }
}