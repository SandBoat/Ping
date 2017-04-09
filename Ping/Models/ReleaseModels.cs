using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ping.Models
{
    public class ReleaseModels
    {
        [Display(Name = "起点名")]
        [Required(ErrorMessage = "必填")]
        public string StartAdress { get; set; }

        [Display(Name = "起点坐标x")]
        [Required(ErrorMessage = "必填")]
        public double Start_x { set; get; }

        [Display(Name = "起点坐标y")]
        [Required(ErrorMessage = "必填")]
        public double Start_y { set; get; }

        [Display(Name = "终点名")]
        [Required(ErrorMessage = "必填")]
        public string EndAdress { get; set; }


        [Display(Name = "终点坐标x")]
        [Required(ErrorMessage = "必填")]
        public double End_x { set; get; }

        [Display(Name = "终点坐标y")]
        [Required(ErrorMessage = "必填")]
        public double End_y { set; get; }

        [Display(Name = "出发时间")]
        [Required(ErrorMessage = "必填")]
        public DateTime Departure { get; set; }

        [Display(Name = "性别")]
        [Required(ErrorMessage = "必填")]
        public string Sex { get; set; }

        [Display(Name = "联系方式")]
        [Required(ErrorMessage = "必填")]
        [MaxLength(50)]
        public string Contacts { get; set; }

        [Display(Name = "要求")]
        [MaxLength(250)]
        public string detail { get; set; }
    }
}