using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Job_Notification.Models.LoginViewModel
{
    public class LoginViewModel
    {
        public string email { get; set; }
        
        public string password { get; set; }

        public bool remember { get; set; }
    }
}
