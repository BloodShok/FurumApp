using ForumApplication.WEB.Models.AccountViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.AdministratorViewModel
{
    public class UpdateUserProfileViewModel
    {
        [Required]
        public string AccountId { get; set; }
        public DateTime BirthDay { get; set; }
        public Gender Gender { get; set; }
        public string SomeInformation { get; set; }
        public string Location { get; set; }
    }
}