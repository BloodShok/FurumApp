using System;

namespace ForumApplication.WEB.Models
{
    public class UserPostInfoViewModel : UserNameIdViewModel
    {
        public string Image { get; set; }
        public DateTime DateRegestration { get; set; }
    }
}