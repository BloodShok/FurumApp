using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.TopicViewModel
{
    public class TopicInfoApiViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string SectionId { get; set; }
    }
}