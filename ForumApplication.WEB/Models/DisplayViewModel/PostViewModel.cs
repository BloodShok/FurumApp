using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string MessageStringContent { get; set; }
        public string AttachedPicture { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
        public UserPostInfoViewModel UserInfo { get; set; }
    }
}