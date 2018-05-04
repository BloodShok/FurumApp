using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models
{

    public class TableCreateAccountViewModel
    {
        [Required(ErrorMessage ="Please enter Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter UserName")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Name must have minimum 5 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }

        public string RoleName { get; set; }
        public bool IsActive { get; set; }
        public string Location { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime DateRegistration { get; set; }
        public Gender Gender { get; set; }
        public string SomeInformation { get; set; }
        public string Image { get; set; }

    }
}