using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.SectionListViewModel
{
    public class UpdateSectionListViewModel
    {
        [Required]
        public int SectionListId { get; set; }
        [Required]
        public string Title { get; set; }
    }
}