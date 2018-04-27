using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models
{
    public class PostInfoViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string MessageStringContent { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
        public UserNameIdViewModel UserInfo { get; set; }
    }
}