using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models
{
    public enum Gender
    {
        M = 0,
        F = 1
    }
    public class UserAccountsInfoViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Location { get; set; }
        public DateTime BirthDay { get; set; }
        public int Gender { get; set; }
        public string SomeInformation { get; set; }
        public string AttachedPicture { get; set; }
    }
}