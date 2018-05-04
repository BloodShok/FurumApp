using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.PostViewModel
{
    public class CreatePostViewModel
    {
        public string UserId { get; set; }
        public string TopicId { get; set; }
        public string MessageStringContent { get; set; }
    }
}