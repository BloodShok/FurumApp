using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.PostViewModel
{
    public class CreatePostViewModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string TopicId { get; set; }
        [Required]
        public string MessageStringContent { get; set; }
    }
}