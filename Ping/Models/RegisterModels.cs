using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ping.Models
{
    public class RegisterModels
    {
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "必填")]
        public string UserName { get; set; }

        [Display(Name = "密码")]
        [Required(ErrorMessage = "必填")]
        [MinLength(6, ErrorMessage = "密码不少于6位")]
        [MaxLength(50, ErrorMessage = "密码不超过50位")]
        public string Password { set; get; }

        [Display(Name = "密码确认")]
        [Required(ErrorMessage = "必填")]
        [MinLength(6, ErrorMessage = "密码不少于6位")]
        [MaxLength(50, ErrorMessage = "密码不超过50位")]
        public string Password2 { set; get; }
    }
}