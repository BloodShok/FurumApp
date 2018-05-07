using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.SectionViewModel
{
    public class UpdateSectionViewModel 
    {
        [Required]
        public int SectionId { get; set; }
        [Required]
        public string Title { get; set; }
    }
}