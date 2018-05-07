using ForumApplication.WEB.Models.BaseViewModelItems;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.SectionViewModel
{
    public class CreateSectionViewModel : BasePropertysForCreateViewModel
    {
        [Required]
        public int SectionListId { get; set; }
    }
}