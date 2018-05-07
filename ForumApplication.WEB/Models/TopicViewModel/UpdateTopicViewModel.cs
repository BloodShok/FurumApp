using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.TopicViewModel
{
    public class UpdateTopicViewModel
    {
        [Required]
        public int TopicId { get; set; }
        [Required]
        public string Title { get; set; }
    }
}