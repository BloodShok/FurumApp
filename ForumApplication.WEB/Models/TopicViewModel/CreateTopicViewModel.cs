using ForumApplication.WEB.Models.BaseViewModelItems;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.TopicViewModel
{
    public class CreateTopicViewModel : BasePropertysForCreateViewModel
    {
        [Required]
        public int SectionId { get; set; }
    }
}