using BLL.Models;
using DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CommonService
    {
        /// <summary>
        /// 根据百度地图坐标
        /// 获得点1和点2之间的距离
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public double getDistanceFromXtoY(double x1, double y1, double x2, double y2)
        {
            double pk = 180 / Math.PI;
            double a1 = x1 / pk;
            double a2 = y1 / pk;
            double b1 = x2 / pk;
            double b2 = y2 / pk;
            double t1 = Math.Cos(a1) * Math.Cos(a2) * Math.Cos(b1) * Math.Cos(b2);
            double t2 = Math.Cos(a1) * Math.Sin(a2) * Math.Cos(b1) * Math.Sin(b2);
            double t3 = Math.Sin(a1) * Math.Sin(b1);
            double tt = Math.Acos(t1 + t2 + t3);
            return 6366000 * tt;
        }

        /// <summary>
        /// 转换为临近起点的Model
        /// </summary>
        /// <param name="lists"></param>
        /// <param name="target_x"></param>
        /// <param name="target_y"></param>
        /// <returns></returns>
        public List<SearchResultModels> List2SRM_NS(List<List> lists, double target_x, double target_y)
        {
            List<SearchResultModels> SRMs = new List<SearchResultModels>();

            SearchResultModels sRM;
            foreach (var o in lists)
            {
                sRM = new SearchResultModels();
                sRM.StartAdress = o.StartAdress;
                sRM.StartPoint_x = (double)o.StartPoint_x;
                sRM.StartPoint_y = (double)o.StartPoint_y;
                sRM.EndAdress = o.EndAdress;
                sRM.EndPoint_x = (double)o.EndPoint_x;
                sRM.EndPoint_y = (double)o.EndPoint_y;
                sRM.Distance = getDistanceFromXtoY(sRM.StartPoint_x, sRM.StartPoint_y, target_x, target_y);
                SRMs.Add(sRM);
            }
            return SRMs;
        }

        /// <summary>
        /// 转换为临近终点的Model
        /// </summary>
        /// <param name="lists"></param>
        /// <param name="target_x"></param>
        /// <param name="target_y"></param>
        /// <returns></returns>
        public List<SearchResultModels> List2SRM_NE(List<List> lists, double target_x, double target_y)
        {
            List<SearchResultModels> SRMs = new List<SearchResultModels>();

            SearchResultModels sRM;
            foreach (var o in lists)
            {
                sRM = new SearchResultModels();
                sRM.StartAdress = o.StartAdress;
                sRM.StartPoint_x = (double)o.StartPoint_x;
                sRM.StartPoint_y = (double)o.StartPoint_y;
                sRM.EndAdress = o.EndAdress;
                sRM.EndPoint_x = (double)o.EndPoint_x;
                sRM.EndPoint_y = (double)o.EndPoint_y;
                sRM.Distance = getDistanceFromXtoY(sRM.EndPoint_x, sRM.EndPoint_y, target_x, target_y);
                SRMs.Add(sRM);
            }
            return SRMs;
        }
    }
}
