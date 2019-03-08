using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationSignalr.Models
{
    public class loginView
    {
        [Required (ErrorMessage ="請輸入帳號")]
        public string account { get; set; }
        [Required(ErrorMessage = "請輸入密碼")]
        public string password { get; set; }
        public int busnumbr { get; set; }
    }
}