using ForumApplication.WEB.Models.BaseViewModelItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.TopicViewModel
{
    public class CreateTopicViewModel : BasePropertysForCreateViewModel
    {
        public int SectionId { get; set; }
    }
}