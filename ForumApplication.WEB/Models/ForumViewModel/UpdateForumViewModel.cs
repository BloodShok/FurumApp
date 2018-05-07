using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.ForumViewModel
{
    public class UpdateForumViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int ForumId { get; set; }
    }
}