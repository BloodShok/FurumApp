using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.Domain.Entitys
{
    public class UserAccount : IdentityUser
    {
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
