﻿using ForumApplication.WEB.Models.TopicViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.BaseViewModelItems
{
    public class NestedContainerElementsInfoViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CountOfNestedElements { get; set; }
        public LastUpdateTopicInfoViewModel LastUpdateTopic { get; set; }
    }
}