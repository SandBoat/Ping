using BLL.Models;
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
    /// 地图逻辑层
    /// </summary>
    public class MapService
    {

        private const int scopeDefault = 1000;

        private UserHandler userHandler = new UserHandler();
        private ListHandler listHandler = new ListHandler();
        private UserListHandler userListHandler = new UserListHandler();

        private CommonService commonService = new CommonService();

        #region 搜索
        public List<List> Search()
        {
            return listHandler.GetTodayList();
        }

        public List Search(int listId)
        {
            return listHandler.GetListById(listId);
        }
        public int SearchReleaseIdByListId(int listId)
        {
            return userListHandler.GetUserIdByListId(listId);
        }
        public User_List SearchUserListByListId(int uid, int listId)
        {
            return userListHandler.GetUserListById(uid, listId);
        }
        public List<List> Search(double start_x, double start_y, double end_x, double end_y, DateTime date)
        {
            return listHandler.GetListByAdress(start_x, start_y, end_x, end_y, date);
        }

        public List<List> SearchOrderByTime(double start_x, double start_y, double end_x, double end_y, DateTime date, TimeSpan time)
        {
            return listHandler.GetListByAdress(start_x, start_y, end_x, end_y, date).OrderBy(o => Math.Abs(o.Departure_Time.Ticks - time.Ticks)).ToList();
        }

        /// <summary>
        /// 搜索临近起点
        /// </summary>
        /// <param name="start_x"></param>
        /// <param name="start_y"></param>
        /// <param name="end_x"></param>
        /// <param name="end_y"></param>
        /// <param name="scope"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<SearchResultModels> SearchNearSA(double start_x, double start_y, double end_x, double end_y, int scope, DateTime date)
        {
            List<List> listToday = listHandler.GetListByDateAndEndAdress(end_x, end_y, date);
            List<SearchResultModels> SRMs = commonService.List2SRM_NS(listToday, start_x, start_y);
            return SRMs.Where(o => o.Distance > 0 && o.Distance <= scope).OrderBy(o => o.Distance).ToList();
            //return listToday.Where(o => (double)o.EndPoint_x == end_x && (double)o.EndPoint_y == end_y && commonService.getDistanceFromXtoY(start_x, start_y, (double)o.StartPoint_x, (double)o.StartPoint_y) < scope).ToList();
        }

        /// <summary>
        /// 搜索临近终点
        /// </summary>
        /// <param name="start_x"></param>
        /// <param name="start_y"></param>
        /// <param name="end_x"></param>
        /// <param name="end_y"></param>
        /// <param name="scope"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<SearchResultModels> SearchNearEA(double start_x, double start_y, double end_x, double end_y, int scope, DateTime date)
        {
            List<List> listToday = listHandler.GetListByDateAndStartAdresss(start_x, start_y, date);
            List<SearchResultModels> SRMs = commonService.List2SRM_NE(listToday, end_x, end_y);
            return SRMs.Where(o => o.Distance > 0 && o.Distance <= scope).OrderBy(o => o.Distance).ToList();
        }
        #endregion

        #region 发布
        /// <summary>
        /// 发布信息是否合法
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public string IsReleaseRight(List list)
        {
            return "ok";
        }


        public Boolean Release(List list, int userId)
        {
            User_List userList = new User_List();
            if (listHandler.Add(list))
            {
                userList.UserID = userId;
                userList.ListID = list.ListID;
                userList.Type = 1;
                return userListHandler.Add(userList);
            }
            return false;
        }
        #endregion

        #region 关注 & 取消关注
        public bool Follow(int userId, int listId)
        {
            User_List ul, ul2;
            if (userHandler.GetUserById(userId) != null && listHandler.GetListById(listId) != null)
            {
                ul = userListHandler.GetUserListById(userId, listId);
                if (ul == null)
                {
                    ul2 = new User_List();
                    ul2.ListID = listId;
                    ul2.UserID = userId;
                    ul2.Type = 2;
                    return userListHandler.Add(ul2);
                }
                else if (ul.Type == 3)
                {
                    ul.Type = 2;
                    return userListHandler.Update(ul);
                }
            }
            return false;
        }

        public bool UnFollow(int userId, int listId)
        {
            User_List ul;
            if (userHandler.GetUserById(userId) != null && listHandler.GetListById(listId) != null)
            {
                ul = userListHandler.GetUserListById(userId, listId);
                if (ul != null && ul.Type == 2)
                {
                    ul.Type = 3;
                    return userListHandler.Update(ul);
                }
            }
            return false;
        }
        #endregion
    }
}
