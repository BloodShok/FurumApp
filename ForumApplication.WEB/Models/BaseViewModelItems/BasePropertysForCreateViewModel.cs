using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.BaseViewModelItems
{
    public class BasePropertysForCreateViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string UserAccountId { get; set; }
    }
}