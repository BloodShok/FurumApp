using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models
{
    public class UserPostInfoViewModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public string AttachedPicture { get; set; }
    }
}