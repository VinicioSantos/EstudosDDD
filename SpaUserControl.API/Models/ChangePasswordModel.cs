using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaUserControl.API.Models
{
    public class ChangePasswordModel
    {
        public string Password { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }
    }
}