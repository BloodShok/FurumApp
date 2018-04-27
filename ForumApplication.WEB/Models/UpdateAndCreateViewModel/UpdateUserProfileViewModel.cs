using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models
{
    public class UpdateUserProfileViewModel
    {
        public string Id { get; set; }
        public DateTime BirthDay { get; set; }
        public Gender Gender { get; set; }
        public string SomeInformation { get; set; }
        public string Location { get; set; }
    }
}