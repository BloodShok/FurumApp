using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.PostViewModel
{
    public class UpdatePostViewModel
    {
        [Required]
        public int PostId { get; set; }
        [Required]
        public string MessageStringContent { get; set; }
    }
}