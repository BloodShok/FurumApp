using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models
{
    public class CreateTopicViewModel : BasePropertysForCreateViewModel
    {
        public int SectionId { get; set; }
    }
}