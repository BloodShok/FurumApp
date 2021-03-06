﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ForumApplication.WEB.Models.AccountViewModel
{
    public enum Gender
    {
        Male = 0,
        Female = 1
    }
    public class UserAccountsInfoViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public string Location { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime BirthDay { get; set; }
        public DateTime DateRegistration { get; set; }
        public Gender Gender { get; set; }
        public string SomeInformation { get; set; }
        public string Image { get; set; }
        

    }
}