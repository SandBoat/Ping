using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ping.Models
{
    public class SearchModels
    {
        [Display(Name = "起点名")]
        public string StartAdress { get; set; }

        [Display(Name = "起点坐标x")]
        [Required(ErrorMessage = "必填")]
        public double Start_x { set; get; }

        [Display(Name = "起点坐标y")]
        [Required(ErrorMessage = "必填")]
        public double Start_y { set; get; }

        [Display(Name = "终点名")]
        public string EndAdress { get; set; }

        [Display(Name = "终点坐标x")]
        [Required(ErrorMessage = "必填")]
        public double End_x { set; get; }

        [Display(Name = "终点坐标y")]
        [Required(ErrorMessage = "必填")]
        public double End_y { set; get; }

        [Display(Name = "出发时间")]
        [Required(ErrorMessage = "必填")]
        public DateTime Departure { set; get; }
    }
}