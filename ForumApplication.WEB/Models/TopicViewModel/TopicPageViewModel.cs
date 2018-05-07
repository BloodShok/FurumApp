using ForumApplication.WEB.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.TopicViewModel
{
    public class TopicPageViewModel
    {
        public TopicInfoViewModel TopicInfoView { get; set; }
        public Page PageInfo { get; set; }
    }
}