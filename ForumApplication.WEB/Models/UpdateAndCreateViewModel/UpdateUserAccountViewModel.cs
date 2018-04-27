using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models
{
    public class UpdateUserAccountViewModel : UpdateUserProfileViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }

    }
}