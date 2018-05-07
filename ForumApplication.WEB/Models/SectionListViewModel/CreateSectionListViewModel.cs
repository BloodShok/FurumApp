using ForumApplication.WEB.Models.BaseViewModelItems;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.SectionListViewModel
{
    public class CreateSectionListViewModel : BasePropertysForCreateViewModel
    {
        [Required]
        public int ForumId { get; set; }
    }
}