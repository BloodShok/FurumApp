﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.Domain.Entitys
{
    public class UserAccount : IdentityUser
    {
        public UserProfile UserProfile { get; set; }
        public bool IsActive { get; set; }
        
    }
}
