using ForumApplication.WEB.Models.BaseViewModelItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.TopicViewModel
{
    public class TopicInfoViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
        public IList<PostInfoViewModel> PostViewModel { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}