using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models
{
    public class JtableCreateAccountViewModel
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
        public string Location { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime DateRegistration { get; set; }
        public Gender Gender { get; set; }
        public string SomeInformation { get; set; }
        public string Image { get; set; }
        public string Password { get; set; }
    }
}