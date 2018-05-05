using ForumApplication.WEB.Models.BaseViewModelItems;
using System;

namespace ForumApplication.WEB.Models.TopicViewModel
{
    public class UserPostInfoViewModel 
    {
        public string Image { get; set; }
        public DateTime DateRegestration { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}